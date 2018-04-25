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
    public class RideDetailsViewModel : IViewModel
    {


        public List<RideDetails> RideList { get; set; }
      

        public ICommand SendEmailCommand
        {
            get
            {

                var rd = new RideDetails();

                rd.Id = Id;
                rd.ToEmail = ToEmail;
                rd.RiderEmail = RiderEmail;
                rd.RiderName = RiderName;
                rd.PhoneNumber = PhoneNumber;

                rd.UserId = Settings.UserId;

                return new Command(() => {
                    SendEmail(rd);
                });
            }
        }

        public string Id { get; set; }
        public string ToEmail { get; set; }
        public string RiderEmail { get; set; }
        public string RiderName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }


        public string FirstStreet { get; set; }
        public string SecondStreet { get; set; }
        public string StartTime { get; set; }
        public string Desination { get; set; }
        public string Landmark { get; set; }
        public bool Active { get; set; }

        async void SendEmail(RideDetails r)
        {
            //check if car

            var riderHompage = new RiderHomePage();
            var riderHomeViewModel = new RiderHomeViewModel();
            using (UserDialogs.Instance.Loading(Constants.TITLE_AUTHENTICATING))
            {
                var result = await RiderService.SendEmail(r);
            }
            riderHompage.BindingContext = riderHomeViewModel;
            await App._NavPage.Navigation.PushAsync(riderHompage);

            //string result = null;
            //await result = "success";
        }
    }
}
