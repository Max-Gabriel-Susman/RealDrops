using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Drops.Models;
using Drops.Static;
using Drops.Services;

namespace Drops.Views
{
    public partial class DropDetailViewPage : ContentPage
    {
        // CONSTRUCTORS
        public DropDetailViewPage()
        {
            InitializeComponent();



            // I don't think I'll need this command anymore
            SaveChangesCommand = new Command(async () =>
            {
                //System.Diagnostics.Debug.WriteLine("savechangescommand invoked");

                //string modifiedJSONPinLabel = NewLabelEntry;

                //string modifiedJSONPinLatitude = Convert.ToString(Latitude);

                //string modifiedJSONPinLongitude = Convert.ToString(Longitude);

                //Dictionary<string, string> modifiedJSONPinValue = new Dictionary<string, string>()
                //{
                //    { "label", modifiedJSONPinLabel },

                //    { "latitude", modifiedJSONPinLatitude },

                //    { "longitude", modifiedJSONPinLongitude }
                //};

                //AllAreas.ActiveArea.JSONPins[ModifiedJSONPinKey] = modifiedJSONPinValue;

                //await CosmosDBService.UpdateArea(AllAreas.ActiveArea);

                //await Application.Current.MainPage.Navigation.PopAsync();
            });

            EditDropCommand = new Command( async () =>
            {
                System.Diagnostics.Debug.WriteLine("EDITDROPCOMMAND INVOKED");

                

                if (ModifiedPin != null)
                {
                    System.Diagnostics.Debug.WriteLine("MODIFIED PIN WAS NOT NULL");

                    string label = ModifiedPin.Label;

                    string latitude = $"{ModifiedPin.Position.Latitude}";

                    string longitude = $"{ModifiedPin.Position.Longitude}";

                    Pin pin = new Pin()
                    {
                        Label = label,

                        Position = new Position(ModifiedPin.Position.Latitude, ModifiedPin.Position.Longitude)
                    };

                    AllAreas.SelectedDrop.Latitude = latitude;

                    AllAreas.SelectedDrop.Longitude = longitude;

                    AllAreas.SelectedDrop.Label = label;

                    AllAreas.ActiveAreaDropPins.Add(AllAreas.SelectedDrop);

                    //AllAreas.ActiveAreaJSONPins.Add(pin); // Might no longer be necessary?

                    AllAreas.ActiveArea.JSONPins[AllAreas.SelectedDrop.Key] = new Dictionary<string, string>()
                    {
                        { "label", label },

                        { "latitude", latitude },

                        { "longitude", longitude }
                    };

                    await CosmosDBService.UpdateArea(AllAreas.ActiveArea);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("MODIFIED PIN WAS NULL");
                }
            });

            BindingContext = this;
        }

        // PROPERTIES
        public ICommand SaveChangesCommand { get; }

        public ICommand EditDropCommand { get; }

        public string NewLabelEntry { get; set; }

        public Pin ModifiedPin { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        // METHODS
        void OnMapClicked(object sender, MapClickedEventArgs e)
        // Look into migrating this functionality to the view model, probably going to be a command with extra databinding for the pin
        {
            map.Pins.Clear();

            Latitude = e.Position.Latitude;

            Longitude = e.Position.Longitude;

            Pin pin = new Pin()
            {
                Position = new Position(Latitude ?? 0.0, Longitude ?? 0.0),

                Label = "New Drop Location!"
            };

            ModifiedPin = pin;

            map.Pins.Add(pin);

            
        }
    }
}
