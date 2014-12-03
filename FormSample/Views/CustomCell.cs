using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;

namespace FormSample
{
    public class CustomCell : ViewCell
    {
        
        public CustomCell()
        {
            var image = new Image
            {
                HorizontalOptions = LayoutOptions.Start
            };
            image.SetBinding(Image.SourceProperty, new Binding("ProfilePicture"));
            image.WidthRequest = image.HeightRequest = 40;

            var checkBox = new CheckBox();
            checkBox.TextColor = Color.White;


            var nameLayout = CreateLayout();
            var viewLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                
                Children = { nameLayout }
            };

            viewLayout.BackgroundColor = CustomerPage.counter % 2 == 0 ? Color.Gray : Color.Silver;

            CustomerPage.counter++;
            View = viewLayout;
        }

        private StackLayout CreateLayout()
        {
            var nameLabel = new Label { HorizontalOptions = LayoutOptions.FillAndExpand };
            nameLabel.SetBinding(Label.TextProperty, new Binding("FirstName"));
            nameLabel.WidthRequest = 200;
            nameLabel.TextColor = Color.Black;

            var cityLabel = new Label { HorizontalOptions = LayoutOptions.FillAndExpand };
            cityLabel.SetBinding(Label.TextProperty, new Binding("City"));
            cityLabel.TextColor = Color.Black;

            var nameLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { nameLabel, cityLabel }
            };

            return nameLayout;

        }

        ////protected override void OnTapped()
        ////{
        ////    base.OnTapped();

        ////    var entry = (BindingContext as Agent);

        ////    var article = new WebView()
        ////    {
        ////        Source = new UrlWebViewSource
        ////        {
        ////            Url = "www.google.com",
        ////        },
        ////        VerticalOptions = LayoutOptions.FillAndExpand
        ////    };

        ////    App.Navigation.PushAsync(new RegisterPage());
        ////    // App.Navigation.PushAsync(new ChartPage());

        ////}

    }
}

