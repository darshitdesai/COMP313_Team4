using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Acr.UserDialogs;
using System.Linq;
using System.Threading.Tasks;
using CabBook.ViewModels;
using CabBook.Helpers;

namespace CabBook
{
    /// <summary>
    /// MyListPageBase
    /// </summary>
	public class ViewRidesRiderPageBase :  ViewPage<ViewRidesRiderViewModel> {}

    /// <summary>
    /// LoginPage - Wraps MyListPageBase
    /// </summary>
	public partial class ViewRidesRiderPage : ViewRidesRiderPageBase
    {
		public ViewRidesRiderPage()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			
		}

		protected async override void OnLoaded()
		{
			base.OnLoaded();

            //Animates the layout in screen
			await Task.Delay(300);
			await MyList.ScaleTo(1, 250, Easing.Linear);
		}
	}
}

