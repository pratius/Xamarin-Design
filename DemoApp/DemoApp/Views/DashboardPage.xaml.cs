﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Helpers;
using DemoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new DashboardViewModel();
            Animation();
			scrollView.Scale = 0;
            grvCamera.IsVisible = false;
        }

        protected async override void OnAppearing()
        {
            await Task.Delay(App.DelaySpeed);

			await scrollView.ScaleTo(1, App.AnimationSpeed, Easing.SinIn);
            base.OnAppearing();
        }

        private async void Animation()
        {
            scrollView.Opacity = 0;
            await scrollView.FadeTo(1, 2000);
           // await buttonStack.ScaleTo(1, 250, Easing.SinIn);
        }

        async void Handle_Scrolled(object sender, Xamarin.Forms.ScrolledEventArgs e)
		{
            await this.ColorTo(Color.FromRgb(255,255, 255), Color.FromRgb(226, 71, 71), c => BackgroundColor = c, 5000);
            grvCamera.IsVisible = true;
		}

	   async void Handle_Tapped(object sender , System.EventArgs e)
		{
           await Navigation.PushAsync(new ReportPage());
		}

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
          await Navigation.PushAsync(new Money());
        }
    }
}
