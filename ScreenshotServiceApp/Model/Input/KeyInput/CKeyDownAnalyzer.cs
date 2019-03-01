using ScreenshotServiceApp.Controller;
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
                    return ACTION_TYPE.TAKE_SNAPSHOT;
                case Keys.Down:
                    CScreenshotServiceStateMachine.GetInstance().IsSnaphotMode = true;
                    return ACTION_TYPE.NONE;
                case Keys.Left: // the key is left arrow
                case Keys.Right: // the key is right arrow
                    if(CScreenshotServiceStateMachine.GetInstance().IsSnaphotMode)
                        return ACTION_TYPE.SHOW_SNAPSHOT;
                    else return ACTION_TYPE.NONE;
                default:
                    return ACTION_TYPE.NONE;
            }
        }
    }
}
