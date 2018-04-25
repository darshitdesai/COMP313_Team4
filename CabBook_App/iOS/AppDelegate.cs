using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Auth;
using Foundation;
using UIKit;
using Acr.UserDialogs;

namespace CabBook.iOS
{
    /// <summary>
    /// AppDelegate - Entry point to Xamarin.Forms app when run on iOS
    /// </summary>
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
            #region PackageInitialization
            global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
            #endif
            #endregion

            Xamarin.Behaviors.Infrastructure.Init ();
            LoadApplication (new App ()); //Loads the actual xamarin.forms application

			return base.FinishedLaunching (app, options);
		}
	}
}

