using ScreenshotServiceApp.Controller;
using System.Windows.Forms;

namespace ScreenshotServiceApp.Model.Input.KeyInput
{
    class CKeyReleasedAnalyzer : IKeyEventAnalyzer
    {
        public ACTION_TYPE AnalyzeKeyEvent(Keys pressedKey)
        {
            if (pressedKey == Keys.Down)// if the key is down arrow
            {
                CScreenshotServiceStateMachine.GetInstance().IsSnaphotMode = false;
                return ACTION_TYPE.CLOSE_SNAPSHOT;
            }
            else
                return ACTION_TYPE.NONE;
        }
    }
}