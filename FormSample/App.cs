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

        public static MainPage RootPage { get; set; }

        public static Page GetMainPage()
        {
            Page page = null;
            try
            {
                RootPage = new MainPage();
                page = RootPage;
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

