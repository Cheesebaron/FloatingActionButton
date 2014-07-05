using Android.App;
using Android.OS;
using Android.Views;

namespace Sample
{
    [Activity(Label = "@string/app_name")]
    public class AboutActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Window.RequestFeature(WindowFeatures.ActionBarOverlay);
            ActionBar.SetBackgroundDrawable(null);

            SetContentView(Resource.Layout.about);
        }
    }
}