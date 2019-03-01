using ScreenshotServiceApp.Controller;
using ScreenshotServiceApp.Model.Input;
using ScreenshotServiceApp.Model.Input.KeyInput;
using System.Windows.Forms;
using Xunit;

namespace UnitTests
{
    public class CKeyDownAnalyzerUnitTest
    {
        [Fact]
        public void TestPrintScreen()
        {
            ACTION_TYPE action = new CKeyDownAnalyzer().AnalyzeKeyEvent(Keys.PrintScreen);
            Assert.True(action == ACTION_TYPE.TAKE_SNAPSHOT);
        }

        [Fact]
        public void TestKeyDown()
        {
            ACTION_TYPE action = new CKeyDownAnalyzer().AnalyzeKeyEvent(Keys.Down);
            Assert.True(CScreenshotServiceStateMachine.GetInstance().IsSnaphotMode);
            Assert.True(action == ACTION_TYPE.NONE);
        }
        [Fact]
        public void TestKeyLeft()
        {
            CScreenshotServiceStateMachine.GetInstance().IsSnaphotMode = true;
            ACTION_TYPE action = new CKeyDownAnalyzer().AnalyzeKeyEvent(Keys.Left);
            Assert.True(action == ACTION_TYPE.SHOW_SNAPSHOT);
        }
    }
}