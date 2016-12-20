using System.Collections.Generic;
using DDEX.FRIN10.MessagingClassLibrary.f_rin;

namespace UMG.MS.RIN.R2.Dataloader.FunctionalTests.TestRINBuilders
{
    public class TestRinBuilder
    {
        private List<SoundRecording> _soundRecordings;

        public TestRinBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _soundRecordings = new List<SoundRecording> { new TestSoundRecordingBuilder().Build()};
        }

        public object Build()
        {
            var rin = new RecordingInformationNotification {ResourceList = new ResourceList()};
            if (_soundRecordings != null)
            {
                foreach (var soundRecording in _soundRecordings)
                {
                    rin.ResourceList.SoundRecordings.Add(soundRecording);
                }
            }

            return rin;
        }
        public TestRinBuilder WithSoundRecordings(List<SoundRecording> soundRecordings)
        {
            _soundRecordings = soundRecordings;
            return this;
        }

    }
}