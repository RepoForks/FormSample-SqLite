using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FormSample.Droid
{
    using System.Threading.Tasks;

    using Acr.XamForms.Mobile.Net;

    using Android.Net;
    using Xamarin.Forms;
    using Java.Net;
    using Acr.XamForms.Mobile.Droid.Net;

    [assembly: Dependency(typeof(NetworkService))]
    public class NetworkService : INetworkService1
    {
        private ConnectivityManager connectivityManager;
        public NetworkService()
        {
            // NetworkConnectionBroadcastReceiver.OnChange = this.SetFromInfo;
            this.connectivityManager = (ConnectivityManager)Forms.Context.GetSystemService(Application.ConnectivityService);
            // this.SetFromInfo(manager.ActiveNetworkInfo);
        }

        //private void SetFromInfo(NetworkInfo network)
        //{
        //    if (network == null || !network.IsConnected)
        //        this.IsConnected = false;
        //    else
        //    {
        //        this.IsConnected = true;
        //        this.IsRoaming = network.IsRoaming;
        //        this.IsWifi = (network.Type == ConnectivityType.Wifi);
        //        this.IsMobile = (network.Type == ConnectivityType.Mobile);
        //    }
        //    this.PostUpdateStates();
        //}

        public bool IsReachable()
        {
            var isConnected = false;
            // var connectivityManager = (ConnectivityManager)Forms.Context.GetSystemService(Application.ConnectivityService);

            var activeConnection = connectivityManager.ActiveNetworkInfo;

            if ((activeConnection != null) && activeConnection.IsConnected)
            {
                isConnected = true;
                // we are connected to a network.
            }

            var mobile = connectivityManager.GetNetworkInfo(ConnectivityType.Mobile).GetState();
            if (mobile == NetworkInfo.State.Connected)
            {
                // We are connected via WiFi
                //  _roamingImage.SetImageResource(Resource.Drawable.green_square);
                isConnected = true;
            }

            var wifiState = connectivityManager.GetNetworkInfo(ConnectivityType.Wifi).GetState();
            if (wifiState == NetworkInfo.State.Connected)
            {
                isConnected = true;
                // _wifiImage.SetImageResource(Resource.Drawable.green_square);
            }

            isConnected =InetAddress.GetByName("www.google.com").IsReachable(5000);
            return isConnected;
        }

        //public override Task<bool> IsHostReachable(string host)
        //{
        //    return Task<bool>.Run(() =>
        //    {
        //        if (!this.IsConnected)
        //            return false;


        //        try
        //        {
        //            return InetAddress.GetByName(host).IsReachable(5000);
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    });

        //}
    }


    [BroadcastReceiver(Enabled = true, Label = "Network Status Receiver")]
    [IntentFilter(new string[] { "android.net.conn.CONNECTIVITY_CHANGE" })]
    public class NetworkConnectionBroadcastReceiver : BroadcastReceiver
    {
        internal static Action<NetworkInfo> OnChange { get; set; }




        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Extras == null || OnChange == null)
                return;


            var ni = intent.Extras.Get(ConnectivityManager.ExtraNetworkInfo) as NetworkInfo;
            if (ni == null)
                return;


            OnChange(ni);
        }
    }

}