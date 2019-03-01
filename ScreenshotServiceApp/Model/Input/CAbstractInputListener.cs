namespace ScreenshotServiceApp.Model.Input
{
    internal delegate void UserActivityRequest(ACTION_TYPE activityType);
    internal enum ACTION_TYPE { TAKE_SNAPSHOT, SHOW_SNAPSHOT, CLOSE_SNAPSHOT, NONE }
    
    abstract class CAbstractInputListener
    {
        // delegates for subscribing to listener events
        internal UserActivityRequest OnUserActivityRequest;

        internal abstract void EnableListener();
        internal abstract void DisableListener();
    }
}