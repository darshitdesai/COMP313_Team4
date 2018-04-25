using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;

namespace CabBook.Droid
{
    /// <summary>
    /// MainActivity - Entry point to Xamarin.Forms app when run on android
    /// </summary>
	[Activity (Label = "Cab Book", Icon = "@drawable/icon", Theme = "@style/Theme.AppTheme",ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            #region PackageInitialization
			Xamarin.Behaviors.Infrastructure.Init ();
			global::Xamarin.Forms.Forms.Init (this, bundle);
            #endregion

            ActionBar.SetIcon(Android.Resource.Color.Transparent);

            UserDialogs.Init(this);
			LoadApplication (new App ()); //Loads the actual xamarin.forms application
		}
	}
}

