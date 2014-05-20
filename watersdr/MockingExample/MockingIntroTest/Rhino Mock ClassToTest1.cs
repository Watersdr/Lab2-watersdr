using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using Rhino.Mocks;

namespace MockingIntroTestRhinoMock
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
        public void testDeleteAllRecordsRhinoStub()
        {
            RecordsForDB data = new RecordsForDB();
            IDatabase fakeDB = mock.Stub<IDatabase>();
            Assert.AreEqual(100, data.numberOfRecords);
            data.deleteAllRecords(fakeDB);
            Assert.AreEqual(0, data.numberOfRecords);
        }

        [Test]
        public void testDeleteAllRecordsRhinoMock()
        {
            RecordsForDB data = new RecordsForDB();
            IDatabase fakeDB = mock.DynamicMock<IDatabase>();

            //note that this ASSERTING that this function will be called
            fakeDB.executeQuery("DELETE FROM RECORDS");

            mock.ReplayAll();
            Assert.AreEqual(100, data.numberOfRecords);
            data.deleteAllRecords(fakeDB);
            Assert.AreEqual(0, data.numberOfRecords);
            mock.VerifyAll();
        }
    }

    public interface IDatabase
    {
        void executeQuery(string query);
    }
}
