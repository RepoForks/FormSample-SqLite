
namespace FormSample.Views
{
    using global::FormSample.Helpers;

    using Xamarin.Forms;
    using Xamarin.Forms.Labs;

    /// <summary>
    /// Required for PlatformRenderer
    /// </summary>


    public class MenuTableView : TableView
    {
    }

    public class MenuPage : ContentPage
    {
        private MasterDetailPage master;



        private TableView tableView;

        public MenuPage(MasterDetailPage m)
        {
            master = m;


            Title = "Main Menu";
            Icon = "slideout.png";


            Title = "Mobile Recruiter";
            Icon = "Icon.png";


            var section = new TableSection()
                              {
                                  new MenuCell { Text = "Home", Host = this },
                                  new MenuCell { Text = "Refer a contractor", Host = this },
                                  new MenuCell { Text = "My contractors", Host = this },
                                  new MenuCell { Text = "Amend my details", Host = this },
                                  new MenuCell { Text = "Terms and conditions", Host = this },
                                  new MenuCell { Text = "About us", Host = this },
                                  new MenuCell { Text = "Take home pay calculator", Host = this },
                                  new MenuCell { Text = "Weekly pay chart", Host = this },
                              };

            var root = new TableRoot() { section };

            tableView = new MenuTableView()
                            {
                                Root = root,
                                // HeaderTemplate = new DataTemplate (typeof(MenuHeader)),
                                Intent = TableIntent.Menu,
                            };


            Content = new StackLayout
                          {
                              BackgroundColor = Color.Gray,
                              VerticalOptions = LayoutOptions.FillAndExpand,
                              Children = { tableView }
                          };
        }

        public void Selected(string item)
        {
            switch (item)
            {
                case "Sessions":
                    master.Detail = new NavigationPage(new HomePage()) { BarBackgroundColor = App.NavTint };
                    break;
                case "Speakers":
                    master.Detail = new NavigationPage(new RegisterPage()) { BarBackgroundColor = App.NavTint };
                    break;
                case "Favorites":
                    master.Detail = new NavigationPage(new ContractorPage()) { BarBackgroundColor = App.NavTint };
                    break;
                case "Room Plan":
                    master.Detail = new NavigationPage(new ChartPage()) { BarBackgroundColor = App.NavTint };
                    break;
                case "Map":
                    master.Detail = new NavigationPage(new LoginPage()) { BarBackgroundColor = App.NavTint };
                    break;
            }

            master.IsPresented = false;
        }
    }

    /// <summary>
    /// The menu cell.
    /// </summary>
    public class MenuCell : ViewCell
    {

        public string Text
        {
            get
            {
                return label.Text;
            }
            set
            {
                label.Text = value;
            }
        }

        private Label label;

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        public MenuPage Host { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuCell"/> class.
        /// </summary>
        public MenuCell()
        {
            label = new Label { YAlign = TextAlignment.Center, TextColor = Color.White, };


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

        /// <summary>
        /// The on tapped.
        /// </summary>
        protected override void OnTapped()
        {
            base.OnTapped();
            Host.Selected(label.Text);
        }
    }

    /// <summary>
    /// The menu header.
    /// </summary>
    public class MenuHeader : ViewCell
    {
        public MenuHeader()
        {

            var label = new Label()
                            {
                                Text = "Evolve 2013",
                                TextColor = Color.Gray,
                                Font = Font.BoldSystemFontOfSize(20)
                            };

            Height = 60;

            View = new StackLayout
                       {
                           Padding = new Thickness(20),
                           BackgroundColor = App.HeaderTint,
                           Children = { label }
                       };
        }
    }
}



