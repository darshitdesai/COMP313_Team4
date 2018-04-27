using System;
using Xamarin.Forms;

namespace CabBook
{
    /// <summary>
    /// FacebookLoginPage
    /// </summary>
	public class FacebookLoginPage : ContentPage
	{
		public FacebookLoginPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = Constants.TITLE_PLEASE_WAIT }
				},
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
		}
	}
}


