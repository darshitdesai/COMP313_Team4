using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Acr.UserDialogs;
using System.Linq;
using System.Threading.Tasks;

namespace CabBook
{
    /// <summary>
    /// MyListPageBase
    /// </summary>
	public class MyListPageBase :  ViewPage<MyListViewModel> {}

    /// <summary>
    /// LoginPage - Wraps MyListPageBase
    /// </summary>
	public partial class MyListPage : MyListPageBase
	{
		public MyListPage ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			var vm = this.BindingContext as MyListViewModel;
			var itemsSource = vm.UserList;
			vm.UserList = App.Database.GetAll();
			MyList.ItemsSource = vm.UserList;
			
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

