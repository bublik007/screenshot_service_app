using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ScreenshotServiceApp.Model
{
    class CScreenshotServiceController
    {
        public static CPCScreenshot TakeScreenshotOfAllScreens()
        {
            CPCScreenshot workstationSnapshot = new CPCScreenshot();
            // getting all the screens presented at this workstation
            Screen[] Scrns = Screen.AllScreens;
            for (int i = 0; i < Scrns.Length; i++)
            {
                Screen screen = Scrns[i];
                Bitmap bm = TakeScreenshot(screen);
                workstationSnapshot.AddScreenSnapshot(i, bm);
            }
            Console.WriteLine(">>>>> done taking a screenshot");
            return workstationSnapshot;
        }

        /// <summary>
        /// Function takes a screenshot from the screen passed in parameters. 
        /// If the screen contains mouse coordinates,
        /// the screen is considered to be active and will be highlighted with a bright frame,
        /// also the mouse pointer will be highlighted with a bright background.
        /// </summary>
        /// <param name="screen"></param>
        private static Bitmap TakeScreenshot(Screen screen)
        {
            Bitmap screenshot = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
            Graphics G = Graphics.FromImage(screenshot);
            G.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y,
                              0, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);
            G.Dispose();
            return screenshot;
        }
    }
}