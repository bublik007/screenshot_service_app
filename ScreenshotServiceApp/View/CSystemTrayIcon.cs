using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenshotServiceApp.View
{
    class CSystemTrayIcon
    {
        private static readonly string ICON_TITLE = "Screenshot Service App";
        public delegate void OnExit();
        public static OnExit onExitDelegate;

        private static NotifyIcon ni;
        public static void CreateSystemTrayIcon()
        {
            // system tray logic 
            ni = new NotifyIcon
            {
                Icon = new Icon(SystemIcons.Information, 40, 40),
                Visible = true
            };

            ni.Text = ICON_TITLE;

            /// CREATING THE MENU /////
            ContextMenu contextMenu1 = new ContextMenu();

            MenuItem menuItem1
                = new MenuItem() { Index = 0, Text = "Exit" };

            menuItem1.Click += (object sender, EventArgs e) => 
            {
                onExitDelegate?.Invoke();
            };
            // Initialize contextMenu1 
            contextMenu1.MenuItems.AddRange(new MenuItem[] { menuItem1 });

            ni.ContextMenu = contextMenu1;
        }

        public static void RemoveTrayIcon()
        {
            ni.Visible = false;
        }

        public static void ShowNotification(String message)
        {
            ni.BalloonTipIcon = ToolTipIcon.Info;
            ni.BalloonTipTitle = ICON_TITLE;
            ni.BalloonTipText = message;

            ni.ShowBalloonTip(5000);
        }
    }
}
