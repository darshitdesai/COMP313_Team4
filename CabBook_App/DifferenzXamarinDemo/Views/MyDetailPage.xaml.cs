using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace CabBook
{
    /// <summary>
    /// MyDetailBase
    /// </summary>
	public class MyDetailBase :  ViewPage<MyDetailViewModel> {}

    /// <summary>
    /// LoginPage - Wraps MyDetailBase
    /// </summary>
	public partial class MyDetailPage : MyDetailBase
	{
		public MyDetailPage ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
		}

		protected async override void OnLoaded()
		{
			base.OnLoaded();

            //Animates the layout in screen
			await Task.Delay(300);
			await MainStackLayout.ScaleTo(1, 250, Easing.SinIn);
		}

	}
}

