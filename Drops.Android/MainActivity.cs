using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Xamarin.Forms;

namespace Drops.Droid
{
    [Activity(Label = "Drops", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.SensorPortrait)]
    // [Activity(Label = "Drops", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;

        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            // let's see if we can get feedback here
            System.Diagnostics.Debug.WriteLine("OnConfigurationChanged was called");

            switch (newConfig.Orientation)
            {
                // I need to grok Android.Content.Res.Orientation.Landscape
                // I'm pretty sure the value is just used as an indication of the detected device orientation
                case Android.Content.Res.Orientation.Landscape:
                    switch (Device.Idiom)
                    {
                        case TargetIdiom.Phone:

                            System.Diagnostics.Debug.WriteLine("idiom is android phone w/ horizontal orientation");

                            LockRotation(Orientation.Vertical);

                            break;

                        case TargetIdiom.Tablet:

                            System.Diagnostics.Debug.WriteLine("idiom is android tablet w/ horizontal orientation");

                            LockRotation(Orientation.Vertical);
                            break;

                    }
                    break;
                case Android.Content.Res.Orientation.Portrait:
                    switch (Device.Idiom)
                    {
                        case TargetIdiom.Phone:

                            System.Diagnostics.Debug.WriteLine("idiom is android phone w/ vetical orientation");

                            LockRotation(Orientation.Vertical);
                            break;
                        case TargetIdiom.Tablet:

                            System.Diagnostics.Debug.WriteLine("idiom is android tablet w/ vertical orientation");

                            LockRotation(Orientation.Vertical);
                            break;
                    }
                    break;
            }
        }

        private void LockRotation(Orientation orientation)
        {
            System.Diagnostics.Debug.WriteLine("Lock rotation was invoked");
            switch (orientation)
            {
                case Orientation.Vertical:
                    RequestedOrientation = ScreenOrientation.Portrait;
                    break;
                case Orientation.Horizontal:
                    RequestedOrientation = ScreenOrientation.Landscape;
                    break;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Not sure if i need these but they got to go for the time being
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;
            //RequestedOrientation = ScreenOrientation.Portrait;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnStart()
        {
            base.OnStart();

            System.Diagnostics.Debug.WriteLine("it's a startin!");

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    // Permissions already granted - display a message.
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            if (requestCode == RequestLocationId)
            {
                if ((grantResults.Length == 1) && (grantResults[0] == (int)Permission.Granted))
                    // Permissions granted - display a message.
                    System.Diagnostics.Debug.WriteLine("Permissions granted.");
                else
                    // Permissions denied - display a message.
                    System.Diagnostics.Debug.WriteLine("Permissions Denied.");
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
    }
}