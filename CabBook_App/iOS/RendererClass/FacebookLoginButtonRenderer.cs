using System;
using CabBook;
using Xamarin.Forms;
using CabBook.iOS;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Auth;
using UIKit;
using Newtonsoft.Json.Linq;


[assembly: ExportRenderer (typeof(FacebookLoginButton), typeof(FacebookLoginButtonRenderer))]
namespace CabBook.iOS
{
    /// <summary>
    /// FacebookLoginButtonRenderer - Custom renderer of type FacebookLoginButton
    /// </summary>
	public class FacebookLoginButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged (e);

			if (Control != null) { 
				var btn = (UIButton)Control;

                //Executes facebook authentication process
				btn.TouchUpInside += delegate {
					if (string.IsNullOrEmpty (App.Token)) {
						var rc = UIApplication.SharedApplication.KeyWindow.RootViewController;
					
						var auth = new OAuth2Authenticator (
                                      clientId: "129521717733836", // OAuth2 client id
							          scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
							          authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"), // the auth URL for the service
							          redirectUrl: new Uri ("http://www.facebook.com/connect/login_success.html")); // the redirect URL for the service

						auth.Completed += (sender, eventArgs) => {
							// We presented the UI, so it's up to us to dimiss it on iOS.
							if (eventArgs.IsAuthenticated) {
								App.SaveFBAccount (eventArgs.Account);
							} else {
								// The user cancelled
							}
							rc.DismissModalViewController (true);
						};

						rc.PresentViewController (auth.GetUI (), true, null);
					} else {
						App.GetFacebookLoginDetail ();
					}
				};
			}
		}
	}
}


