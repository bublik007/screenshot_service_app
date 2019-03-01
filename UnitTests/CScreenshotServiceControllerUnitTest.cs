using ScreenshotServiceApp.Model;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Xunit;

namespace UnitTests
{
    public class CScreenshotServiceControllerUnitTest
    {
        [Fact]
        public void TestTakeScreenshotOfAllScreens()
        {
            ArrayList screenshots = CScreenshotController.TakeScreenshotOfAllScreens();
            Assert.True(screenshots.Count>0);
        }

        [Fact]
        public void TestTakeScreenshot()
        {
            Screen[] screens = Screen.AllScreens;
            Bitmap screenshot = CScreenshotController.TakeScreenshot(screens[0]);
            Assert.False(screenshot.Size.IsEmpty); // This is indeed not a proper way to test whether the screenshot was actually taken. But better than nothing 
        }
    }
}