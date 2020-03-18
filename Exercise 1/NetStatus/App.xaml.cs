using System;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetStatus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = CrossConnectivity.Current.IsConnected
                ? (Page) new NetworkViewPage()
                : new NoNetworkPage();
        }

        protected override void OnStart()
        {
            base.OnStart();
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectionChange;
        }

        private void HandleConnectionChange(object sender, ConnectivityChangedEventArgs e)
        {
            Type currentPage = this.MainPage.GetType();
            if(e.IsConnected && currentPage != typeof(NetworkViewPage))
            {
                this.MainPage = new NetworkViewPage();
            }
            else if(!e.IsConnected && currentPage != typeof(NoNetworkPage))
            {
                this.MainPage = new NetworkViewPage();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
