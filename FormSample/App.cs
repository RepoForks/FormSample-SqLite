using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Services;

namespace FormSample
{
    using System.Threading.Tasks;

    using FormSample.Helpers;
    using FormSample.Views;

    using Xamarin.Forms.Labs;

    public class App
    {
        public static INavigation Navigation { get; private set; }
        public static Color NavTint {
            get {
                return Color.FromHex ("3498DB"); // Xamarin Blue
            }
        }
        public static Color HeaderTint {
            get {
                return Color.FromHex ("2C3E50"); // Xamarin DarkBlue
            }
        }

        public static Color NavTint
        {
            get
            {
                return Color.FromHex("3498DB"); // Xamarin Blue
            }
        }

        public static Color HeaderTint
        {
            get
            {
                return Color.FromHex("2C3E50"); // Xamarin DarkBlue
            }
        }

<<<<<<< HEAD
        private async Task<bool> IsNetworkAvailable()
        {
            var network = Resolver.Resolve<IDevice>().Network;
            //var dev = Resolver.Resolve<IDevice>().PhoneService;
            //dev.DialNumber("989898989");


            var isReachable = await network.IsReachable("www.yahoo.com", TimeSpan.FromSeconds(15));
            return isReachable;

        }

        public static Page GetMainPage()
        {
            Page page = null;
            try
            {
                // Settings.GeneralSettings= string.Empty;
                if (!string.IsNullOrWhiteSpace(Settings.GeneralSettings))
                {
                    page = new HomePage();
                    var md = new MasterDetailPage();

                    md.Master = new MenuPage(md);
                    md.Detail = new NavigationPage(page) { BarBackgroundColor = Color.Gray };

                    return md;
                }

                page = new NavigationPage(new LoginPage());
=======

        public static Page GetMainPage()
        {


            Page page = null;
            try
            {
                 
//                /// Settings.GeneralSettings= string.Empty;
                if (!string.IsNullOrWhiteSpace(Settings.GeneralSettings))
                {
                    page= new HomePage();
                }
                else{
                    page = new LoginPage();
                }

                var md = new MasterDetailPage ();

                md.Master = new MenuPage (md);
                md.Detail = new NavigationPage(page) {Tint = App.NavTint};
                // md.IsVisible = false;
                return md;

               

>>>>>>> origin/master

                //			    page = new NavigationPage(new LoginPage());
                //                if (!string.IsNullOrWhiteSpace(Settings.GeneralSettings))
                //                {
                //                    Navigation = page.Navigation;
                //                    // return page;
                //                    // return new HomePage();
                //                }
                //                    // return new LoginPage();
                //                else
                //                {
                //                    page = new NavigationPage(new HomePage());
                //                    Navigation = page.Navigation;
                //                }
                //                // return page;
                //
                //                //var navigationPage = new NavigationPage(new HackerNewsPage());
                //                //Navigation = navigationPage.Navigation;
                //
                //                //return navigationPage;
                //
                //                ////            return new ContentPage
                //                ////            { 
                //                ////                Content = new Label
                //                ////                {
                //                ////                    Text = "Hello, Forms!",
                //                ////                    VerticalOptions = LayoutOptions.CenterAndExpand,
                //                ////                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                //                ////                },
                //                ////            };
            }
            catch (Exception ex)
            {
            }
           return page;
        }
    }

    public class HackerNewsPage : ContentPage
    {

        private ListView listView;
        public HackerNewsPage()
        {
            Title = "Customers";

            listView = new ListView
            {
                RowHeight = 80
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { listView }
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var entries = await new DataService().GetCustomers();
            listView.ItemTemplate = new DataTemplate(typeof(CustomCell));
            listView.ItemsSource = entries;
        }
    }
}

