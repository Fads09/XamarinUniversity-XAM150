using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

namespace NetStatus
{
    public partial class NetworkViewPage : ContentPage
    {
        public NetworkViewPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(CrossConnectivity.Current.ConnectionTypes != null)
            {
                ConnectionDetails.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();
                CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
            }
            else
            {
                ConnectionDetails.Text = "No Network";
            }
            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (CrossConnectivity.Current != null)
                CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;
        }

        private void UpdateNetworkInfo(object sender, ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                ConnectionDetails.Text = connectionType.ToString();
            }
        }
    }
}