/*Author: Savan Patel
Date: March 1, 2018
Purpose: Custom controls for Form border and Image Source */

using System;
using Xamarin.Forms;

namespace CabBook.CustomControls
{
	public class CustomEntry : Entry
	{
		Color BorderColor{ get; set;}
		ImageSource IconImage{ get; set;}
		int CornerRadius{ get; set;}
		int BorderSize{ get; set;}

		public CustomEntry (){
			
		}
	}
}

