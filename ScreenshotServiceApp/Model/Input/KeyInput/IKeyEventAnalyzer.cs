using System.Windows.Forms;

namespace ScreenshotServiceApp.Model.Input.KeyInput
{
    public interface IKeyEventAnalyzer
    {
        ACTION_TYPE AnalyzeKeyEvent(Keys pressedKey);
    }
}