﻿using System;
using Microsoft.Extensions.DependencyInjection;
using SpeakDanish.ViewModels;
using SpeakDanish.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("materialdesignicons-webfont.ttf", Alias = "MaterialDesignIcons")]
namespace SpeakDanish
{
    public partial class App : Application
    {
        public App (Action<IServiceCollection> addPlatformServices = null)
        {
            InitializeComponent();

            AppContainer.SetupServices(addPlatformServices);

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.Blue,
                BarTextColor = Color.White,
            };

            MainPage.BindingContext = AppContainer.GetService<HomeViewModel>();
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

