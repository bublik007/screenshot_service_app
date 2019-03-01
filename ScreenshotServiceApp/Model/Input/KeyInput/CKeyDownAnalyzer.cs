using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotServiceApp.Model.Input.KeyInput
{
    class CKeyDownAnalyzer : IKeyEventAnalyzer
    {
        public ACTION_TYPE AnalyzeKeyEvent(Keys pressedKey)
        {
            switch (pressedKey)
            {
                case Keys.PrintScreen:
                    {
                        /*Console.WriteLine("{0} blocked!", (Keys)vkCode);
                        //start a separate thread to 
                        if (_instance.OnUserActivityRequest != null)
                            _instance.OnUserActivityRequest.BeginInvoke(, null, null);// async mode
                        Console.WriteLine("returning from hook!");
                        return (IntPtr)1;// we are blocking further processing of the Printscreen. Is it actually good ? Probably not*/
                        return ACTION_TYPE.TAKE_SNAPSHOT;
                    }
                case Keys.Down:
                    //_isSnapshotMode = true;// TODO:: switch statemachine state
                    //break;
                    return ACTION_TYPE.NONE;
                // show snapshot
                case Keys.Left: // the key is left arrow
                case Keys.Right: // the key is right arrow
                    /*if (_isSnapshotMode)
                    {
                        if (_instance.OnUserActivityRequest != null)
                            _instance.OnUserActivityRequest.BeginInvoke(ACTION_TYPE.SHOW_SNAPSHOT, null, null);
                        return (IntPtr)1;// we are blocking further processing of the Printscreen. Is it actually good ? Probably not
                    }*/
                    //break;
                    // TODO:: check statemachine
                    return ACTION_TYPE.SHOW_SNAPSHOT;
                default:
                    return ACTION_TYPE.NONE;
            }
        }
    }
}
