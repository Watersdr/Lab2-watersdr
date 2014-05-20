using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using Rhino.Mocks.Interfaces;
using Rhino.Mocks.Impl;

namespace MockingWithRhino
{
    [TestFixture]
    public class LogAnalyzerTest
    {

        [Test]
        public void Analyze_TooShortFileName_ErrorLoggedtoService_NonStrictMock()
        {
            MockRepository mocks = new MockRepository();
            IWebService simulatedService = mocks.DynamicMock<IWebService>();

            using (mocks.Record())
            {

                simulatedService.LogError("Filename too short:abc.ext");
            }

            LogAnalyzer log = new LogAnalyzer(simulatedService);
            string tooShortFileName = "abc.ext";
           log.Analyze(tooShortFileName);

            mocks.VerifyAll();

        }

        [Test]
        public void ReturnResultsFromMock()
        {
            
            MockRepository mocks = new MockRepository();
            IGetResults resultGetter = mocks.DynamicMock<IGetResults>();
            
            using (mocks.Record())
            {
                resultGetter.GetSomeNumber("a");
                LastCall.Return(1);

                resultGetter.GetSomeNumber("c");
                LastCall.Return(2);

                resultGetter.GetSomeNumber("b");
                LastCall.Return(3);
            }

            int result;

            result = resultGetter.GetSomeNumber("b");
            Assert.AreEqual(3, result);

            result = resultGetter.GetSomeNumber("a");
            Assert.AreEqual(1, result);

            result = resultGetter.GetSomeNumber("c");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ReturnResultsFromStub()
        {

            MockRepository mocks = new MockRepository();
            IGetResults resultGetter = mocks.Stub<IGetResults>();

            using (mocks.Record())
            {
                resultGetter.GetSomeNumber("a");
                LastCall.Return(1);

                resultGetter.GetSomeNumber("c");
                LastCall.Return(2);

                resultGetter.GetSomeNumber("b");
                LastCall.Return(3);
            }

            int result;

            result = resultGetter.GetSomeNumber("b");
            Assert.AreEqual(3, result);

            result = resultGetter.GetSomeNumber("a");
            Assert.AreEqual(1, result);

            result = resultGetter.GetSomeNumber("c");
            Assert.AreEqual(2, result);

        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            MockRepository mocks = new MockRepository();
            IWebService stubService = mocks.DynamicMock<IWebService>();
            IEmailService mockEmail = mocks.DynamicMock<IEmailService>();

            using (mocks.Record())
            {
                stubService.LogError("whatever");
                LastCall.Constraints(Rhino.Mocks.Constraints.Is.Anything());
                LastCall.Throw(new Exception("fake exception"));

                mockEmail.SendEmail("a", "subject", "fake exception");
            }

            LogAnalyzer2 log = new LogAnalyzer2();
            log.Service = stubService;
            log.Email = mockEmail;

            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);

            mocks.VerifyAll();
        }
             

         //[Test]
        //[Ignore("Tests Unhandled Out of Memory Exception")]
        public void StubSimulatingException()
        {
            MockRepository repository = new MockRepository();
            IGetResults resultGetter = repository.Stub<IGetResults>();
            using (repository.Record())
            {
                resultGetter.GetSomeNumber("A");
                LastCall.Throw(new OutOfMemoryException("The system is out of memory!"));
            }
            resultGetter.GetSomeNumber("A");
        }

          
    }

 }
