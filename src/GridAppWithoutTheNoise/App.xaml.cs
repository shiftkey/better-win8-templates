using System;
using GridAppWithoutTheNoise.Common;
using GridAppWithoutTheNoise.Modules.Home;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GridAppWithoutTheNoise
{
    sealed partial class App
    {
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            // Do not repeat app initialization when already running, just ensure that the window is active
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                Window.Current.Activate();
                return;
            }

            // Create a Frame to act as the navigation context and associate it with a SuspensionManager key
            var rootFrame = new Frame();
            SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                await SuspensionManager.RestoreAsync();
            }

            if (rootFrame.Content == null)
            {
                if (!rootFrame.Navigate(typeof(HomeView), "AllGroups"))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        private static async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }
    }
}
