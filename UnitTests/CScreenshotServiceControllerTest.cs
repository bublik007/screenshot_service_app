using Xunit;
using ScreenshotServiceApp.Controller;

namespace UnitTests
{
    public class CScreenshotServiceControllerTest
    {
        [Fact]
        public void TestIsSnapshotMode()
        {
            CScreenshotServiceStateMachine sm = new CScreenshotServiceStateMachine();
            sm.IsSnaphotMode = true;
            Assert.True(sm.IsSnaphotMode);
        }

        [Fact]
        public void TestIsSnapshotModeInInitialization()
        {
            CScreenshotServiceStateMachine sm = new CScreenshotServiceStateMachine();
            Assert.False(sm.IsSnaphotMode);
        }
    }
}