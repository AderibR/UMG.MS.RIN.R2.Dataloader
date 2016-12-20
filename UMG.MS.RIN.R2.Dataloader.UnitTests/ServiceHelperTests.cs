using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace UMG.MS.RIN.R2.Dataloader.UnitTests
{
    [TestFixture]
    public class ServiceHelperTests
    {
        [Test]
        public async Task OnStart_AlwaysCallsReleaseStatusChangeQueueConsumer()
        {
            _mockRinQueueConsumer.Setup(x => x.Receive())
                .Returns((EnterpriseRequest)null);

            await ExecuteService();

            _mockReleaseStatusChangeQueueConsumer.Verify(x => x.Receive(), Times.AtLeastOnce);
        }

    }
}
