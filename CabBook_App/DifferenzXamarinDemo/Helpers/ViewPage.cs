using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using Acr.UserDialogs;

namespace CabBook
{
	public interface IViewModel {}
	
    /// <summary>
    /// ViewPage - Binds pages with viewmodels
    /// </summary>
	public class ViewPage<T> : MainBaseContentPage where T:IViewModel, new()
	{
		readonly T _viewModel; 

		public T ViewModel
		{
			get {
				return _viewModel;
			}
		}

		public ViewPage ()
		{
			_viewModel = new T ();
			BindingContext = _viewModel;
		}
	}

    /// <summary>
    /// MainBaseContentPage - Wrapper for ContentPage
    /// </summary>
	public class MainBaseContentPage : ContentPage
	{
		
		public MainBaseContentPage()
		{
		}

		~MainBaseContentPage()
		{
		}


		public bool HasInitialized
		{
			get;
			private set;
		}

		protected virtual void OnLoaded()
		{
			
		}


		protected virtual void Initialize()
		{
		}

		protected override void OnAppearing()
		{
			if(!HasInitialized)
			{
				HasInitialized = true;
				OnLoaded();
			}

			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}



	}
}

