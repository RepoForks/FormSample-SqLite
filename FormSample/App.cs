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

        static void CreateDatabase()
        {
            FormSample.AgentDatabase d = new AgentDatabase();
            var t = d.GetAgents();
            d.SaveItem(new Agent()
            {
                AgencyName = "test",
                Email = "abc@xyz.com",
                FirstName = "Thanki",
                LastName = "sudhir",
                Phone = "99933423",
            });
        }

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
            
            NavigationPage page = null;
            try
            {
                Settings.GeneralSettings = "hello";
                if (!string.IsNullOrWhiteSpace(Settings.GeneralSettings))
                {
                }
                // CreateDatabase ();
                page = new NavigationPage(new LoginPage());

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

