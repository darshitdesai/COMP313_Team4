using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Acr.UserDialogs;
using System.Linq;
using System.Threading.Tasks;
using CabBook.ViewModels;

namespace CabBook
{
    /// <summary>
    /// MyListPageBase
    /// </summary>
	public class DriverHomePageBase :  ViewPage<DriverHomeViewModel> {}

    /// <summary>
    /// LoginPage - Wraps MyListPageBase
    /// </summary>
	public partial class DriverHomePage : DriverHomePageBase
    {
		public DriverHomePage()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

		}


		protected override void OnAppearing()
		{
			base.OnAppearing ();
			var vm = this.BindingContext as MyListViewModel;
		}

		protected async override void OnLoaded()
		{
			base.OnLoaded();

            //Animates the layout in screen
			await Task.Delay(300);
			
		}
	}
}

