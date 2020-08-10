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

        public ModalDetailPlace(String Address, String Label)
        {
            InitializeComponent();
            address.Text = Address;
            label.Text = Label;

            place = this.ObtenerDetallesLugar(Label, Address);
            //carouselView.ItemsSource = place.menuList;
            carouselViewImg.ItemsSource = place.imagesPlace;

        }

        void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //carouselView.ScrollTo((int)Math.Floor(e.NewValue));
        }


        private PlaceDetail ObtenerDetallesLugar(String name, String direccion)
        {
            //aca deberia invocar un servicio para la busqueda del lugar
            //y el detalle
            PlaceDetail resultado = new PlaceDetail();
            resultado.PlaceName = name;
            resultado.Address = direccion;

            List<MenuPlace> listado = new List<MenuPlace>();
            List<imagePlace> imagenes = new List<imagePlace>();
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

                imagePlace temp1 = new imagePlace();
                temp1.Imagen = "https://www.espiamos.com/7909-home_default/botella-de-agua-espia-full-hd-con-deteccion-de-movimiento.jpg";
                temp1.Name = "Imagen " + f.ToString();
                imagenes.Add(temp1);
            }
            resultado.menuList = listado;
            resultado.imagesPlace = imagenes;

            return resultado;
        }

        
    }
}