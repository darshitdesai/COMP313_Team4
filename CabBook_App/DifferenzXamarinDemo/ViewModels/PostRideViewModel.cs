/*Author: Heli Thakkar, Darshit
Date: March 25, 2018
*/

using Acr.UserDialogs;
using CabBook.Helpers;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CabBook.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PostRideViewModel : IViewModel
    {

        public string FirstStreet { get; set; }
        public string SecondStreet { get; set; }
        public string StartTime { get; set; }
        public string Desination { get; set; }
        public string Landmark { get; set; }
        public bool Active { get; set; }

        public string SaveButtonText { get; set; } = Constants.TEXT_UPDATE;

        public string DeleteButtonText { get; set; } = Constants.TEXT_DELETE;

        public ICommand SaveCommand
        {
            get
            {
                return new Command(() => {
                    Save();
                });
            }
        }

        /// <summary>
        /// Saves user details to address book.
        /// </summary>
        async void Save()
        {
            if (!string.IsNullOrEmpty(FirstStreet) && !string.IsNullOrEmpty(SecondStreet) && !string.IsNullOrEmpty(StartTime))
            {
                using (UserDialogs.Instance.Loading(Constants.TITLE_SAVING))
                {
                    var ride = new RideInformation();
                    ride.Active = Active;
                    ride.Destination = Desination;
                    ride.FirstStreet = FirstStreet;
                    ride.Landmark = Landmark;
                    ride.SecondStret = SecondStreet;
                    ride.StartTime = StartTime;
                    ride.UserId = Settings.UserId;
                    var result = DriverService.PostRide(ride);
                };
                await App.Current.MainPage.DisplayAlert(Constants.TITLE_SUCCESS, Constants.MESSAGE_SUCCESS_DATA_UPDATED, Constants.TEXT_OK);
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Constants.TITLE_VALIDATION_ERROR, Constants.MESSAGE_ERROR_INSERT_ALL_DATA, Constants.TEXT_OK);
            }
        }

       
        public ICommand BackCommand
        {
            get
            {
                return new Command(() => {
                    Cancel();
                });
            }
        }

        async void Cancel()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
