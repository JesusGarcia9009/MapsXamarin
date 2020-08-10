using GoogleMaps.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoogleMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage(String tipoEstablecimiento, String tipoProducto, bool isMap)
        {
            InitializeComponent();
            MyMenu(tipoEstablecimiento, tipoProducto, isMap);
        }

        public void MyMenu(String tipoEstablecimiento, String tipoProducto, bool isMap)
        {
            if(isMap)
                Detail = new NavigationPage(new Detail(tipoEstablecimiento, tipoProducto));
            else
                Detail = new NavigationPage(new DetailList(tipoEstablecimiento, tipoProducto));

            List<Menu> menu = new List<Menu>
            {
                new Menu{ Page = new Detail(tipoEstablecimiento, tipoProducto), MenuTitle="Mi Mapa",  MenuDetail="Mapa de lugares cercanos",icon="ic_map.png"},
                new Menu{ Page = new DetailList(tipoEstablecimiento, tipoProducto), MenuTitle="Mi listado",  MenuDetail="Listado de lugares cercanos",icon="ic_list.png"},
                new Menu{ Page = new Feed(), MenuTitle="Contactenos",  MenuDetail="Datos Personales",icon="ic_contact.png"},
            };
            ListMenu.ItemsSource = menu;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                ListMenu.SelectedItem = null;
                Detail = new NavigationPage(menu.Page);
            }
        }
    }
}
