using System;
using Xamarin.Forms;

namespace FormSample
{
    public class ContactUs : ContentPage
    {
        public ContactUs()
        {
            this.Title = "Contact us";
            Label label = new Label(){ Text = "To speak with a member of our dedicated team:" };

            double width = 320;
            double height = 150;


            var phoneNumberImage = new Image()
            {
                    WidthRequest =   width,
                    HeightRequest=height,
                    Aspect = Aspect.AspectFill
            };

            phoneNumberImage.Source = ImageSource.FromFile("ContactPhoneNumber.jpg");

            var agencyImage = new Image() {
                WidthRequest = width,
                HeightRequest=height,
                Aspect = Aspect.AspectFill
            };

            agencyImage.Source = ImageSource.FromFile("ContactAgency.jpg");

            var contactMapImage = new Image() {
                WidthRequest = width,
                HeightRequest=height,
                Aspect = Aspect.AspectFill
            };
            

            contactMapImage.Source = ImageSource.FromFile("ContactMap.jpg");

            var downloadButton = new Button { Text = "Download Terms and Conditions", BackgroundColor = Color.Gray, TextColor = Color.Black }; 
            // downloadButton.Image = FileImageSource.FromFile("ContactPhoneNumber");
            var layout = new StackLayout
            {
                    Orientation = StackOrientation.Vertical,
                    Padding = 0,
                    HorizontalOptions = LayoutOptions.Fill,
                    Children = {label,phoneNumberImage, agencyImage,contactMapImage,agencyImage,contactMapImage,downloadButton}
            };


            this.Content = new ScrollView{Content = layout};
        }
    }
}

