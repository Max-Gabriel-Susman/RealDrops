using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Drops.Models;
using Drops.Services;

namespace Drops.Views
{
    public partial class DropDetailViewPage : ContentPage
    {
        // CONSTRUCTORS
        public DropDetailViewPage()
        {
            InitializeComponent();

            SaveChangesCommand = new Command(async () =>
            {
                System.Diagnostics.Debug.WriteLine("savechangescommand invoked");

                string modifiedJSONPinLabel = NewLabelEntry;

                string modifiedJSONPinLatitude = Convert.ToString(Latitude);

                string modifiedJSONPinLongitude = Convert.ToString(Longitude);

                Dictionary<string, string> modifiedJSONPinValue = new Dictionary<string, string>()
                {
                    { "label", modifiedJSONPinLabel },

                    { "latitude", modifiedJSONPinLatitude },

                    { "longitude", modifiedJSONPinLongitude }
                };

                AllAreas.ActiveArea.JSONPins[ModifiedJSONPinKey] = modifiedJSONPinValue;

                await CosmosDBService.UpdateArea(AllAreas.ActiveArea);

                await Application.Current.MainPage.Navigation.PopAsync();
            });

            BindingContext = this;
        }

        // PROPERTIES
        public ICommand SaveChangesCommand { get; }

        public string NewLabelEntry { get; set; }

        public string ModifiedJSONPinKey { get; set; }

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
            map.Pins.Add(pin);
        }
    }
}
