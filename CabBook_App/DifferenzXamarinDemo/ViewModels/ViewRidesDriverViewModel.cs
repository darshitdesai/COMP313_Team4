using Acr.UserDialogs;
using CabBook.Helpers;
using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CabBook.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ViewRidesDriverViewModel : IViewModel
    {


        public List<RideInformation> RideList { get; set; }

        public ICommand CarDetailsCommand
        {
            get
            {
                return new Command(() => {
                    ViewSaveCarDetails();
                });
            }
        }

        public ICommand PostRideCommand
        {
            get
            {
                return new Command(() => {
                    PostRide();
                });
            }
        }

        public ICommand ViewRideCommand
        {
            get
            {
                return new Command(() => {
                    ViewRides();
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

            var carDeatilsPage = new CarDeatilsPage();
            var carDeatilsViewModel = new CarDeatilsViewModel();

            carDeatilsPage.BindingContext = carDeatilsViewModel;
            await App._NavPage.Navigation.PushAsync(carDeatilsPage);

            //string result = null;
            //await result = "success";
        }

        async void PostRide()
        {
            //check if car

            var posRidePage = new PostRidePage();
            var postRideViewModel = new PostRideViewModel();

            posRidePage.BindingContext = postRideViewModel;
            await App._NavPage.Navigation.PushAsync(posRidePage);

            //string result = null;
            //await result = "success";
        }

        async void ViewRides()
        {
            //check if car

            var posRidePage = new PostRidePage();
            var postRideViewModel = new PostRideViewModel();

            posRidePage.BindingContext = postRideViewModel;
            await App._NavPage.Navigation.PushAsync(posRidePage);

            //string result = null;
            //await result = "success";
        }

    }
}
