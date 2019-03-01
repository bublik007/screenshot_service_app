using System;

namespace ScreenshotServiceApp.Model.Input.KeyInput
{
    public class CKeyEventAnalyzerFactory
    {
        private const int WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101;
        public static IKeyEventAnalyzer GetKeyEventAnalyzer(IntPtr wParam)
        {
            if (wParam == (IntPtr)WM_KEYDOWN)// when the key is pushed down
                return new CKeyDownAnalyzer();
            else if (wParam == (IntPtr)WM_KEYUP)
                return new CKeyReleasedAnalyzer();
            else return null;
        }
    }
}
