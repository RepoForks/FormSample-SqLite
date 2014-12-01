using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FormSample.Views.MenuTableView), typeof(FormSample.Droid.MenuTableViewRenderer))]

namespace FormSample.Droid
{
    using Xamarin.Forms.Platform.Android;

    public class MenuTableViewRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            var tableView = Control as global::Android.Widget.ListView;
            tableView.DividerHeight = 0;
            tableView.SetBackgroundColor(new global::Android.Graphics.Color(0x2C, 0x3E, 0x50));
        }
    }
}