using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSample.ViewModel
{
    using System.Diagnostics;

    using FormSample.Helpers;
    using FormSample.Views;
    

    using Xamarin.Forms;
     

    public class LoginViewModel : BaseViewModel
    {
        private DataService dataService;

        private INavigation navigation;
        public LoginViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            this.dataService = new DataService();
        }

        public const string UsernamePropertyName = "Username";
        private string username = string.Empty;
        public string Username
        {
            get { return username; }
            set { this.ChangeAndNotify(ref username, value, UsernamePropertyName); }
        }

        public const string PasswordPropertyName = "Password";
        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { this.ChangeAndNotify(ref password, value, PasswordPropertyName); }
        }

        private Command loginCommand;
        public const string LoginCommandPropertyName = "LoginCommand";
        public Command LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand()));
            }
        }

		protected async Task ExecuteLoginCommand()
        {
            try
            {
                if(await ValidateFields())
                {
                    Settings.GeneralSettings = this.Username;

                    var page = new HomePage();
                    var md = new MasterDetailPage();

                    md.Master = new MenuPage(md);
                    md.Detail = new NavigationPage(page) { BarBackgroundColor = Color.Gray };
                     
                    await navigation.PushAsync(md);
                }
                 
            }
            catch (Exception ex)
            {

            }
            //if (await this.dataService.IsValidUser(this.Username, this.Password))
            //{
                
            //}
        }

        private Command goToRegisterCommand;
        public const string GoToRegisterCommandPropertyName = "GoToRegisterCommand";
        public Command GoToRegisterCommand
        {
            get
            {
                return goToRegisterCommand ?? (goToRegisterCommand = new Command(async () => await ExecuteGoToRegisterCommand()));
            }
        }

        protected async Task ExecuteGoToRegisterCommand()
        {
            try
            {
                await navigation.PushAsync(new RegisterPage());
            }
            catch(Exception ex)
            {
            }
        }

        private async Task<bool> ValidateFields()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(this.Username) && string.IsNullOrWhiteSpace(this.Password))
            {
                MessagingCenter.Send(this, "msg", "Username or password is required");
                // await Page.DisplayAlert("success", "Username or password is required", "OK");
                isValid = false;
            }
            return isValid;
        }
    }
}
