/*Author: Anjali, Mittal
Date: March 29, 2018
*/

using System;
using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using Acr.UserDialogs;

namespace CabBook
{
    /// <summary>
    /// MyListViewModel - Contains attributes/methods used to deal with MyListPage
    /// </summary>
    [AddINotifyPropertyChangedInterface]
	public class MyListViewModel : IViewModel
	{
		public List<UserData> UserList{ get; set;}

		public Command<UserData> SelectItem  { get {
				return new Command<UserData> (s => {
                    ViewAddress(s);
				});
			}}

        /// <summary>
        /// Views user data from address book.
        /// </summary>
        /// <param name="s">S.</param>
        async void ViewAddress(UserData s)
        {
            var myDetailPage = new MyDetailPage();
            var myDetailViewModel = new MyDetailViewModel();
            using (UserDialogs.Instance.Loading(Constants.TITLE_LOADING))
            {
                myDetailViewModel.Name = s.Name;
                myDetailViewModel.ID = s.ID;
                myDetailViewModel.Active = s.Active;
                myDetailViewModel.ContactNumber = s.ContactNumber;
                myDetailViewModel.EmailAddress = s.EmailAddress;
            };

            myDetailPage.BindingContext = myDetailViewModel;
            await App.Current.MainPage.Navigation.PushAsync(myDetailPage);
        }

		public ICommand LogoutCommand  { get { return new Command (() => {
            App.Logout();
		}); } }


		public ICommand AddCommand  { get {
				return new Command (() => {
                    Add();
				});
			}}

        /// <summary>
        /// Navigates to MyDetailsPage to add new user data in address book.
        /// </summary>
        async void Add()
        {
            var myDetailPage = new MyDetailPage();
            var myDetailViewModel = new MyDetailViewModel();
            myDetailViewModel.ID = 0;
            myDetailViewModel.Active = false;
            myDetailPage.BindingContext = myDetailViewModel;
            await App.Current.MainPage.Navigation.PushAsync(myDetailPage);
        }
	}
}

