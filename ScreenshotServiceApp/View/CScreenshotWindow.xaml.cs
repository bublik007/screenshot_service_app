using System.Windows;
using System.Windows.Media.Imaging;

namespace ScreenshotServiceApp.View
{
    /// <summary>
    /// Interaction logic for CScreenshotWindow.xaml
    /// </summary>
    public partial class CScreenshotWindow : Window
    {
        public CScreenshotWindow()
        {
            InitializeComponent();
        }
        //set snapshot URI dynamically

        public BitmapSource SnapshotBitmap 
        { 
            set
            {
                // Create source.
                /*BitmapImage bi = new BitmapImage();
                // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.UriSource = new Uri(value, UriKind.RelativeOrAbsolute);
                bi.EndInit();*/

                this._screenshotImage.Source = value;
            }
        }
    }
}