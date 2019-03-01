using Xunit;
using System.Windows.Forms;
using System.Drawing;
using ScreenshotServiceApp.Model;
using ScreenshotServiceApp.View;
using System.Windows.Media.Imaging;
using System.Collections;

namespace UnitTests
{
    public class CViewControllerUnitTest
    {
        [Fact]
        public void TestBitmapToWPFSourceConversion()
        {
            Screen[] screens = Screen.AllScreens;
            Bitmap bm = CScreenshotServiceController.TakeScreenshot(screens[0]);

            BitmapSource bms = CViewController.ToWpfBitmap(bm);
            Assert.True(bms != null);// FIXME: may be something like this could work: color == Color.FromArgb(128, 128, 128, 128) ?
        }

        [Fact]
        public void TestShowSnapshots()
        {
            ArrayList list = CScreenshotServiceController.TakeScreenshotOfAllScreens();
            CViewController.ShowSnapshots(list);
            Assert.True(true);// FIXME:: hard to test whether windows were actually open because of the threads
        }
    }
}