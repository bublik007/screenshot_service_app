using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ScreenshotServiceApp.Model
{
    class CWorkstationSnapshot : IEnumerable
    {
        public class CScreenSnapshot 
        {
            public int ScreenNumber { get; set; }
            public Bitmap ScreenBitmap { get; set; }
        }

        public CWorkstationSnapshot()
        { }

        // 1. array of images/URLs from each screen of the computer
        private List<CScreenSnapshot> _arrayOfScreenshots = new List<CScreenSnapshot>();

        public CWorkstationSnapshot AddScreenSnapshot(int screenNumber, Bitmap bm)
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