
using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace Expedia
{
    public class Flight : Booking
    {
        private DateTime dateThatFlightLeaves;
        private DateTime dateThatFlightReturns;

        public int Miles
        {
            get;
            private set;
        }

        #region Booking implementation
        public double getBasePrice()
        {
            var lengthOfSpread = (dateThatFlightReturns - dateThatFlightLeaves).Days;

            return 200 + lengthOfSpread * 20;
        }
        #endregion

        public Flight(DateTime startDate, DateTime endDate, int someMiles)
        {
            if (endDate < startDate)
                throw new InvalidOperationException("End date cannot be before start date!");

            if (someMiles < 0)
                throw new ArgumentOutOfRangeException("Miles must be positive!");

            dateThatFlightLeaves = startDate;
            dateThatFlightReturns = endDate;
            Miles = someMiles;
        }

        public override bool Equals(object obj)
        {
            if (obj is Flight)
            {
                return Equals(obj as Flight);
            }

            return base.Equals(obj);
        }

        private bool Equals(Flight obj)
        {
            bool l = obj.dateThatFlightLeaves.Equals(this.dateThatFlightLeaves);
            bool r = obj.dateThatFlightReturns.Equals(this.dateThatFlightReturns);
            bool m = obj.Miles.Equals(this.Miles);
            return l && r && m;
        }

        private static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static Flight fromDatafile(string[] data)
        {
            if (data.Length != 4)
                throw new ArgumentException("hotel passed incorrect number of parameters. Should be 4.  Was " + data.Length);
            if (data[0] != "FLIGHT")
                throw new ArgumentException("First parameter to car should be FLIGHT.  Was " + data[0]);
            DateTime start = FromUnixTime(Convert.ToInt64(data[1]));
            DateTime end = FromUnixTime(Convert.ToInt64(data[2]));
            return new Flight(start, end, Convert.ToInt32(data[3]));
        }

        public Boolean IsAlreadyInDB(SqlConnection sqlConn)
        {
            SqlCommand sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"SELECT COUNT(*) FROM Flights WHERE (StartTime = @start) AND (ReturnTime = @start) AND (Distance = @distance)";
            AddParameters(sqlComm);
            int count = (int)sqlComm.ExecuteScalar();
            return count > 0;
        }

        public void WriteToDB(SqlConnection sqlConn)
        {
            SqlCommand sqlComm1 = sqlConn.CreateCommand();
            sqlComm1.CommandText = @"INSERT INTO Flights (StartTime, ReturnTime, Distance) VALUES (@start, @return, @distance)";
            AddParameters(sqlComm1);
            SqlCommand sqlComm = sqlComm1;
            
            sqlComm.ExecuteNonQuery();
        }

        private void AddParameters(SqlCommand sqlComm1)
        {
            sqlComm1.Parameters.Add("@distance", SqlDbType.Int);
            sqlComm1.Parameters["@distance"].Value = Miles;
            sqlComm1.Parameters.Add("@start", SqlDbType.DateTime);
            sqlComm1.Parameters["@start"].Value = new SqlDateTime(dateThatFlightLeaves);
            sqlComm1.Parameters.Add("@return", SqlDbType.DateTime);
            sqlComm1.Parameters["@return"].Value = new SqlDateTime(dateThatFlightReturns);
        }
    }
}
