using System.Windows.Forms;

namespace ScreenshotServiceApp.Model.Input.KeyInput
{
    class CKeyReleasedAnalyzer : IKeyEventAnalyzer
    {
        public ACTION_TYPE AnalyzeKeyEvent(Keys pressedKey)
        {
            if (pressedKey == Keys.Down)// if the key is down arrow
                return ACTION_TYPE.CLOSE_SNAPSHOT;
                //_isSnapshotMode = false; FIXME:::
                /*if (_instance.OnUserActivityRequest != null)
                    _instance.OnUserActivityRequest.BeginInvoke(ACTION_TYPE.CLOSE_SNAPSHOT, null, null);
                return (IntPtr)1;// we are blocking further processing of the key up event*/
            else
                return ACTION_TYPE.NONE;
        }
    }
}