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
    public partial class ModalDetailPlace : ContentPage
    {
        private DetailPlace DetailPlace { get; set; }

        public PlaceDetail place { get; set; }

        public ModalDetailPlace(Pin item)
        {
            InitializeComponent();

            address.Text = item.Address;
            label.Text = item.Label;

            place = this.ObtenerDetallesLugar(item.Label, item.Address);
            carouselView.ItemsSource = place.menuList;
        }

        void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            carouselView.ScrollTo((int)Math.Floor(e.NewValue));
        }


        private PlaceDetail ObtenerDetallesLugar(String name, String direccion)
        {
            //aca deberia invocar un servicio para la busqueda del lugar
            //y el detalle
            PlaceDetail resultado = new PlaceDetail();
            resultado.PlaceName = name;
            resultado.Address = direccion;

            List<MenuPlace> listado = new List<MenuPlace>();
            bool detenerse = false; float f = 3.2f;
            while (!detenerse) {
                MenuPlace temp = new MenuPlace();
                temp.Imagen = "https://www.espiamos.com/7909-home_default/botella-de-agua-espia-full-hd-con-deteccion-de-movimiento.jpg";
                temp.PrecioOriginal = f;
                temp.Name = "Cerveza " + f.ToString();

                if (f < 5) {
                    f += 0.5f;
                }
                else {
                    detenerse = true;
                }
                listado.Add(temp);
            }
            resultado.menuList = listado;

            return resultado;
        }

        // background brush
        SKPaint backgroundBrush = new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = Color.Red.ToSKColor()
        };


        private void BackgroundGradient_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
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