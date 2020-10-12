using Xamarin.Forms;
using Xamarin.Forms.Xaml;
// using Drops.Data;
using Drops.Models; // prabably don't need
using Drops.Views;
using Drops.Static;
using System.IO;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)] // used to be located in AssemblyInfo.CS, looks like I don't need it in a separate file though? maybe it's best practice to store the attribute in a separate classfile and the example wher I saw it in App.Xaml.cs was for the sake of brevity?
namespace Drops
{
    public partial class App : Application
    {
        

        // CONSTRUCTORS
        public App()
        {
            InitializeComponent();

            BackgroundColor = Color.FromHex("423f3b");

            NavigationBackgroundColor = Color.FromHex("58a0ca");

            // MainPage = new NavigationPage(new MapPage());
            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new LoginPage();
        }

        // PROPETIES
        public Color BackgroundColor { get; set; }

        public Color NavigationBackgroundColor { get; set; }
        
        // METHODS
        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}