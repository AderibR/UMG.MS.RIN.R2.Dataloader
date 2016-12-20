using DDEX.FRIN10.MessagingClassLibrary.f_rin;

namespace UMG.MS.RIN.R2.Dataloader.FunctionalTests.TestRINBuilders
{
    public class TestSoundRecordingBuilder
    {
        private string _titleText;

        public TestSoundRecordingBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _titleText = "Title";
        }

        public SoundRecording Build()
        {
            var soundRecording = new SoundRecording {Titles = {new Title {TitleText = _titleText}}};

            return soundRecording;
        }

        public TestSoundRecordingBuilder WithTitleText(string titleText)
        {
            _titleText = titleText;
            return this;
        }

    }
}