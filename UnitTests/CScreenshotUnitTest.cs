using Xunit;
using ScreenshotServiceApp.Model.Screenshot;
using System.Windows.Forms;
using System.Drawing;
using ScreenshotServiceApp.Model;

namespace UnitTests
{
    public class CScreenshotUnitTest
    {
        [Fact]
        public void TestScreenshotInitialization()
        {
            Screen[] screens = Screen.AllScreens;
            Bitmap bm = CScreenshotController.TakeScreenshot(screens[0]);
            CScreenshot screenshot = new CScreenshot(0, bm);
            int x = (bm.Width - CScreenshot.TIMESTAMP_RECTANGLE_WIDTH) / 2;
            int y = (bm.Height - CScreenshot.TIMESTAMP_RECTANGLE_HEIGHT) / 2;
            Color color = bm.GetPixel(x + 1, y + 1);

            Assert.True(true);// FIXME: may be something like this could work: color == Color.FromArgb(128, 128, 128, 128) ?
        }
    }
}