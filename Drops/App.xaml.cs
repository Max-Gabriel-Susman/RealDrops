using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Drops.Views;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)] 
namespace Drops
{
    public partial class App : Application
    {
        // CONSTRUCTORS
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}