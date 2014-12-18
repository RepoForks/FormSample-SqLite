using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSample.Views
{
    using FormSample.Helpers;

    using Xamarin.Forms;

    public class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            var menuPage = new MenuPage();
            menuPage.Menu.ItemSelected += (sender, e) =>
                {
                    NavigateTo(e.SelectedItem as string);
                    // menuPage.Menu.SelectedItem = null;
                };
            Master = menuPage;
            
            this.NavigateTo("Home");
            // Detail = detailPage;
            // ShowLoginPage();

        }

       
        public async void ShowLoginPage()
        {
            if (string.IsNullOrWhiteSpace(Settings.GeneralSettings))
            {
                var page = new LoginPage();
                await Navigation.PushModalAsync(page);
            }
        }

        public void NavigateTo(string item)
        {
            Page page = new HomePage();
            switch (item)
            {
                case "Home":
                    page = new HomePage();
                    break;
                case "Speakers":
                    page = new ChartPage();
                    break;
                case "Favorites":
                    page = new ColumnChartPage();
                    break;
                case "About us":
                    page = new AboutUs();
                    break;
                case "Contact us":
                    page = new ContactUs();
                    break;

                case "Logout":
                    Settings.GeneralSettings = string.Empty;
                    // page = new LoginPage();
                    break;
            }

            this.Detail = new NavigationPage(page);
            this.IsPresented = false;
        }
    }
}
