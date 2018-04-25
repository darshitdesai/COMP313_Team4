using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using CabBook.Helpers;
using CabBook.ViewModels;

namespace CabBook
{
    /// <summary>
    /// LoginPageBase
    /// </summary>
	public class CarDeatilsPageBase :  ViewPage<CarDeatilsViewModel> {}

    /// <summary>
    /// LoginPage - Wraps LoginPageBase
    /// </summary>
	public partial class CarDeatilsPage : CarDeatilsPageBase
    {
		public CarDeatilsPage()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

            Settings.IsLoggedIn = false;
		}

		protected async override void OnLoaded()
		{
			base.OnLoaded();

            //Animates the layout in screen
			await Task.Delay(300);
			await mainStackView.ScaleTo(1, 250, Easing.SinIn);
		}
	}
}

