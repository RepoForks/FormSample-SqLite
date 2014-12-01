using System;
using Xamarin.Forms;
using FormSample.Views;

namespace FormSample
{

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

            Title = "Mobile Recruiter";
            Icon = "Icon.png";


            var section = new TableSection () {
                new MenuCell {Text = "Home", Host = this},
                new MenuCell {Text = "Refer a contractor", Host = this},
                new MenuCell {Text = "My contractors", Host = this},
                new MenuCell {Text = "Amend my details", Host = this},
                new MenuCell {Text = "Terms and conditions", Host = this},
                new MenuCell {Text = "About us", Host = this},
                new MenuCell {Text = "Take home pay calculator", Host = this},
                new MenuCell {Text = "Weekly pay chart", Host = this},
            };

            var root = new TableRoot () {section} ;

            tableView = new MenuTableView ()
                { 
                    Root = root,
                    //              HeaderTemplate = new DataTemplate (typeof(MenuHeader)),
                    Intent = TableIntent.Menu,
                };


            Content = new StackLayout {
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {tableView}
            };
        }

        NavigationPage sessions, speakers, favorites;
        public void Selected (string item) {

            switch (item) {
                case "Sessions":
                    if (sessions == null)
                        sessions = new NavigationPage (new HomePage ()) { BarBackgroundColor = App.NavTint };
                    master.Detail = sessions;
                    break;
                case "Speakers":
                    if (speakers == null) {
                        speakers = new NavigationPage (new RegisterPage ()) { BarBackgroundColor = App.NavTint };
                        //TODO: finish WrapLayout demo
                        //                  speakers = new NavigationPage (new SpeakersPageWrap ()) { BarBackgroundColor = App.NavTint };
                    }
                    master.Detail = speakers;
                    break;
                case "Favorites":
                    if (favorites == null)
                        favorites = new NavigationPage (new ContractorPage ()) { BarBackgroundColor = App.NavTint };
                    master.Detail = favorites;
                    break;
                case "Room Plan":
                    master.Detail = new NavigationPage(new ChartPage()) {BarBackgroundColor = App.NavTint};
                    break;
                case "Map":
                    master.Detail = new NavigationPage(new LoginPage()) {BarBackgroundColor = App.NavTint};
                    break;
//                case "About":
//                    master.Detail = new NavigationPage(new AboutPage()) {BarBackgroundColor = App.NavTint};
//                    break;            };
            master.IsPresented = false;  // close the slide-out
        }
    }

    public class MenuCell : ViewCell
    {
        Label label;

        public string Text { 
            get { return label.Text; }
            set{ label.Text = value;} 
        }

        public MenuPage Host { get; set; }

        public MenuCell ()
        {
            label = new Label {
                YAlign = TextAlignment.Center,
                TextColor = Color.White,
            };

            var layout = new StackLayout {
                BackgroundColor = App.HeaderTint,
                Padding = new Thickness(20, 0, 0, 0),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = {label}
            };
            View = layout;
        }

        protected override void OnTapped ()
        {
            base.OnTapped ();

            Host.Selected (label.Text);
        }
    }
    public class MenuHeader : ViewCell
    {
        public MenuHeader () {

            var label = new Label () {
                Text = "Evolve 2013",
                TextColor = Color.Gray,
                Font = Font.BoldSystemFontOfSize(20)
            };

            Height = 60;

            View = new StackLayout {
                Padding = new Thickness(20),
                BackgroundColor = App.HeaderTint,
                Children = { label }
            };
        }
    }
}

}