using System.Windows.Forms;

namespace ScreenshotServiceApp.Model.Input.KeyInput
{
    interface IKeyEventAnalyzer
    {
        ACTION_TYPE AnalyzeKeyEvent(Keys pressedKey);
    }
}