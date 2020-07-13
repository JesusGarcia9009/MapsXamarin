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
    public partial class ModalFilter : ContentPage
    {
        private Establecimiento SelectedEstablecimiento { get; set; }

        private Producto SelectedProducto { get; set; }

        public Establecimiento[] Establecimientos { get; set; }
        public Producto[] Productos { get; set; }

        public ModalFilter(FiltersViewModel listados)
        {
            InitializeComponent();
            this.Productos = listados.Productos;
            this.Establecimientos = listados.Establecimientos;

            prod.ItemsSource = Productos;
            esta.ItemsSource = Establecimientos;

        }

        private async void Acept_Clicked(object sender, EventArgs e)
        {
            string nombreProducto = ""; int idProducto = -1;
            string nombreEstablecimiento = ""; int idEstablecimiento = -1;
            if (prod.SelectedIndex != -1)
            {
                idProducto = ((Producto)prod.ItemsSource[prod.SelectedIndex]).idProducto;
                nombreProducto = ((Producto)prod.ItemsSource[prod.SelectedIndex]).nombreProducto.ToString();
            }
            if (esta.SelectedIndex != -1)
            {
                idEstablecimiento = ((Establecimiento)esta.ItemsSource[esta.SelectedIndex]).idEstablecimiento;
                nombreEstablecimiento = ((Establecimiento)esta.ItemsSource[esta.SelectedIndex]).nombreEstablecimiento.ToString();
            }
            await Navigation.PushModalAsync(new MainPage(nombreEstablecimiento, nombreProducto));

        }


    }
}