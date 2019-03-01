using System;
using System.Windows;
using ScreenshotServiceApp.View;
using ScreenshotServiceApp.ViewModel;

namespace ScreenshotServiceApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        CScreenshotServiceController model = new CScreenshotServiceController();

        static void InitializeSubscriptionToEvents()
        {
            CScreenshotServiceController.ShowSnapshot += CViewController.ShowSnapshots;
            CScreenshotServiceController.CloseSnapshot += CViewController.CloseSnapshots;
            CScreenshotServiceController.ShowActivityMessage += CSystemTrayIcon.ShowNotification;
        }
        App()
        {
            InitializeComponent();
            CSystemTrayIcon.CreateSystemTrayIcon();
            CSystemTrayIcon.onExitDelegate += ExitApp;
            InitializeSubscriptionToEvents();
            this.Exit += App_Exit;
        }
        public static void ExitApp()
        {
            CSystemTrayIcon.RemoveTrayIcon();
            Current.Shutdown();
        }
        void App_Exit(object sender, ExitEventArgs e)
        {
            // release all the resources kept by the APP:
            model.UnsubscribeFromInputProviders();// FIXME:: how to do it better?
        }

        [STAThread]
        static void Main()
        {
            App app = new App();
            app.Run();
        }
    }
}