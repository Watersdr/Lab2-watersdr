using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using Rhino.Mocks;

namespace MockingIntroTest3
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
        private MockRepository mock;
        [SetUp]
        public void setup()
        {
            mock = new MockRepository();
        }

        [Test]
        public void testDumbTest()
        {
            RecordsForDB data = new RecordsForDB();
            IDatabase fakeDB = mock.DynamicMock<IDatabase>();

            //note that this ASSERTING that this function will be called
            fakeDB.executeQuery("DELETE FROM RECORDS");

            mock.ReplayAll();
            Assert.AreEqual(100, data.numberOfRecords);
            fakeDB.executeQuery("DELETE FROM RECORDS");
            mock.VerifyAll();
            
        }
    }


    public interface IDatabase
    {
        void executeQuery(string query);
    }
}
