using Android.Graphics;
using GoogleMaps.Entities;
using GoogleMaps.Services;
using Newtonsoft.Json;
using SkiaSharp;
using SkiaSharp.Views.Forms;
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
using Color = Xamarin.Forms.Color;

namespace GoogleMaps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalFilterListado : ContentPage
    {
        private Establecimiento SelectedEstablecimiento { get; set; }

        private Producto SelectedProducto { get; set; }

        public Establecimiento[] Establecimientos { get; set; }
        public Producto[] Productos { get; set; }

        public ModalFilterListado(FiltersViewModel listados)
        {
            InitializeComponent();
            this.Productos = listados.Productos;
            this.Establecimientos = listados.Establecimientos;

            producto.ItemsSource = Productos;
            establecimiento.ItemsSource = Establecimientos;

        }

        private async void Acept_Clicked(object sender, EventArgs e)
        {
            string nombreProducto = ""; int idProducto = -1;
            string nombreEstablecimiento = ""; int idEstablecimiento = -1;
            if (producto.SelectedIndex != -1)
            {
                idProducto = ((Producto)producto.ItemsSource[producto.SelectedIndex]).idProducto;
                nombreProducto = ((Producto)producto.ItemsSource[producto.SelectedIndex]).nombreProducto.ToString();
            }
            if (establecimiento.SelectedIndex != -1)
            {
                idEstablecimiento = ((Establecimiento)establecimiento.ItemsSource[establecimiento.SelectedIndex]).idEstablecimiento;
                nombreEstablecimiento = ((Establecimiento)establecimiento.ItemsSource[establecimiento.SelectedIndex]).nombreEstablecimiento.ToString();
            }
            await Navigation.PushModalAsync(new MainPage(nombreEstablecimiento, nombreProducto, false));

        }

        // background brush
        SKPaint backgroundBrush = new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = Color.Red.ToSKColor()
        };


        private void BackgroundGradient_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e) {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // get the brush based on the theme
            SKColor gradientStart = ((Color)Application.Current.Resources["BackgroundGradientStartColor"]).ToSKColor();
            SKColor gradientMid = ((Color)Application.Current.Resources["BackgroundGradientMidColor"]).ToSKColor();
            SKColor gradientEnd = ((Color)Application.Current.Resources["BackgroundGradientEndColor"]).ToSKColor();

            // gradient backround
            backgroundBrush.Shader = SKShader.CreateRadialGradient
                (new SKPoint(0, info.Height * .8f),
                info.Height * .8f,
                new SKColor[] { gradientStart, gradientMid, gradientEnd },
                new float[] { 0, .5f, 1 },
                SKShaderTileMode.Clamp);

            SKRect backgroundBounds = new SKRect(0, 0, info.Width, info.Height);
            canvas.DrawRect(backgroundBounds, backgroundBrush);
        }
    }
}