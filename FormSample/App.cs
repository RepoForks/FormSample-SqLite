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
    using System.Globalization;
    using Xamarin.Forms.Labs.Controls;
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
                page = new NavigationPage(new StepperDemoPage()); // RootPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return page;
        }


    }

    public class SliderDemo : ContentPage
    {
        public SliderDemo()
        {
            var sliderMain = new ExtendedSlider
            {
                Minimum = 0.0f,
                Maximum = 5.0f,
                Value = 0.0f,
                StepValue = 1.0f,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            var labelCurrentValue = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BindingContext = sliderMain,
            };

            labelCurrentValue.SetBinding(Label.TextProperty,
                                            new Binding("Value", BindingMode.OneWay,
                                                null, null, "Current Value: {0}"));

            var grid = new Grid
            {
                Padding = 10,
                RowDefinitions =
            {
                new RowDefinition {Height = GridLength.Auto},
            },
                ColumnDefinitions =
            {
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
            },
            };

            for (var i = 0; i < 6; i++)
            {
                var label = new Label
                {
                    Text = i.ToString(CultureInfo.InvariantCulture),
                };

                var tapValue = i; // Prevent modified closure

                label.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() => { sliderMain.Value = tapValue; }),
                    NumberOfTapsRequired = 1
                });

                grid.Children.Add(label, i, 0);
            }

            Content = new StackLayout
            {
                Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 10),
                Children = { grid, sliderMain, labelCurrentValue },
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
        }
    }

    class StepperDemoPage : ContentPage 
   { 
       Label label; 


        public StepperDemoPage() 
        { 
            Label header = new Label 
            { 
                Text = "Stepper", 
                Font = Font.SystemFontOfSize(50, FontAttributes.Bold), 
                HorizontalOptions = LayoutOptions.Center 
            }; 


            Stepper stepper = new Stepper 
            { 
                Minimum = 100, 
                Maximum = 1000, 
                Increment = 0.1, 
                HorizontalOptions = LayoutOptions.Center, 
                VerticalOptions = LayoutOptions.CenterAndExpand 
            }; 
            stepper.ValueChanged += OnStepperValueChanged; 


            label = new Label 
            { 
                Text = "Stepper value is 0", 
                Font = Font.SystemFontOfSize(NamedSize.Large), 
                HorizontalOptions = LayoutOptions.Center, 
                VerticalOptions = LayoutOptions.CenterAndExpand 
            }; 


            // Build the page. 
            this.Content = new StackLayout 
            { 
                Children =  
                { 
                    header, 
                    stepper, 
                    label 
                } 
            }; 
        } 


        void OnStepperValueChanged(object sender, ValueChangedEventArgs e) 
        { 
            label.Text = String.Format("Stepper value is {0:F1}", e.NewValue); 
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

