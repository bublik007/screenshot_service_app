using Xunit;
using ScreenshotServiceApp.ViewModel;
using ScreenshotServiceApp.Model.Input;

namespace UnitTests
{
    public class CScreenshotServiceControllerTest
    {
        [Fact]
        public void TestTakeSnapshotActivityRequest()
        {
            new CScreenshotServiceController().ProcessUserActivityRequest(ACTION_TYPE.TAKE_SNAPSHOT);
            Assert.True(CScreenshotServiceController._latestWorkstationSnapshot != null);
        }
    }
}