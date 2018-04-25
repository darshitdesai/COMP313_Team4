using Acr.UserDialogs;
using CabBook.Helpers;
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
    public class DriverHomeViewModel : IViewModel
    {

        public ICommand CarDetailsCommand
        {
            get
            {
                return new Command(() =>
                {
                    ViewSaveCarDetails();
                });
            }
        }

        public ICommand PostRideCommand
        {
            get
            {
                return new Command(() =>
                {
                    PostRide();
                });
            }
        }

        public ICommand ViewRideCommand
        {
            get
            {
                return new Command(() =>
                {
                    ViewRides();
                });
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Logout();
                });
            }
        }

        async void ViewSaveCarDetails()
        {
            //check if car

            var carDeatilsPage = new CarDeatilsPage();
            var carDeatilsViewModel = new CarDeatilsViewModel();

            carDeatilsPage.BindingContext = carDeatilsViewModel;


            using (UserDialogs.Instance.Loading(Constants.TITLE_LOADING))
            {
                var result = await DriverService.GetCarDetails(Settings.UserId);

                if (result != null)
                {
                    //car
                    carDeatilsViewModel.NotCar = false;
                    carDeatilsViewModel.BabySeat = result.BabySeat;
                    carDeatilsViewModel.CarName = result.CarName;
                    carDeatilsViewModel.CarNumer = result.CarNumer;
                    carDeatilsViewModel.LicenseNumber = result.LicenseNumber;
                    carDeatilsViewModel.LicenseType = result.LicenseType;
                    carDeatilsViewModel.UserId = result.UserId;

                }
                else
                {
                    carDeatilsViewModel.NotCar = true;
                }

                await App._NavPage.Navigation.PushAsync(carDeatilsPage);
            }

            //string result = null;
            //await result = "success";
        }

        async void PostRide()
        {
            //check if car

            var posRidePage = new PostRidePage();
            var postRideViewModel = new PostRideViewModel();

            posRidePage.BindingContext = postRideViewModel;
            using (UserDialogs.Instance.Loading(Constants.TITLE_LOADING))
            {
                await App._NavPage.Navigation.PushAsync(posRidePage);
            }

            //string result = null;
            //await result = "success";
        }

        async void ViewRides()
        {
            //check if car
            var posRidePage = new ViewRidesPage();
            var postRideViewModel = new ViewRidesDriverViewModel();
            using (UserDialogs.Instance.Loading(Constants.TITLE_LOADING))
            {
                var rides = await DriverService.GetAllRides(Settings.UserId);
                postRideViewModel.RideList = rides;
                posRidePage.BindingContext = postRideViewModel;
                await App._NavPage.Navigation.PushAsync(posRidePage);
            }
            

            //string result = null;
            //await result = "success";
        }

    }
}
