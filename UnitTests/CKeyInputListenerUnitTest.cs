using ScreenshotServiceApp.Controller;
using ScreenshotServiceApp.Model.Input;
using ScreenshotServiceApp.Model.Input.KeyInput;
using System.Windows.Forms;
using Xunit;

namespace UnitTests
{
    public class CKeyInputListenerUnitTest
    {
        [Fact]
        public void TestKeyListenerInitialization()
        {
            CKeyInputListener.Initialize(null);
            Assert.True(true);// TODO: a bit confused how to test that the listener reacts to events. Need to simulate events, not sure if it is a good idea.
        }
    }
}