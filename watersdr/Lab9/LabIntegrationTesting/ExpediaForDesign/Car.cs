
using System;
using System.Data;
using System.Data.SqlClient;

namespace Expedia
{
	public class Car : Booking
	{
		private int numberOfDaysToRent;
		
		#region Booking implementation
        public double getBasePrice()
		{	
			double result = numberOfDaysToRent * 10;
			
			if(numberOfDaysToRent > 5)
			{	
				result *= 0.8;
			}
			
			return result;
		}
		#endregion
		
		public Car (int daysToRent)
		{
			if(daysToRent <= 0)
				throw new ArgumentOutOfRangeException("Days to Rent must be greater than zero!");
			
			numberOfDaysToRent = daysToRent;
		}

        public static Car fromDatafile(string[] data)
        {
            if (data.Length != 2)
                throw new ArgumentException("car passed incorrect number of parameters. Should be 2.  Was " + data.Length);
            if (data[0] != "CAR")
                throw new ArgumentException("First parameter to car should be CAR.  Was " + data[0]);
            return new Car(Convert.ToInt32(data[1]));
        }


        public Boolean IsAlreadyInDB(SqlConnection sqlConn)
        {
            SqlCommand sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"SELECT COUNT(*) FROM Cars WHERE NumberOfDays = @days";
            AddParameters(sqlComm);
            int count = (int)sqlComm.ExecuteScalar();
            return count > 0;
        }

	    public void WriteToDB(SqlConnection sqlConn)
	    {
	        SqlCommand sqlComm = sqlConn.CreateCommand();
	        sqlComm.CommandText = @"INSERT INTO Cars (NumberOfDays) VALUES (@days)";
	        AddParameters(sqlComm);
            
	        sqlComm.ExecuteNonQuery();
	    }

	    private void AddParameters(SqlCommand sqlComm1)
	    {
	        sqlComm1.Parameters.Add("@days", SqlDbType.Int);
	        sqlComm1.Parameters["@days"].Value = numberOfDaysToRent;
	    }
	}
}
