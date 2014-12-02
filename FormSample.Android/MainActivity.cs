using System;
using Android.App;
using Android.Net;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
 
using Xamarin.Forms.Labs.Droid;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Mvvm;

namespace FormSample.Droid
{
    using Android.Net;

    using global::Android.Content.PM;

    using Xamarin.Forms.Platform.Android;

    [Activity(Label = "Mobile Recruiter", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : XFormsApplicationDroid
    {
        bool _initialized = false;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // if (!_initialized) Initialise(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(App.GetMainPage());
        }

        private void Initialise(Bundle bundle)
        {
            Forms.Init(this, bundle);
            var container = new SimpleContainer();
            var app = new XFormsAppDroid();
            app.Init(this);

            var data = app.AppDataDirectory;


            container.Register(t => AndroidDevice.CurrentDevice)
                .Register(t => t.Resolve<IDevice>().Display)
                .Register(t => t.Resolve<IDevice>().Network)
                .Register<IDependencyContainer>(container)
                .Register<IXFormsApp>(app);


            Resolver.SetResolver(container.GetResolver());
            // App.Initialise();

            _initialized = true;
        }

        
    }

    
}

