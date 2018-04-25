
using System;
using System.Windows.Input;
using Xamarin.Forms;
using PropertyChanged;
using Acr.UserDialogs;
using System.Collections.Generic;
using Xamarin.Auth;
using CabBook.Helpers;
using System.Text.RegularExpressions;

namespace CabBook
{
    /// <summary>
    /// LoginViewModel - Contains attributes/methods used to deal with LoginPage
    /// </summary>
    [AddINotifyPropertyChangedInterface]
	public class LoginViewModel : IViewModel
	{
		public string Password { get; set; }

		public string Email { get; set; }

		public ICommand LoginCommand { get { return new Command (() => {
            LoginToken();
			}); } }

        /// <summary>
        /// Performs user login.
        /// </summary>
		private async void Login ()
		{
            if(string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
            {
                await UserDialogs.Instance.AlertAsync(Constants.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, Constants.TITLE_ERROR, Constants.TEXT_OK);
                return;
            }

            if (!(Regex.IsMatch(Email, Constants.EMAIL_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_INVALID_EMAIL, Constants.TEXT_OK);
                return;
            }

            LoginModel result = new LoginModel ();
            using (UserDialogs.Instance.Loading (Constants.TITLE_AUTHENTICATING)) {
				LoginModel LoginData = new LoginModel ();
				LoginData.Email = Email;
				LoginData.Password = Password;
				LoginData.DeviceOSType = "No Device";
				LoginData.DeviceToken = "";
				LoginData.DeviceUDID = "";
				result = await LoginService.Login (LoginData);
			};
			if (result != null) {
				if (result.Errors.Count > 0) {
                    await App.Current.MainPage.DisplayAlert (Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, Constants.TEXT_OK);
				} else {
                    using (UserDialogs.Instance.Loading(Constants.TITLE_LOADING))
                    {
                        App.AutoLogin();
                    }
				}
			} else {
                await App.Current.MainPage.DisplayAlert (Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, Constants.TEXT_OK);
			}
		}


        private async void LoginToken()
        {
            if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
            {
                await UserDialogs.Instance.AlertAsync(Constants.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, Constants.TITLE_ERROR, Constants.TEXT_OK);
                return;
            }

            if (!(Regex.IsMatch(Email, Constants.EMAIL_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_INVALID_EMAIL, Constants.TEXT_OK);
                return;
            }

            Token result = new Token();
            using (UserDialogs.Instance.Loading(Constants.TITLE_AUTHENTICATING))
            {
                LoginModel LoginData = new LoginModel();
                LoginData.Email = Email;
                LoginData.Password = Password;
                LoginData.DeviceOSType = "No Device";
                LoginData.DeviceToken = "";
                LoginData.DeviceUDID = "";
                result = await LoginService.LoginToken(LoginData);
            };
            if (result != null)
            {
                if (result.Errors.Count > 0)
                {
                    await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, Constants.TEXT_OK);
                }
                else
                {
                    using (UserDialogs.Instance.Loading(Constants.TITLE_LOADING))
                    {
                        Settings.AccessToken = result.AccessToken;
                        Settings.UserId = result.UserId;
                        Settings.UserRole = result.UserRole;
                        App.AutoLogin();
                    }
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, Constants.TEXT_OK);
            }
        }

    }
}

