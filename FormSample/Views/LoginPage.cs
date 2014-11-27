using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSample.Views
{
    using FormSample.ViewModel;
    using Xamarin.Forms;

    public class LoginPage : ContentPage
    {


        public LoginPage()
        {
            MessagingCenter.Subscribe<LoginViewModel,string>(this,"msg",(sender,args)=>{
                DisplayAlert("Message",args,"OK");
            });

            BindingContext = new LoginViewModel(Navigation);

            BackgroundColor = Color.FromHex("232323");

            var layout = new StackLayout { Padding = 5 };

            var label = new Label
                            {
                                Text = "Sign in",
                                Font = Font.SystemFontOfSize(NamedSize.Large),
                                TextColor = Color.White,
                                VerticalOptions = LayoutOptions.Center,
                                XAlign = TextAlignment.Center, // Center the text in the blue box.
                                YAlign = TextAlignment.Center, // Center the text in the blue box.
                            };

            layout.Children.Add(label);

            var username = new Entry { Placeholder = "Username" };
            username.SetBinding(Entry.TextProperty, LoginViewModel.UsernamePropertyName);
			username.Keyboard = Keyboard.Email;
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "Password" };
            password.SetBinding(Entry.TextProperty, LoginViewModel.PasswordPropertyName);
            password.IsPassword = true;
            layout.Children.Add(password);

            var forgotPassword = new Button{ Text = "I have forgetton my password", TextColor = Color.Blue };

			var button = new Button { Text = "Sign In", TextColor = Color.White,BackgroundColor = Color.Blue, };
            button.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);

			var registerButton = new Button{ Text = "I don't have a recruiter account..",BackgroundColor = Color.Lime, TextColor = Color.White };
            registerButton.SetBinding(Button.CommandProperty, LoginViewModel.GoToRegisterCommandPropertyName);

            var downloadButton = new Button{ Text = "Download Terms and Conditions",BackgroundColor = Color.Yellow, TextColor = Color.White };
			var contactUsButton = new Button{ Text = "Contact Us",BackgroundColor = Color.Teal, TextColor = Color.White };

            layout.Children.Add(button);
			layout.Children.Add(registerButton);
			layout.Children.Add(downloadButton);
			layout.Children.Add(contactUsButton);

            Content = new ScrollView { Content = layout };
        }

       
    }
}
