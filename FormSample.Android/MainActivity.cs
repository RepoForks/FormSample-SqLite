using Android.App;
using Android.OS;

namespace FormSample.Droid
{
    using FormSample.Views;

    using global::Android.Content.PM;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    [Activity(Label = "Customer page", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AndroidActivity
    {
        bool _initialized = false;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // if (!_initialized) Initialise(bundle);
            OxyPlot.XamarinFormsAndroid.Forms.Init();
            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(App.GetMainPage());
            // BuildView();
        }

        static Page BuildView()
        {
            return new MainPage();
        }

        //private void Initialise(Bundle bundle)
        //{
        //    Forms.Init(this, bundle);
        //    var container = new SimpleContainer();
        //    var app = new XFormsAppDroid();
        //    app.Init(this);

        //    var data = app.AppDataDirectory;


        //    container.Register(t => AndroidDevice.CurrentDevice)
        //        .Register(t => t.Resolve<IDevice>().Display)
        //        .Register(t => t.Resolve<IDevice>().Network)
        //        .Register<IDependencyContainer>(container)
        //        .Register<IXFormsApp>(app);


        //    Resolver.SetResolver(container.GetResolver());
        //    // App.Initialise();

        //    _initialized = true;
        //}

        
    }

    
}

