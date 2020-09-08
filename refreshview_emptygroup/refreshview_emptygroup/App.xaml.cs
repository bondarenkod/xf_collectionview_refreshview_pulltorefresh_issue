using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using refreshview_emptygroup.Services;
using refreshview_emptygroup.Views;

namespace refreshview_emptygroup
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
