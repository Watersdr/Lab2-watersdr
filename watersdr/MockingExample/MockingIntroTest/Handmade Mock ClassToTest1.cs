using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MockingIntroTestHandmadeMock
{
    class RecordsForDB
    {

        public int numberOfRecords = 100;

        public void deleteAllRecords(IDatabase db)
        {
            db.executeQuery("DELETE FROM RECORDS");
            numberOfRecords = 0;
        }
    }

    [TestFixture]
    public class MikeDemoTests
    {
        [Test]
        public void testDeleteAllRecordsHandmadeMock()
        {
            RecordsForDB data = new RecordsForDB();
            FakeDatabase fakeDB = new FakeDatabase();
            Assert.AreEqual(100, data.numberOfRecords);
            data.deleteAllRecords(fakeDB);
            Assert.AreEqual(0, data.numberOfRecords);
            Assert.AreEqual("DELETE FROM RECORDS", fakeDB.lastParam);            
        }
    }

    public class FakeDatabase : IDatabase
    {
        public string lastParam;
        public void executeQuery(string query)
        {
            lastParam = query;
        }
    }

    public interface IDatabase
    {
        void executeQuery(string query);
    }
}
