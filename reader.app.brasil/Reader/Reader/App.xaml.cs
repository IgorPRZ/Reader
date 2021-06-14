using Reader.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reader
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BarCodePrincipalPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
