using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using ScreenshotServiceApp.Model;

namespace ScreenshotServiceApp.View
{
    internal static class CViewController
    {
        private static List<CScreenshotWindow> _openSnapshots = new List<CScreenshotWindow>();
        private delegate void CDelegate(CWorkstationSnapshot snapshot);
        public static void ShowSnapshots(CWorkstationSnapshot snapshot)
        {
            var d = System.Windows.Application.Current.Dispatcher;
            if (!d.CheckAccess())
            {
                CDelegate handler = ShowSnapshots;
                d.Invoke(handler, new object[] { snapshot });
            }
            else
            {
                Screen[] AllSystemScreens = Screen.AllScreens;
                if (_openSnapshots.Count == 0)
                {// already insnapshot mode, no need to recreate windows
                    foreach (Screen s in AllSystemScreens)
                        _openSnapshots.Add(new CScreenshotWindow());
                }
                ShowWorkstationsSnaphots(snapshot, AllSystemScreens);// FIXME
            }
        }

        private static void ShowWorkstationsSnaphots(CWorkstationSnapshot snapshot,
            Screen[] AllSystemScreens)
        {
            foreach (CWorkstationSnapshot.CScreenSnapshot s in snapshot)
            {
                try
                {
                    CScreenshotWindow _screenshotWindow = _openSnapshots[s.ScreenNumber];
                    _screenshotWindow.SnapshotBitmap = ToWpfBitmap(s.ScreenBitmap);
                    ///show on correct screen of the system
                    ShowWindowOnParticularScreen(_screenshotWindow, AllSystemScreens[s.ScreenNumber]);
                    _screenshotWindow.Loaded += (object sender, RoutedEventArgs e)
                                                    => { _screenshotWindow.WindowState = WindowState.Maximized; };
                    //_openSnapshots.Add(_screenshotWindow);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Opening snapshot failed for some reason " + ex.ToString());
                }
            }
        }

        private static BitmapSource ToWpfBitmap(this Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);

                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }

        public static void CloseSnapshots()
        {
            var d = System.Windows.Application.Current.Dispatcher;
            if (!d.CheckAccess())
                d.Invoke(new Action(CloseSnapshots));
            else
            {
                foreach (CScreenshotWindow w in _openSnapshots)
                {
                    w.Hide();
                    w.SnapshotBitmap = null;
                    //w.Close();
                }
                _openSnapshots.Clear();
            }
        }

        private static void ShowWindowOnParticularScreen(Window fullScreenWindow, 
            Screen destinationScreen)
        {
            Rectangle workingArea = destinationScreen.Bounds;
            fullScreenWindow.Left = workingArea.Left;
            fullScreenWindow.Top = workingArea.Top;
            fullScreenWindow.Width = workingArea.Width;
            fullScreenWindow.Height = workingArea.Height;
            fullScreenWindow.WindowStyle = WindowStyle.None;
            //fullScreenWindow.Topmost = true;
            fullScreenWindow.Show();
        }
    }
}