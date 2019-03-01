using ScreenshotServiceApp.Controller;
using ScreenshotServiceApp.Model.Input;
using ScreenshotServiceApp.Model.Input.KeyInput;
using System.Windows.Forms;
using Xunit;

namespace UnitTests
{
    public class CKeyReleasedAnalyzerUnitTest
    {
        [Fact]
        public void TestOtherKeyReleased()
        {
            ACTION_TYPE action = new CKeyReleasedAnalyzer().AnalyzeKeyEvent(Keys.PrintScreen);
            Assert.True(action == ACTION_TYPE.NONE);
        }

        [Fact]
        public void TestKeyDownReleased()
        {
            CScreenshotServiceStateMachine.GetInstance().IsSnaphotMode = true;
            ACTION_TYPE action = new CKeyReleasedAnalyzer().AnalyzeKeyEvent(Keys.Down);
            Assert.False(CScreenshotServiceStateMachine.GetInstance().IsSnaphotMode);
            Assert.True(action == ACTION_TYPE.CLOSE_SNAPSHOT);
        }
    }
}