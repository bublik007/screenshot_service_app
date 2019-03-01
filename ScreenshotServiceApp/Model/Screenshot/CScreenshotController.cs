using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ScreenshotServiceApp.Model
{
    class CScreenshotServiceController
    {
        private const int TIMESTAMP_RECTANGLE_WIDTH = 700, TIMESTAMP_RECTANGLE_HEIGHT = 50,
                            ACTIVE_SCREEN_HIGHLIGHT_STROKE_WIDTH = 20;
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
            AddTimestampRectangleOnScreenshot(screenshot);
            return screenshot;
        }

        private static void AddTimestampRectangleOnScreenshot(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            
            //creating reactangles
            Rectangle backgroundRect = new Rectangle((bmp.Width - TIMESTAMP_RECTANGLE_WIDTH) / 2, 
                                                    (bmp.Height - TIMESTAMP_RECTANGLE_HEIGHT) / 2, 
                                                    TIMESTAMP_RECTANGLE_WIDTH, TIMESTAMP_RECTANGLE_HEIGHT);
            RectangleF textLayoutRect = new RectangleF(backgroundRect.Left, backgroundRect.Top,
                                                   backgroundRect.Width, backgroundRect.Height);
            // filling and painting rectangle
            SolidBrush semitransparentLightGrayBrush 
                = new SolidBrush(Color.FromArgb(128, 128, 128, 128));// to fill rectangle
            g.FillRectangle(semitransparentLightGrayBrush, backgroundRect);
            g.DrawRectangle(new Pen(semitransparentLightGrayBrush), backgroundRect);

            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            g.DrawString(DateTime.Now.ToString(), 
                        new Font("Tahoma", 20), new SolidBrush(Color.FromArgb(128, 0, 0, 0)), 
                        textLayoutRect, format);

            g.Flush();
        }
    }
}