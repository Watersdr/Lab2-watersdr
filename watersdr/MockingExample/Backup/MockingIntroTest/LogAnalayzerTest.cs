using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;
using NUnit.Framework;

namespace MockingIntroTest
{
    [TestFixture]
    public class LogAnalyzerTests
    {
    //    Notice how the assert is performed against the mock object, and not
    //against the LogAnalyzer class. That’s because we’re testing the interaction
    //between LogAnalyzer and the web service.

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            MockService mockService = new MockService();
            LogAnalyzer log = new LogAnalyzer(mockService);
            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);

            Assert.AreEqual("Filename too short:abc.ext", mockService.LastError);
        }
    }

    public class MockService : IWebService
    {
        public string LastError;

        public void LogError(string message)
        {
            LastError = message;
        }

    }
}
