using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Drops.Views;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)] 
namespace Drops
{
    public partial class App : Application
    {
        // FIELDS
        const int smallWightResolution = 768;

        const int smallHeightResolution = 1280;

        // CONSTRUCTORS
        public App()
        {
            InitializeComponent();

            LoadStyles();

            MainPage = new NavigationPage(new LoginPage());
        }

        // METHODS
        void LoadStyles() // I should probably modularize the logic this methods bloated AF
        {
            // Optimizes for users RuntimePlatform
            GetRuntimePlatform();

            // Optimizes for users Display dimensions
            //GetDisplaySize();

            // Optimizes for users Device Idiom
            GetDeviceIdiom();
        }

        // Contains the logic that categorizes the users device by it's diplay dimensions
        public void GetDisplaySize()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;

            //return (width <= smallWightResolution && height <= smallHeightResolution);
            bool isSmall = (width <= smallWightResolution && height <= smallHeightResolution);

            if (isSmall)
            {
                //dictionary.MergedDictionaries.Add(SmallDevicesStyle.SharedInstance);

                System.Diagnostics.Debug.WriteLine("this is a small device");
            }
            else
            {
                //dictionary.MergedDictionaries.Add(GeneralDevicesStyle.SharedInstance);

                System.Diagnostics.Debug.WriteLine("this is not a small device");
            }
        }

        // Optimizes for users Device Idiom
        public void GetDeviceIdiom()
        {
            switch (Device.Idiom)
            {
                case TargetIdiom.Desktop:

                    System.Diagnostics.Debug.WriteLine("you're on desktop");

                    break;
                case TargetIdiom.Phone:

                    System.Diagnostics.Debug.WriteLine("you're on your phone");

                    break;
                case TargetIdiom.Tablet:

                    System.Diagnostics.Debug.WriteLine("you're on your tablet");

                    break;
                case TargetIdiom.TV:

                    System.Diagnostics.Debug.WriteLine("you're on a smart tv");

                    break;
            }
        }

        // Optimizes for users runtime platform
        public void GetRuntimePlatform()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:

                    System.Diagnostics.Debug.WriteLine("you're running iOS");

                    // Let's add style selection logic

                    break;

                case Device.Android:

                    System.Diagnostics.Debug.WriteLine("you're running android");

                    // let's add style selection logic
                    break;

                default:

                    System.Diagnostics.Debug.WriteLine("gee I don't know what you're running, maybe uwp?");

                    break;
            }
        }
    }
}