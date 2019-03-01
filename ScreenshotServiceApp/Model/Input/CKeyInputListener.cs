using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenshotServiceApp.Model.Input
{
    class CKeyInputListener : CAbstractInputListener
    {
        // see for more info the following example>>> http://rsdn.ru/forum/info/FAQ.dotnet.hooks
        // and the following explanations about hooks>>> https://docs.microsoft.com/en-us/windows/desktop/winmsg/about-hooks
        private const int WH_KEYBOARD_LL = 13,//The WH_KEYBOARD_LL hook enables you to monitor keyboard input events about to be posted in a thread input queue.
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101;

        private static IntPtr _hookID = IntPtr.Zero;

        private LowLevelKeyboardProc _proc = HookCallback;

        private static CKeyInputListener _instance = null;

        private CKeyInputListener(){}

        internal static CKeyInputListener GetInstance()
        {
            return (_instance == null) ? _instance = new CKeyInputListener() : _instance;
        }

        internal override void EnableListener()
        {
            if (_hookID == IntPtr.Zero)
            {
                _hookID = SetHook(_proc);
                if (_hookID == IntPtr.Zero)
                {
                    MessageBox.Show("SetWindowsHookEx Failed");
                    return;
                }
            }
        }
        internal override void DisableListener()
        {
            UnhookWindowsHookEx(_hookID);
            _hookID = IntPtr.Zero;
        }

        #region declaring hook 

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static bool _isSnapshotMode = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam">Sets the message ID of the keyboard. 
        ///                      This parameter can be one of the following messages: WM_KEYDOWN, WM_KEYUP, 
        ///                      WM_SYSKEYDOWN or WM_SYSKEYUP</param>
        /// <param name="lParam">Code of the pressed key</param>
        /// <returns></returns>
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (!(nCode >= 0))
                return CallNextHookEx(_hookID, nCode, wParam, lParam);

            if (wParam == (IntPtr)WM_KEYDOWN)// when the key is pushed down
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys pressedKey = (Keys)vkCode;
                switch (pressedKey)
                {
                    case Keys.PrintScreen:
                        {
                            Console.WriteLine("{0} blocked!", (Keys)vkCode);
                            //start a separate thread to 
                            if (_instance.OnUserActivityRequest != null)
                                _instance.OnUserActivityRequest.BeginInvoke(USER_ACTIVITY_TYPE.TAKE_SNAPSHOT, null, null);// async mode
                            Console.WriteLine("returning from hook!");
                            return (IntPtr)1;// we are blocking further processing of the Printscreen. Is it actually good ? Probably not
                        }
                    case Keys.Down:
                        _isSnapshotMode = true;
                        break;
                    // show snapshot
                    case Keys.Left: // the key is left arrow
                    case Keys.Right: // the key is right arrow
                        if (_isSnapshotMode)
                        {
                            if (_instance.OnUserActivityRequest != null)
                                _instance.OnUserActivityRequest.BeginInvoke(USER_ACTIVITY_TYPE.SHOW_SNAPSHOT, null, null);
                            return (IntPtr)1;// we are blocking further processing of the Printscreen. Is it actually good ? Probably not
                        }
                        break;
                }
            }
            else if (wParam == (IntPtr)WM_KEYUP)// when a key is released
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (((Keys)vkCode == Keys.Down))// if the key is down arrow
                {
                    _isSnapshotMode = false;
                    if (_instance.OnUserActivityRequest != null)
                        _instance.OnUserActivityRequest.BeginInvoke(USER_ACTIVITY_TYPE.CLOSE_SNAPSHOT, null, null);
                    return (IntPtr)1;// we are blocking further processing of the key up event
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        /**
        * idHook - the id of the event we want to intercept 
        * lpfn - Handle to DLL which contains the function which will react to the hook. Can be null only if dwThreadId is not 0.
         * hMod - function itself
         * dwThreadId - current thread(if events should be sent ins cope of this thread) or 0. If 0 --> global subscription to the events.
        */
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion
    }
}