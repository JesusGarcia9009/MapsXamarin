using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoogleMaps
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetail { get; set; }

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new GoogleMaps.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
