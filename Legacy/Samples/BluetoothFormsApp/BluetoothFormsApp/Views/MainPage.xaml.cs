﻿using InTheHand.Devices.Enumeration;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BluetoothFormsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
        public MainPage()
        {
            InitializeComponent();

            

        }

        protected async override void OnAppearing()
        {
            
        }
    }
}