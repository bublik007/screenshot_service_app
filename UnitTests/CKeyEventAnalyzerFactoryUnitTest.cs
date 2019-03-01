using ScreenshotServiceApp.Controller;
using ScreenshotServiceApp.Model.Input;
using ScreenshotServiceApp.Model.Input.KeyInput;
using System;
using Xunit;

namespace UnitTests
{
    public class CKeyEventAnalyzerFactoryUnitTest
    {
        [Fact]
        public void TestGetKeyEventAnalyzer()
        {
            int WM_KEYDOWN = 0x0100, WM_KEYUP = 0x0101;
            IKeyEventAnalyzer analyzer = CKeyEventAnalyzerFactory.GetKeyEventAnalyzer((IntPtr)WM_KEYDOWN);
            Assert.True(analyzer is CKeyDownAnalyzer);
            analyzer = CKeyEventAnalyzerFactory.GetKeyEventAnalyzer((IntPtr)WM_KEYUP);
            Assert.True(analyzer is CKeyReleasedAnalyzer);
        }
    }
}