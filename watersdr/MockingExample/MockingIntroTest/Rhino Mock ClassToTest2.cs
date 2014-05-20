using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using Rhino.Mocks;

namespace MockingIntroTest2Rhino
{
    class RecordsForDB2
    {
        private IDatabase db;
        private IErrorLoggingService logger;

        public RecordsForDB2(IDatabase dbForRecords, IErrorLoggingService errorLoggingService)
        {
            db = dbForRecords;
            logger = errorLoggingService;
        }

        public void checkCatastropicDBError()
        {
            if (db.hasCatastropicDatabaseError())
            {
                logger.LogError("A catastropic db error has occured");
            }
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
        public void testDBError()
        {
            IDatabase fakeDB = mock.DynamicMock<IDatabase>();
            IErrorLoggingService fakeService = mock.DynamicMock<IErrorLoggingService>();
            
            Expect.Call(fakeDB.hasCatastropicDatabaseError()).Return(true);
            fakeService.LogError("A catastropic db error has occured");

            mock.ReplayAll();

            RecordsForDB2 data = new RecordsForDB2(fakeDB, fakeService);
            data.checkCatastropicDBError();
            mock.VerifyAll();
            
        }
    }

    public interface IDatabase
    {
        void executeQuery(string query);
        bool hasCatastropicDatabaseError();
    }

    public interface IErrorLoggingService
    {
        void LogError(string message);
    }
}
