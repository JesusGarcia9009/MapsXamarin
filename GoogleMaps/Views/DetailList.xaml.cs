using GoogleMaps.Entities;
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
        private static bool banderaClick;

        public DetailList()
        {
            InitializeComponent();
            Title = "Ejemplo ListView 1";
            banderaClick = true;
        }

        protected override async void OnAppearing()
        {
            LlenarMenu();
            await Task.Yield();
        }

        public async void LlenarMenu()
        {
            DetailList oEjemploListView1Model = new DetailList();
            listViewPlace.ItemsSource = null;
            listViewPlace.ItemsSource = oEjemploListView1Model.ObtenerListPlaces();
            
        }

        private async void OnClickOpcionSeleccionada(object sender, SelectedItemChangedEventArgs e)
        {
            if (banderaClick)
            {
                var item = e.SelectedItem as ListPlaces;
                if ((item != null) && (item.Habilitado))
                {
                    var oSeleccionado = item.idOpcion;
                    banderaClick = false;
                    switch (oSeleccionado)
                    {
                        case 1:
                            Navigation.PushAsync(new DetailList());
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    await Task.Run(async () =>
                    {
                        await Task.Delay(500);
                        banderaClick = true;
                    });

                }
            } // fin banderaCLick
        }// fin metodo OnClickOpcionSeleccionada



        private ObservableCollection<ListPlaces> ObtenerListPlaces()
        {

            ObservableCollection<ListPlaces> oMenuPrincipal = new ObservableCollection<ListPlaces>();

            oMenuPrincipal.Add(new ListPlaces
            {
                Opcion = "ListView Ejemplo 1",
                Habilitado = true,
                idOpcion = 1,
                icon = "http://lorempixel.com/100/100/people/1"
            });
            oMenuPrincipal.Add(new ListPlaces
            {
                Opcion = "ListView Ejemplo 2",
                Habilitado = true,
                idOpcion = 2,
                icon = "http://lorempixel.com/100/100/people/1"
            });
            oMenuPrincipal.Add(new ListPlaces
            {
                Opcion = "ListView Ejemplo 3",
                Habilitado = true,
                idOpcion = 3,
                icon = "http://lorempixel.com/100/100/people/1"
            });
            oMenuPrincipal.Add(new ListPlaces
            {
                Opcion = "ListView Ejemplo 4",
                Habilitado = true,
                idOpcion = 4,
                icon = "http://lorempixel.com/100/100/people/1"
            });
            oMenuPrincipal.Add(new ListPlaces
            {
                Opcion = "ListView Ejemplo 5",
                Habilitado = true,
                idOpcion = 5,
                icon = "http://lorempixel.com/100/100/people/1"
            });
            return oMenuPrincipal;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            listViewPlace.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                listViewPlace.ItemsSource = ObtenerListPlaces();
            else
                listViewPlace.ItemsSource = ObtenerListPlaces().Where(i => i.Opcion.Contains(e.NewTextValue));

            listViewPlace.EndRefresh();
        }



    }
}
