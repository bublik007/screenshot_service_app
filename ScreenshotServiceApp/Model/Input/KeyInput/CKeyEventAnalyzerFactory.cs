using System;

namespace ScreenshotServiceApp.Model.Input.KeyInput
{
    class CKeyEventAnalyzerFactory
    {
        private const int WH_KEYBOARD_LL = 13,//The WH_KEYBOARD_LL hook enables you to monitor keyboard input events about to be posted in a thread input queue.
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101;
        public static IKeyEventAnalyzer GetKeyEventAnalyzer(IntPtr wParam)
        {
            if (wParam == (IntPtr)WM_KEYDOWN)// when the key is pushed down
                return new CKeyDownAnalyzer();
            else if (wParam == (IntPtr)WM_KEYDOWN)
                return new CKeyReleasedAnalyzer();
            else return null;
        }
    }
}
