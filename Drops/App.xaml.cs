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
        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new NavigationPage(new LoginPage());


        //}
        public App()
        {
            InitializeComponent();
            LoadStyles();

            MainPage = new MainPage();
        }

        // METHODS
        void LoadStyles()
        {
            // I need to create logic that implements styles dependent upon platform
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

            // This logic will be implemented later for tablet and desktop support
            if (IsASmallDevice())
            {
                dictionary.MergedDictionaries.Add(SmallDevicesStyle.SharedInstance);
            }
            else
            {
                dictionary.MergedDictionaries.Add(GeneralDevicesStyle.SharedInstance);
            }
        }

        // I'm going to implement this in the future to make the code adaptive
        //switch (Device.RuntimePlatform)
        //{
        //    case Device.iOS:
        //        // dropsglyph.pdf assing this to the 
        //        break;
        //    case Device.Android:

        //        break;
        //    default:

        //        break;
        //}

        //switch (Device.Idiom)
        //{
        //    case TargetIdiom.Desktop:

        //        break;
        //    case TargetIdiom.Phone:
        //        break;
        //    case TargetIdiom.Tablet:
        //        break;
        //    case TargetIdiom.TV:
        //        break;
        //}


        public static bool IsASmallDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= smallWightResolution && height <= smallHeightResolution);
        }
    }
}