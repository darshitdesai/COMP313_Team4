using Acr.UserDialogs;
using CabBook.Helpers;
using CabBook.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CabBook.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CarDeatilsViewModel : IViewModel
    {

        public string Id { get; set; }
        public string CarName { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseType { get; set; }
        public string CarNumer { get; set; }
        public bool BabySeat { get; set; }
        public string UserId { get; set; }
        public bool NotCar { get; set; }

        public ICommand CarDetailsCommand
        {
            get
            {
                return new Command(() => {
                    ViewSaveCarDetails();
                });
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() => {
                    App.Logout();
                });
            }
        }

        async void ViewSaveCarDetails()
        {
            //check if car


            using (UserDialogs.Instance.Loading(Constants.TITLE_AUTHENTICATING))
            {
                var driverHomePage = new DriverHomePage();
                var driverHomeViewModel = new DriverHomeViewModel();

                CarDetails cd = new CarDetails();


                cd.Id = Id;
                cd.CarName = CarName;
                cd.LicenseNumber = LicenseNumber;
                cd.LicenseType = LicenseType;
                cd.CarNumer = CarNumer;
                cd.BabySeat = BabySeat;
                cd.UserId = Settings.UserId;


                var result = DriverService.AddCarDetail(cd);

                driverHomePage.BindingContext = driverHomeViewModel;
                await App._NavPage.Navigation.PushAsync(driverHomePage);
            }
        }
    }
}
