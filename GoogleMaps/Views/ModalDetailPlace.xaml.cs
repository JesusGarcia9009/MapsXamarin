using Android.Graphics;
using GoogleMaps.Entities;
using GoogleMaps.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace GoogleMaps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalDetailPlace : ContentPage
    {
        private DetailPlace DetailPlace { get; set; }
        
        public ModalDetailPlace(Pin item)
        {
            InitializeComponent();

            address.Text = item.Address;
            label.Text = item.Label;
        }

        

    }
}