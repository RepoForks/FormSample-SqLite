using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Services;

namespace FormSample
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;

    using FormSample.Helpers;
    using FormSample.ViewModel;
    using FormSample.Views;
    using Xamarin.Forms.Labs;
    public class App
    {
        public static INavigation Navigation { get; private set; }
        
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

        public static Page GetMainPage()
        {
            Page page = null;
            try
            {
                Agent a = new Agent() { FirstName = "sudhir", LastName = "thanki", City = "ahd", };
                Agent b = new Agent() { FirstName = "san", LastName = "modha", City = "pbr", };
                AgentDatabase d = new AgentDatabase();
                d.SaveItem(a);
                d.SaveItem(b);

                // Settings.GeneralSettings= string.Empty;
                ////if (!string.IsNullOrWhiteSpace(Settings.GeneralSettings))
                ////{
                ////    page = new HomePage();
                ////    var md = new MasterDetailPage();

                ////    md.Master = new MenuPage(md);
                ////    md.Detail = new NavigationPage(page) { BarBackgroundColor = Color.Gray };

                ////    return md;
                ////}

                page = new NavigationPage(new CustomerPage());


                 





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
                throw ex;
            }
            return page;
        }


    }

    public class CustomerPage : ContentPage
    {
        
        public static int counter { get; set; }

        private CustomerViewModel viewModel = new CustomerViewModel();
        private ListView listView;
        public CustomerPage()
        {
            var x = DependencyService.Get<INetworkService>().IsReachable();
            if (!x)
            {
                DisplayAlert("Message", "No connection found!", "OK");
            }

            var d = DependencyService.Get<IDeviceService>();
            d.Call("123455");

            counter = 1;
            Title = "Customers";

            listView = new ListView
            {
                RowHeight = 20
            };

            var grid = new Grid
            {
                ColumnSpacing = 200
                
           };
            grid.Children.Add(new Label { Text = "Name" }, 0, 0); // Left, First element
            grid.Children.Add(new Label { Text = "City" }, 1, 0);
            
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { grid, listView }
            };
            listView.ItemTapped += async (sender, args) =>
            {
                var customer = args.Item as Agent;
                if (customer == null)
                    return;

                var answer = await DisplayAlert("Confrim?", "are you sure?", "Yes", "No");
                if (answer)
                {
                    this.viewModel.DeleteCustomer(customer.Id);
                    listView.ItemsSource = this.viewModel.customerList;
                }

                listView.SelectedItem = null;
            };


        }

         

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //// var entries = await new DataService().GetCustomers();
            //// listView.ItemsSource = entries;
            listView.ItemTemplate = new DataTemplate(typeof(CustomCell));
            
            listView.ItemsSource = this.viewModel.customerList;
        }
    }

    public interface INetworkService
    {
        bool IsReachable();
    }

    public interface IDeviceService
    {
        void Call(string phoneNumber);

    }
}

