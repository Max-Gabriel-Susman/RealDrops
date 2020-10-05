using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.ViewModels;
using Drops.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Drops.Views
{
    public partial class AreaCreationDetailView : ContentPage
    {
        // CONSTRUCTORS
        public AreaCreationDetailView()
        {
            InitializeComponent();

            SubscribedAreas = new ObservableCollection<DropsArea>();

            AllAreas.GetSubscribedAreas(SubscribedAreas);

            // Creates an area locally and inserts in in the DB
            CreateAreaCommand = new Command( async () =>
            {
                System.Diagnostics.Debug.WriteLine("create are acommand invoked");

                NewArea = new DropsArea()
                {
                    AreaName = AreaNameEntry,

                    Latitude = Latitude ?? 0.0,

                    Longitude = Longitude ?? 0.0,

                    Pins = new Dictionary<string, Dictionary<string, string>>(),

                    Subscribers = new Dictionary<string, string>()
                    {
                        {AllUsers.ActiveUser.Username, "owner"}
                    }
                };

                await CosmosDBService.InsertArea(NewArea);

                await Application.Current.MainPage.Navigation.PopAsync();
            });

            BindingContext = this;
        }

        // PROPERTIES
        public ObservableCollection<DropsArea> SubscribedAreas { get; set; }

        public DropsArea NewArea { get; set; }

        public ICommand CreateAreaCommand { get; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Label { get; set; }

        public string AreaNameEntry { get; set; }


        // EVENT HANDLER
        // it seems as thought the dissapearing elements only occurs on ios
        // also the options button does not fit on android, wtf
        // I tried to fix the issue by nesting the dissapearinng views in a stack view to no avail,
        // when the map isn't present the elements don't dissapear, which makes me think they were never absent, they were just covered up or pushed out of the way
        // going to try placing the elements above the map and see if that helps
        void OnMapClicked(object sender, MapClickedEventArgs e)
        // Look into migrating this functionality to the view model, probably going to be a command with extra databinding for the pin
        {
            map.Pins.Clear();

            Latitude = e.Position.Latitude;

            Longitude = e.Position.Longitude;

            Pin pin = new Pin()
            {   
                Position = new Position(Latitude ?? 0.0, Longitude ?? 0.0),

                Label = "Undeclared"
            };
            map.Pins.Add(pin);
        }

        // LIFECYCLE METHODS
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //AllAreas.SubscribedAreas = CosmosDBService.GetAreas();
        }
    }
}
