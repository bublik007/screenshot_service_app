using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScreenshotServiceApp.Model.Screenshot
{
    public class CScreenshot
    {
        public const int TIMESTAMP_RECTANGLE_WIDTH = 700, TIMESTAMP_RECTANGLE_HEIGHT = 50,
                    ACTIVE_SCREEN_HIGHLIGHT_STROKE_WIDTH = 20;

        public int ScreenNumber { get; }
        public Bitmap ScreenBitmap { get; }

        public CScreenshot(int ScreenNumber, Bitmap ScreenBitmap)
        {
            this.ScreenNumber = ScreenNumber;
            this.ScreenBitmap = ScreenBitmap;

            AddTimestampRectangleOnScreenshot();
        }

        private void AddTimestampRectangleOnScreenshot()
        {
            Graphics g = Graphics.FromImage(ScreenBitmap);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            //creating reactangles
            Rectangle backgroundRect = new Rectangle((ScreenBitmap.Width - TIMESTAMP_RECTANGLE_WIDTH) / 2,
                                                    (ScreenBitmap.Height - TIMESTAMP_RECTANGLE_HEIGHT) / 2,
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