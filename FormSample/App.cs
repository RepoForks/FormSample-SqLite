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
                // Settings.GeneralSettings= string.Empty;
                ////if (!string.IsNullOrWhiteSpace(Settings.GeneralSettings))
                ////{
                ////    page = new HomePage();
                ////    var md = new MasterDetailPage();

                ////    md.Master = new MenuPage(md);
                ////    md.Detail = new NavigationPage(page) { BarBackgroundColor = Color.Gray };

                ////    return md;
                ////}

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

    public class CustomerPage : ContentPage
    {
        public static int counter { get; set; }

        private ListView listView;
        public CustomerPage()
        {
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

