﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using SpeakDanish.iOS.Services;
using SpeakDanish.Services;
using Microsoft.Extensions.DependencyInjection;
using UIKit;

namespace SpeakDanish.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(AddServices));

            return base.FinishedLaunching(app, options);
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IAudioRecorder, AudioRecorder>();
            services.AddSingleton<ITtsDataInstaller, TtsDataInstaller>();
            services.AddSingleton<IAlertService, AlertService>();
        }

        public static UIViewController GetVisibleViewController()
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (rootController.PresentedViewController == null)
                return rootController;

            if (rootController.PresentedViewController is UINavigationController)
            {
                return ((UINavigationController)rootController.PresentedViewController).TopViewController;
            }

            if (rootController.PresentedViewController is UITabBarController)
            {
                return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;
            }

            return rootController.PresentedViewController;
        }
    }
}
