
using System;
using System.Data.SqlClient;

namespace Expedia
{
	public interface Booking
	{
		double getBasePrice();

	    Boolean IsAlreadyInDB(SqlConnection sqlConn);
        void WriteToDB(SqlConnection sqlConn);

	}
}
