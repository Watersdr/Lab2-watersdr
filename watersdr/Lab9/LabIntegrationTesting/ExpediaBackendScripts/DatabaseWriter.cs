using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace Expedia
{
    class DatabaseWriter
    {
        public void CreateNewItemsFromWebPage()
        {
            WebClient client = new WebClient();
            string data = client.DownloadString("http://hewner.com/cgi-bin/CurrentTravelData.cgi");
            //System.Console.WriteLine(data);
            string[] lines = data.Split('\n');

            List<Booking> bookings = new List<Booking>();

            foreach (string line in lines)
            {
                if (line == "")
                    continue; // ignore blank lines            
                bookings.Add(CreateBookingForLine(line));
            }

            SqlConnection sqlConn = new SqlConnection("Server=whale.cs.rose-hulman.edu;Database=yourdb;User Id=yourusername;Password=yourpassword;");
            int numBookingsAdded = 0;
            int numBookingsSkipped = 0;
            try
            {
                sqlConn.Open();
                foreach (Booking currentBooking in bookings)
                {

                    if (currentBooking.IsAlreadyInDB(sqlConn))
                    {
                        Console.WriteLine("Skipping item - already in DB");
                        numBookingsSkipped++;
                    }
                    else
                    {
                        Console.WriteLine("Writing to DB");
                        currentBooking.WriteToDB(sqlConn);
                        numBookingsAdded++;
                    }
                }
            }
            finally
            {
                sqlConn.Close();
            }
            Console.WriteLine("Saved {0} bookings, skipped {1} bookings", numBookingsAdded, numBookingsSkipped);
            
        }

        private static Booking CreateBookingForLine(string line)
        {
            Booking currentBooking = null;
            string[] words = line.Split(' ');
            switch (words[0])
            {
                case "CAR":
                    currentBooking = Car.fromDatafile(words);
                    break;
                case "FLIGHT":
                    currentBooking = Flight.fromDatafile(words);
                    break;
                case "HOTEL":
                    currentBooking = Hotel.fromDatafile(words);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unexpected line: " + line);
            }
            return currentBooking;
        }

        public static void Main()
        {
            DatabaseWriter writer = new DatabaseWriter();
            writer.CreateNewItemsFromWebPage();
            System.Console.WriteLine("Load/Write complete.  Press [Enter] to exit.");
            System.Console.ReadLine();
        }
    }
}
