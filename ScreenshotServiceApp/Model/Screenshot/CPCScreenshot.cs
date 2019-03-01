using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ScreenshotServiceApp.Model
{
    class CPCScreenshot : IEnumerable
    {
        public class CScreenSnapshot 
        {
            public int ScreenNumber { get; set; }
            public Bitmap ScreenBitmap { get; set; }
        }

        public CPCScreenshot()
        { }

        // 1. array of images/URLs from each screen of the computer
        private List<CScreenSnapshot> _arrayOfScreenshots = new List<CScreenSnapshot>();

        public CPCScreenshot AddScreenSnapshot(int screenNumber, Bitmap bm)
        {
            _arrayOfScreenshots.Add(new CScreenSnapshot
            {
                ScreenNumber = screenNumber,
                ScreenBitmap = bm

            });
            return this;
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _arrayOfScreenshots.GetEnumerator();
        }

        #endregion
    }
}