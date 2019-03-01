using System.Collections;
using System.Collections.Generic;
using ScreenshotServiceApp.Model.Input;
using ScreenshotServiceApp.View;

namespace ScreenshotServiceApp.ViewModel
{
    public delegate void OnActivity(string message);
    
    // central class of the application 
    public class CScreenshotServiceController
    {
        public static OnActivity ShowActivityMessage;
        // array list of all the taken screenshots
        public static ArrayList _latestWorkstationSnapshot = null;

        private List<CAbstractInputListener> _userInputListeners
                                        = new List<CAbstractInputListener>();
        public CScreenshotServiceController()
        {
            CAbstractInputListener _userInputListener = CKeyInputListener.Initialize(ProcessUserActivityRequest);
            _userInputListeners.Add(_userInputListener);
        }

        internal void UnsubscribeFromInputProviders()
        {
            foreach(CAbstractInputListener l in _userInputListeners)
                l.DisableListener();
        }

        //called by CKeyInputListener
        public void ProcessUserActivityRequest(ACTION_TYPE activityType)
        {
            switch(activityType)
            {
                case ACTION_TYPE.TAKE_SNAPSHOT:
                    _latestWorkstationSnapshot = Model.CScreenshotServiceController.TakeScreenshotOfAllScreens();
                    ShowActivityMessage?.Invoke("snapshot +1");
                    break;
                case ACTION_TYPE.SHOW_SNAPSHOT:
                    if (_latestWorkstationSnapshot != null)
                        CViewController.ShowSnapshots(_latestWorkstationSnapshot);
                    break;
                case ACTION_TYPE.CLOSE_SNAPSHOT:
                    CViewController.CloseSnapshots();
                    break;
            }
        }
    }
}