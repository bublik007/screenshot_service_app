using ScreenshotServiceApp.Controller;
using System.Windows.Forms;

namespace ScreenshotServiceApp.Model.Input.KeyInput
{
    public class CKeyDownAnalyzer : IKeyEventAnalyzer
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
                        return (CScreenshotServiceStateMachine.GetInstance().IsSnaphotMode) ? ACTION_TYPE.SHOW_SNAPSHOT : ACTION_TYPE.NONE;
                default:
                    return ACTION_TYPE.NONE;
            }
        }
    }
}
