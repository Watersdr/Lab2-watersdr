using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using Rhino.Mocks;

namespace MockingIntroTest
{
    class RecordsForDB
    {

        public int numberOfRecords = 100;

        public void deleteAllRecords(IDatabase db)
        {
            //db.executeQuery("DELETE FROM RECORDS");
            numberOfRecords = 0;
        }
    }

    [TestFixture]
    public class MikeDemoTests
    {
        [Test]
        public void testDeleteAllRecords()
        {
            MockRepository mock = new MockRepository();

            RecordsForDB data = new RecordsForDB();
            IDatabase fakeDatabase = mock.DynamicMock<IDatabase>();
            fakeDatabase.executeQuery("DELETE FROM RECORDS");
            mock.ReplayAll();

            Assert.AreEqual(100, data.numberOfRecords);
            data.deleteAllRecords(fakeDatabase);
            Assert.AreEqual(0, data.numberOfRecords);
            mock.VerifyAll();
        }
    }

    public class FakeDatabase : IDatabase
    {
        public String savedQuery;
        public void executeQuery(String query)
        {
            savedQuery = query;
        }
    }



    public interface IDatabase
    {
        void executeQuery(string query);
    }
}
