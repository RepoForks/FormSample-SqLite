using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs;

namespace FormSample.Views
{
    using FormSample.Helpers;

    using Xamarin.Forms;
    

    public class HomePage : ContentPage
    {
        private INetworkService _network { get; set; }
        int count = 1;

        private bool IsNetworkAvailable()
        {
            var x = DependencyService.Get<INetworkService>().IsReachable();
            return true;
        }

        private async Task GoToLoginPage()
        {
            if (string.IsNullOrWhiteSpace(Settings.GeneralSettings))
            {
                var page = new LoginPage();
                await Navigation.PushModalAsync(page);
            }
        }

        public HomePage()
        {
            // var t = this.IsNetworkAvailable();
            this.GoToLoginPage();

            Title = "Home";

            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 10
            };

            var grid = new Grid
            {
                RowSpacing = 10
            };

            Image imgReferContractor = new Image(){
                WidthRequest = 100,
                HeightRequest=100
            };
            imgReferContractor.Source = ImageSource.FromFile("index5.jpg");

            Image imgMyContractor = new Image(){
                WidthRequest = 100,
                HeightRequest=100
            };
            imgMyContractor.Source = ImageSource.FromFile("index6.jpg");

            Image imgAboutUs = new Image(){
                WidthRequest = 100,
                HeightRequest=100
            };
            imgAboutUs.Source = ImageSource.FromFile("index7.jpg");

            Image imgAmendDetail = new Image(){
                WidthRequest = 100,
                HeightRequest=100
            };
            imgAmendDetail.Source = ImageSource.FromFile("index8.jpg");

            Image imgPayChart = new Image(){
                WidthRequest = 100,
                HeightRequest=100,

            };
            imgPayChart.Source = ImageSource.FromFile("index5.jpg");


            Image imgPayCalc = new Image(){
                WidthRequest = 100,
                HeightRequest=100
            };
            imgPayCalc.Source = ImageSource.FromFile("index6.jpg");


            // grid.Children.Add(new Label { Text = "Refer a Contractor" }, 0, 0); // Left, First element
            grid.Children.Add(imgReferContractor, 0, 0); // Left, First element
            grid.Children.Add(imgMyContractor, 1, 0); // Right, First element  new Label { Text = "My Contractors" }
            grid.Children.Add(imgAboutUs , 0, 1); // Left, Second element new Label { Text = "About us" }
            grid.Children.Add(imgAmendDetail, 1, 1); // Right, Second element new Label { Text = "Amend detail" }
            grid.Children.Add(imgPayChart, 0, 2); // Left, Thrid element
            grid.Children.Add(imgPayCalc, 1, 2); // Right, Thrid element


            var tapGestureRecognizer = new TapGestureRecognizer ();
            tapGestureRecognizer.Tapped += (sender, e) => DisplayAlert("Message","Image clicked","OK");
            imgReferContractor.GestureRecognizers.Add(tapGestureRecognizer);


            var myContractorGestureRecognizer = new TapGestureRecognizer ();
            myContractorGestureRecognizer.Tapped += (sender, e) => DisplayAlert("Message","Image clicked","OK");
            imgMyContractor.GestureRecognizers.Add(myContractorGestureRecognizer);

            var gridButton = new Button { Text = "Download terms and condition" };
             
            gridButton.Clicked += delegate
            {
                gridButton.Text = string.Format("Thanks! {0} clicks.", count++);
            };
            ////grid.Children.Add(gridButton, 0, 3); // Left, Third element
            ////grid.Children.Add(new Label { Text = " " }, 1, 3);
            layout.Children.Add(grid);
            layout.Children.Add(gridButton);
            Content = layout;
        }
    }
}
