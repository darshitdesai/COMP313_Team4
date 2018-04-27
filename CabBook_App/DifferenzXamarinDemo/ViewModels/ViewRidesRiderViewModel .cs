/*Author: Heli Thakkar, Mittal
Date: March 17, 2018
*/

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
    public class ViewRidesRiderViewModel : IViewModel
    {


        public List<RideDetails> RideList { get; set; }


        public Command<RideDetails> SelectItem
        {
            get
            {
                return new Command<RideDetails>(s => {
                    ViewRideDetais(s);
                });
            }
        }

        async void ViewRideDetais(RideDetails r)
        {

            var rideDetailsPage = new RideDetailsPage();
            var rideDetailsViewModel = new RideDetailsViewModel();

            rideDetailsViewModel.ToEmail = r.UserDetails.Email;
            rideDetailsViewModel.FirstStreet = r.rideInfo.FirstStreet;
            rideDetailsViewModel.SecondStreet = r.rideInfo.SecondStret;
            rideDetailsViewModel.StartTime = r.rideInfo.StartTime;
            rideDetailsViewModel.Desination = r.rideInfo.Destination;
            rideDetailsViewModel.Landmark = r.rideInfo.Landmark;



            rideDetailsPage.BindingContext = rideDetailsViewModel;
            await App._NavPage.Navigation.PushAsync(rideDetailsPage);

            
        }
    }
}
