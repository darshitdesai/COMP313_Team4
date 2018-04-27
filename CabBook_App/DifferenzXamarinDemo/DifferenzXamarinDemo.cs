/* Author: Darshit Desai 
Date: March 1, 2018
purpose: User Login */


using System;

using Xamarin.Forms;
using Acr.UserDialogs;
using System.Threading.Tasks;
using System.Collections.Generic;
using CabBook.Helpers;
using CabBook.ViewModels;

namespace CabBook
{
	public class App : Application
	{
		static UserDatabase database;

        static RideInformationDatabase RideInformationDatabase;

        public static NavigationPage _NavPage;

        //Entry point to Xamarin.Forms app
		public App ()
		{
			var profilePage = new LoginPage ();

            _NavPage = new NavigationPage(profilePage);

			_NavPage.BarBackgroundColor = Color.Teal;
            _NavPage.BarTextColor = Color.White;

            MainPage = _NavPage;

            if (Settings.IsLoggedIn)
            {
                AutoLogin();
            }
		}

		public static UserDatabase Database {
			get { 
				if (database == null) {
					database = new UserDatabase ();
				}
				return database; 
			}
		}


		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		static string _Token;
		static Xamarin.Auth.Account _fbaccount;
		public static string Token {
			get { return _Token; }
		}

		public static Xamarin.Auth.Account FBAccount{
			get{ return _fbaccount;}
		}

		public static void SaveFBAccount(Xamarin.Auth.Account account)
		{
			_fbaccount = account;
			_Token = account.Properties["access_token"];
			GetFacebookLoginDetail ();
		}

		public async static void Logout()
		{
			_fbaccount = null;
			_Token = null;

            Settings.AccessToken = null;

            using (UserDialogs.Instance.Loading(Constants.TITLE_LOGOUT))
            {
                Settings.IsLoggedIn = false;
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
		}

        /// <summary>
        /// Gets the facebook login detail.
        /// </summary>
		public static async void GetFacebookLoginDetail (){
			await Task.Delay(2000);
			using (UserDialogs.Instance.Loading (Constants.TITLE_AUTHENTICATING)) {
				try{
					if (!string.IsNullOrEmpty (_Token)) {
                        AutoLogin();
				} else {
                        await App.Current.MainPage.DisplayAlert (Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_SESSION_EXPIRED, Constants.TEXT_CANCEL);
				}
				}
				catch(Exception exc) {
                    await App.Current.MainPage.DisplayAlert (Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_SOMETHING_WENT_WRONG, Constants.TEXT_CANCEL);
				}
			};
		}

        public static async void AutoLogin()
        {
           
            if (Settings.UserRole == "Driver")
            {
                var driverHomePage = new DriverHomePage();
                var driverHomeViewModel = new DriverHomeViewModel();
                Settings.IsLoggedIn = true;
                driverHomePage.BindingContext = driverHomeViewModel;
                using (UserDialogs.Instance.Loading(Constants.TITLE_AUTHENTICATING))
                {
                    await App._NavPage.Navigation.PushAsync(driverHomePage);
                }
            }
            else
            {
                var driverHomePage = new RiderHomePage();
                var driverHomeViewModel = new RiderHomeViewModel();
                Settings.IsLoggedIn = true;
                driverHomePage.BindingContext = driverHomeViewModel;
                using (UserDialogs.Instance.Loading(Constants.TITLE_AUTHENTICATING))
                {
                    await App._NavPage.Navigation.PushAsync(driverHomePage);
                }
            }
        }
	}
}

