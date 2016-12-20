using System;
using System.Collections.Generic;
using DDEX.FRIN10.MessagingClassLibrary.f_rin;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UMG.MS.RIN.R2.Dataloader.FunctionalTests.Helpers;
using UMG.MS.RIN.R2.Dataloader.FunctionalTests.TestRINBuilders;

namespace UMG.MS.RIN.R2.Dataloader.FunctionalTests.Steps
{
    [Binding]
    public class R2ResourceSteps
    {
        [Given(@"a RIN with this sound recording information")]
        public void GivenARINWithThisSoundRecordingInformation(Table table)
        {
            var titleText = table.Rows[0]["TitleText"];
            var soundRecordings = new List<SoundRecording>
            {
                new TestSoundRecordingBuilder().WithTitleText(titleText).Build()
            };

            var rin = new TestRinBuilder().WithSoundRecordings(soundRecordings).Build();

            ScenarioContext.Current["RIN"] = rin;
        }
        
        [Then(@"R2 Data Loader structure will have this Resource information")]
        public void ThenRDataLoaderStructureWillHaveThisResourceInformation(Table table)
        {
            var actualDataLoaderMessage =  (string)ScenarioContext.Current["DataLoaderMessage"];

            var extendedTable = new TableExtender<DataLoaderResourceProperties>().Extend(table);

            var actualResourceProperties =
                GetRelevantResourcePropertiesFromDataLoaderMessage(actualDataLoaderMessage, table.Header);

            extendedTable.CompareToSet(actualResourceProperties);
        }

        private List<DataLoaderResourceProperties> GetRelevantResourcePropertiesFromDataLoaderMessage(string actualDataLoaderMessage, ICollection<string> relevantProperties)
        {
            var dataLoaderResourcePropertyList = new List<DataLoaderResourceProperties>();

            foreach (
                var resource in
                    actualDataLoaderMessage)

            {
                if (HasDataInRelevantTextColumns(resource.ToString(), relevantProperties))
                {
                    var dataLoaderResourceProperties = new DataLoaderResourceProperties ();

                    if (relevantProperties.Contains("Title"))
                    {
                        dataLoaderResourceProperties.Title = "";
                    }

                    dataLoaderResourcePropertyList.Add(dataLoaderResourceProperties);
                }
            }

            return dataLoaderResourcePropertyList;
        }

        private bool HasDataInRelevantTextColumns(string resource, ICollection<string> relevantProperties)
        {
            if (relevantProperties.Contains("Title") )
                return true;

            return false;
        }
    }

    public class DataLoaderResourceProperties
    {
        public string Title { get; set; }
    }
}
