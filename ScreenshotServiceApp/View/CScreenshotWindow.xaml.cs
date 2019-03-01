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

        public BitmapSource SnapshotBitmap 
        { 
            set
            {
                this._screenshotImage.Source = value;
            }
        }
    }
}