// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuPage.cs" company="">
//   
// </copyright>
// <summary>
//   Required for PlatformRenderer
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FormSample.Views
{
    using System.Collections.Generic;

    using Xamarin.Forms;

    /// <summary>
    ///     Required for PlatformRenderer
    /// </summary>
    public class MenuTableView : TableView
    {
    }

    /// <summary>
    /// The menu page.
    /// </summary>
    public class MenuPage : ContentPage
    {
        #region Fields

        /// <summary>
        /// The master.
        /// </summary>
        private readonly MasterDetailPage master;

        /// <summary>
        /// The table view.
        /// </summary>
        private TableView tableView;
        public ListView Menu { get; set; }
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPage"/> class.
        /// </summary>
       
        public MenuPage()
        {
            // this.master = new MasterDetailPage();

            this.Title = "Main Menu";
            this.Icon = "slideout.png";

            var itemList = new List<string> { "Home", "Speakers", "Favorites","Logout" };
            Menu = new ListView() { ItemsSource = itemList };

            //var section = new TableSection
            //                  {
            //                      new MenuCell { Text = "Home", Host = this }, 
            //                      new MenuCell { Text = "Refer a contractor", Host = this }, 
            //                      new MenuCell { Text = "My contractors", Host = this }, 
            //                      new MenuCell { Text = "Amend my details", Host = this }, 
            //                      new MenuCell { Text = "Terms and conditions", Host = this }, 
            //                      new MenuCell { Text = "About us", Host = this }, 
            //                      new MenuCell { Text = "Take home pay calculator", Host = this }, 
            //                      new MenuCell { Text = "Weekly pay chart", Host = this }, 
            //                  };

            //var root = new TableRoot { section };

            //this.tableView = new MenuTableView
            //                     {
            //                         Root = root, 
                                     
            //                         // HeaderTemplate = new DataTemplate (typeof(MenuHeader)),
            //                         Intent = TableIntent.Menu, 
            //                     };
            

            this.Content = new StackLayout
                               {
                                   BackgroundColor = Color.Gray, 
                                   VerticalOptions = LayoutOptions.FillAndExpand, 
                                   Children = {
                                                 Menu 
                                              }
                               };
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The selected.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Selected(string item)
        {
            switch (item)
            {
                case "Home":
                    this.master.Detail = new NavigationPage(new HomePage()) { BarBackgroundColor = App.NavTint };
                    break;
                case "Speakers":
                    this.master.Detail = new NavigationPage(new RegisterPage()) { BarBackgroundColor = App.NavTint };
                    break;
                case "Favorites":
                    this.master.Detail = new NavigationPage(new ContractorPage()) { BarBackgroundColor = App.NavTint };
                    break;
                case "Room Plan":
                    this.master.Detail = new NavigationPage(new ChartPage()) { BarBackgroundColor = App.NavTint };
                    break;
                case "Map":
                    this.master.Detail = new NavigationPage(new LoginPage()) { BarBackgroundColor = App.NavTint };
                    break;
            }

            this.master.IsPresented = false;
        }

        #endregion
    }

    /// <summary>
    ///     The menu cell.
    /// </summary>
    public class MenuCell : ViewCell
    {
        #region Fields

        /// <summary>
        /// The label.
        /// </summary>
        private readonly Label label;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MenuCell" /> class.
        /// </summary>
        public MenuCell()
        {
            this.label = new Label { YAlign = TextAlignment.Center, TextColor = Color.White, };

            var layout = new StackLayout
                             {
                                 BackgroundColor = App.HeaderTint, 
                                 Padding = new Thickness(20, 0, 0, 0), 
                                 Orientation = StackOrientation.Horizontal, 
                                 HorizontalOptions = LayoutOptions.StartAndExpand, 
                                 Children = {
                                               this.label 
                                            }
                             };

            this.View = layout;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the host.
        /// </summary>
        public MenuPage Host { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text
        {
            get
            {
                return this.label.Text;
            }

            set
            {
                this.label.Text = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The on tapped.
        /// </summary>
        protected override void OnTapped()
        {
            base.OnTapped();
            this.Host.Selected(this.label.Text);
        }

        #endregion
    }

    /// <summary>
    ///     The menu header.
    /// </summary>
    public class MenuHeader : ViewCell
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuHeader"/> class.
        /// </summary>
        public MenuHeader()
        {
            var label = new Label { Text = "Evolve 2013", TextColor = Color.Gray, Font = Font.BoldSystemFontOfSize(20) };

            this.Height = 60;

            this.View = new StackLayout
                            {
                                Padding = new Thickness(20), 
                                BackgroundColor = App.HeaderTint, 
                                Children = {
                                              label 
                                           }
                            };
        }

        #endregion
    }
}