using ScreenshotServiceApp.Model.Screenshot;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ScreenshotServiceApp.Model
{
    class CPCScreenshot : IEnumerable
    {

        public CPCScreenshot()
        { }
        // 1. array of images/URLs from each screen of the computer
        private List<CScreenshot> _arrayOfScreenshots = new List<CScreenshot>();

        public CPCScreenshot AddScreenSnapshot(int screenNumber, Bitmap bm)
        {
            _arrayOfScreenshots.Add(new CScreenshot(screenNumber, bm));
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