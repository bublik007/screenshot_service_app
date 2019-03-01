﻿using System.Collections.Generic;
using ScreenshotServiceApp.Model;
using ScreenshotServiceApp.Model.Input;

namespace ScreenshotServiceApp.ViewModel
{
    internal delegate void ShowSystemSnapshot(CWorkstationSnapshot snapshot);
    internal delegate void CloseSystemSnapshot();
    internal delegate void OnActivity(string message);
    
    // central class of the application 
    class CScreenshotServiceController
    {
        public static ShowSystemSnapshot ShowSnapshot;
        public static CloseSystemSnapshot CloseSnapshot;
        public static OnActivity ShowActivityMessage;
        // array list of all the taken screenshots
        private static CWorkstationSnapshot _latestWorkstationSnapshot = null;

        private List<CAbstractInputListener> _userInputListeners
                                        = new List<CAbstractInputListener>();
        internal CScreenshotServiceController()
        {
            CAbstractInputListener _userInputListener = CKeyInputListener.GetInstance();
            _userInputListener.EnableListener();
            _userInputListener.OnUserActivityRequest += ProcessUserActivityRequest;
            _userInputListeners.Add(_userInputListener);
        }

        internal void UnsubscribeFromInputProviders()
        {
            foreach(CAbstractInputListener l in _userInputListeners)
                l.DisableListener();
        }

        //called by CKeyInputListener
        private void ProcessUserActivityRequest(USER_ACTIVITY_TYPE activityType)
        {
            switch(activityType)
            {
                case USER_ACTIVITY_TYPE.TAKE_SNAPSHOT:
                    _latestWorkstationSnapshot = Model.CScreenshotServiceController.TakeScreenshotOfAllScreens();
                    ShowActivityMessage?.Invoke("snapshot +1");
                    break;
                case USER_ACTIVITY_TYPE.SHOW_SNAPSHOT:
                    if (_latestWorkstationSnapshot != null)
                        ShowSnapshot.Invoke(_latestWorkstationSnapshot);
                    break;
                case USER_ACTIVITY_TYPE.CLOSE_SNAPSHOT:
                    CloseSnapshot?.Invoke();
                    break;
            }
        }
    }
}