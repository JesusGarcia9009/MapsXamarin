using BurgersUIApp.ViewModels;
using GoogleMaps.Entities;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoogleMaps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailList : ContentPage
    {
        GoogleMaps.Entities.Filters _filter = new Entities.Filters();

        public DetailList(String tipoEstablecimiento, String tipoProducto)
        {
            InitializeComponent();
            //Title = "Ejemplo ListView 1";
            //banderaClick = true;
            BindingContext = new MenuDetailsViewModel();
        }


        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Burgers current = (e.CurrentSelection.FirstOrDefault() as Burgers);

            ModalDetailPlace page2 = new ModalDetailPlace(current.Name, current.Description);

            page2.Disappearing += OnDetailPlaceDisappearing;
            Navigation.PushAsync(page2);
        }

        private void OnDetailPlaceDisappearing(object sender, EventArgs eventArgs)
        {
            ((ModalDetailPlace)sender).Disappearing -= OnDetailPlaceDisappearing; //Unsubscribe from the event to allow the GC to collect the page and prevent memory leaks
        }

        private async void Search_Clicked(object sender, EventArgs e)
        {
            FiltersViewModel x = _filter.refreshData();
            ModalFilterListado page2 = new ModalFilterListado(x);

            page2.Disappearing += OnPage2Disappearing;
            await Navigation.PushAsync(page2);
        }

        private void OnPage2Disappearing(object sender, EventArgs eventArgs)
        {
            ((ModalFilterListado)sender).Disappearing -= OnPage2Disappearing; //Unsubscribe from the event to allow the GC to collect the page and prevent memory leaks
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
