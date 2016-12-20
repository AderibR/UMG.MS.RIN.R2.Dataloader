using System;
using DDEX.FRIN10.MessagingClassLibrary.f_rin;
using Moq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UMG.MS.Library.Services.R2;

namespace UMG.MS.RIN.R2.Dataloader.FunctionalTests.Steps
{
    [Binding]
    public class SharedSteps
    {
        private Mock<IR2Service> _mockR2Service;

        //[BeforeTestRun]
        //public void SetupMocks()
        //{

        //    _mockR2Service = new Mock<IR2Service>();
        //}

        [When(@"I transform that RIN for the R2 Data Loader")]
        public void WhenITransformThatRINForTheRDataLoader()
        {
            var rin = (RecordingInformationNotification)ScenarioContext.Current["RIN"];

            //var _rinProcessor = new RinProcessor();

            _mockR2Service = new Mock<IR2Service>();

            string capturedDataLoaderXml = null;
            _mockR2Service.Setup(x => x.GetLoaderResponseXml(It.IsAny<string>()))
                .Callback((string a1) => capturedDataLoaderXml = a1)
                .Returns(string.Empty);

            //_rinProcessor.ProcessAsync(rin);

            ScenarioContext.Current["DataLoaderMessage"] = capturedDataLoaderXml;
        }

        [When(@"I run")]
        public void WhenIRun()
        {
            var i = 1;
        }

        [Then(@"I stop")]
        public void ThenIStop()
        {
            Assert.That(true, Is.True);
        }
    }
}
