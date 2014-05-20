
using System;
using System.Data;
using System.Data.SqlClient;

namespace Expedia
{
	public class Hotel : Booking
	{
		private int numberOfNightsToRent;
		
		#region Booking implementation
        public double getBasePrice()
		{
			return 45 * numberOfNightsToRent;
		}
		#endregion
		
		public Hotel (int nightsToRent)
		{
			if(nightsToRent <= 0)
				throw new ArgumentOutOfRangeException("Nights to rent must be greater than zero!");
			
			numberOfNightsToRent = nightsToRent;
		}
		
		public override bool Equals(object obj) {
			if(obj is Hotel) {
				return Equals(obj as Hotel);
			}
			
			return base.Equals(obj);
		}
		
		private bool Equals(Hotel obj) {
			return obj.numberOfNightsToRent.Equals(this.numberOfNightsToRent);
		}

        public static Hotel fromDatafile(string[] data)
        {
            if (data.Length != 2)
                throw new ArgumentException("hotel passed incorrect number of parameters. Should be 2.  Was " + data.Length);
            if (data[0] != "HOTEL")
                throw new ArgumentException("First parameter to car should be HOTEL.  Was " + data[0]);
            return new Hotel(Convert.ToInt32(data[1]));
        }


	    public void WriteToDB(SqlConnection sqlConn)
	    {
	        SqlCommand sqlComm = sqlConn.CreateCommand();
	        sqlComm.CommandText = @"INSERT INTO Hotels (NumberOfNights) VALUES (@nights)";
	        AddParameters(sqlComm);
	        sqlComm.ExecuteNonQuery();
	    }

        public Boolean IsAlreadyInDB(SqlConnection sqlConn)
        {
            SqlCommand sqlComm = sqlConn.CreateCommand();
	        sqlComm.CommandText = @"SELECT COUNT(*) FROM Hotels WHERE NumberOfNights = @nights";
	        AddParameters(sqlComm);
	        int count = (int) sqlComm.ExecuteScalar();
            return count > 0;
        }

	    private void AddParameters(SqlCommand sqlComm)
	    {
	        sqlComm.Parameters.Add("@nights", SqlDbType.Int);
	        sqlComm.Parameters["@nights"].Value = numberOfNightsToRent;
	    }
	}
}
