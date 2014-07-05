using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.OS;
using Android.Widget;
using DK.Ostebaronen.FloatingActionButton;

namespace Sample
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Fab _fab;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _fab = FindViewById<Fab>(Resource.Id.fabbutton);
            _fab.FabColor = Color.White;
            _fab.FabDrawable = Resources.GetDrawable(Resource.Drawable.ic_content_edit);
            _fab.Click += (s, e) => Toast.MakeText(this, "Clicked Fab", ToastLength.Short).Show();
            ActionBar.SetBackgroundDrawable(new ColorDrawable(Color.Black));

            var blue = FindViewById<View>(Resource.Id.blueButton);
            blue.Click += (s, e) =>
            {
                var holoBlue = Resources.GetColor(Android.Resource.Color.HoloBlueLight);
                _fab.FabColor = holoBlue;
                ActionBar.SetBackgroundDrawable(new ColorDrawable(holoBlue));
                _fab.FabDrawable = Resources.GetDrawable(Resource.Drawable.ic_content_new);
            };

            var purple = FindViewById<View>(Resource.Id.purpleButton);
            purple.Click += (s, e) =>
            {
                var holoPurple = Resources.GetColor(Android.Resource.Color.HoloPurple);
                _fab.FabColor = holoPurple;
                ActionBar.SetBackgroundDrawable(new ColorDrawable(holoPurple));
                _fab.FabDrawable = Resources.GetDrawable(Resource.Drawable.ic_av_play);
            };

            var green = FindViewById<View>(Resource.Id.greenButton);
            green.Click += (s, e) =>
            {
                var holoGreen = Resources.GetColor(Android.Resource.Color.HoloGreenLight);
                _fab.FabColor = holoGreen;
                ActionBar.SetBackgroundDrawable(new ColorDrawable(holoGreen));
                _fab.FabDrawable = Resources.GetDrawable(Resource.Drawable.ic_content_discard);
            };

            var oraange = FindViewById<View>(Resource.Id.orangeButton);
            oraange.Click += (s, e) =>
            {
                var holoOrange = Resources.GetColor(Android.Resource.Color.HoloOrangeLight);
                _fab.FabColor = holoOrange;
                ActionBar.SetBackgroundDrawable(new ColorDrawable(holoOrange));
                _fab.FabDrawable = Resources.GetDrawable(Resource.Drawable.ic_social_add_person);
            };

            var red = FindViewById<View>(Resource.Id.redButton);
            red.Click += (s, e) =>
            {
                var holoRed = Resources.GetColor(Android.Resource.Color.HoloRedLight);
                _fab.FabColor = holoRed;
                ActionBar.SetBackgroundDrawable(new ColorDrawable(holoRed));
                _fab.FabDrawable = Resources.GetDrawable(Resource.Drawable.ic_navigation_accept);
            };

            var hide = FindViewById<Button>(Resource.Id.hideButton);
            hide.Click += (s, e) =>
            {
                _fab.Hide();
                ActionBar.Hide();
            };

            var show = FindViewById<Button>(Resource.Id.showButton);
            show.Click += (s, e) =>
            {
                _fab.Show();
                ActionBar.Show();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            StartActivity(new Intent(this, typeof(AboutActivity)));
            return base.OnOptionsItemSelected(item);
        }
    }
}

