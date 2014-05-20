using System;
using System.Text;
using NUnit.Framework;
using Expedia;
using System.Data.SqlClient;

namespace ExpediaTest
{
	[TestFixture()]
    class IntegrationTests
    {

        private void ExecuteSQLFile(string filename, SqlConnection conn)
        {
            System.IO.StreamReader myFile = new System.IO.StreamReader(filename);
            string filedata = myFile.ReadToEnd();
            myFile.Close();
            // folks on the internet suggest that this is a little
            // more powerful than other ways we might invoke the SQL 
            SqlCommand command = conn.CreateCommand();
            command.CommandText = filedata;
            command.ExecuteNonQuery();
        }

    }
}
