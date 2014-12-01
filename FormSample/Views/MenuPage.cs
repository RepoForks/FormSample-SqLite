using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSample.Views
{
    using FormSample.Helpers;

    using Xamarin.Forms;

    /// <summary>
    /// Required for PlatformRenderer
    /// </summary>
    public class MenuTableView : TableView
    {
    }

    public class MenuPage : ContentPage
    {
        MasterDetailPage master;

        TableView tableView;

        public MenuPage(MasterDetailPage m)
        {
            master = m;

            Title = "Main Menu";
            Icon = "slideout.png";

            var section = new TableSection() {
				new MenuCell {Text = "Home", Host = this},
				new MenuCell {Text = "Refer a contractor", Host = this},
				new MenuCell {Text = "My contractors", Host = this},
				new MenuCell {Text = "Amend my detail", Host = this},
				new MenuCell {Text = "Download terms and conditions", Host = this},
				new MenuCell {Text = "About us", Host = this},
                new MenuCell {Text = "Contact us", Host = this},
                new MenuCell {Text = "Take home pay calculator", Host = this},
                new MenuCell {Text = "Weekly pay chart", Host = this},
                new MenuCell {Text = "Logout", Host = this},
			};

            var root = new TableRoot() { section };

            tableView = new MenuTableView()
            {
                Root = root,
                //				HeaderTemplate = new DataTemplate (typeof(MenuHeader)),
                Intent = TableIntent.Menu,
            };


            Content = new StackLayout
            {
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { tableView }
            };
        }

        NavigationPage sessions, speakers, favorites;
        public void Selected(string item)
        {

            switch (item)
            {
                case "Home":
                    if (sessions == null)
                        sessions = new NavigationPage(new HomePage()) { BarBackgroundColor = App.NavTint };
                    master.Detail = sessions;
                    break;
                case "Refer a contractor":
                    if (speakers == null)
                    {
                        speakers = new NavigationPage(new LoginPage()) { BarBackgroundColor = App.NavTint };
                        master.Detail = speakers;
                    }
                    master.Detail = speakers;
                    break;
                case "My contractors":
                    if (favorites == null)
                        favorites = new NavigationPage(new RegisterPage()) { BarBackgroundColor = App.NavTint };
                    master.Detail = favorites;
                    break;
                case "Room Plan":
                    master.Detail = new NavigationPage(new RegisterPage()) { BarBackgroundColor = App.NavTint };
                    break;
                //case "Map":
                //    master.Detail = new NavigationPage(new MapPage()) { BarBackgroundColor = App.NavTint };
                //    break;
                //case "About":
                //    master.Detail = new NavigationPage(new AboutPage()) { BarBackgroundColor = App.NavTint };
                //    break;
                case "Logout":
                    Settings.GeneralSettings = string.Empty;
                    App.GetMainPage();
                    break;
            };
            master.IsPresented = false;  // close the slide-out
        }
    }

    public class MenuCell : ViewCell
    {
        public string Text
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        Label label;

        public MenuPage Host { get; set; }

        public MenuCell()
        {
            label = new Label
            {
                YAlign = TextAlignment.Center,
                TextColor = Color.White,
            };

            var layout = new StackLayout
            {
                BackgroundColor = App.HeaderTint,
                Padding = new Thickness(20, 0, 0, 0),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { label }
            };
            View = layout;
        }

        protected override void OnTapped()
        {
            base.OnTapped();

            Host.Selected(label.Text);
        }
    }

}
