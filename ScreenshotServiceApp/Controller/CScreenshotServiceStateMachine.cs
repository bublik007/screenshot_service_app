namespace ScreenshotServiceApp.Controller
{
    class CScreenshotServiceStateMachine
    {
        private static CScreenshotServiceStateMachine _instance;
        public static CScreenshotServiceStateMachine GetInstance()
        {
            return _instance ?? (_instance = new CScreenshotServiceStateMachine());
        }

        private bool _isSnapshotMode = false;
        public bool IsSnaphotMode { get { return _isSnapshotMode; } set { _isSnapshotMode = value; } }
    }
}
