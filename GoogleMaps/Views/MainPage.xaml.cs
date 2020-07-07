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
        public MainPage()
        {
            InitializeComponent();
            MyMenu();
        }

        public void MyMenu()
        {
            Detail = new NavigationPage(new Detail());
            List<Menu> menu = new List<Menu>
            {
                new Menu{ Page= new Detail(), MenuTitle="Mi Mapa",  MenuDetail="Mapa de lugares cercanos",icon="ic_map.png"},
                new Menu{ Page= new DetailList(), MenuTitle="Mi listado",  MenuDetail="Listado de lugares cercanos",icon="ic_list.png"},
                new Menu{ Page= new Feed(), MenuTitle="Contactenos",  MenuDetail="Datos Personales",icon="contacts.png"},
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
