namespace ScreenshotServiceApp.Model.Input
{
    internal delegate void UserActivityRequest(USER_ACTIVITY_TYPE activityType);
    internal enum USER_ACTIVITY_TYPE { TAKE_SNAPSHOT, SHOW_SNAPSHOT, CLOSE_SNAPSHOT }
    
    abstract class CAbstractInputListener
    {
        // delegates for subscribing to listener events
        internal UserActivityRequest OnUserActivityRequest;

        internal abstract void EnableListener();
        internal abstract void DisableListener();
    }
}