using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Drops.ViewModels
{
    public class DropListViewModel : BaseViewModel
    {
        // CONSTRUCTORS
        public DropListViewModel()
        {
            Pins = new ObservableCollection<DropsPin>();

            System.Diagnostics.Debug.WriteLine($"Hey there are {AllAreas.ActiveArea.Pins.Count} pins in the active area");

            // let's save this logic for use in mappage once we get that shit fixed
            //foreach (var pair in AllAreas.ActiveArea.Pins)
            //{
            //    // within value in the dictionary is another set of key value pairs containing strings representing a pins properties
            //    Dictionary<string, string> drop = pair.Value;

            //    System.Diagnostics.Debug.WriteLine("Adding pin NOW!!!");
            //    // the properties are captured and converted if necessary so they may be used to instantiate the pin they represent
            //    string label = drop["label"];

            //    double latitude = Convert.ToDouble(drop["latitude"]);

            //    double longitude = Convert.ToDouble(drop["longitude"]);

            //    Pins.Add(new Pin()
            //    {
            //        Label = label,

            //        Position = new Position(latitude, longitude)
            //    });
            //}

            foreach (var pair in AllAreas.ActiveArea.Pins)
            {
                // within value in the dictionary is another set of key value pairs containing strings representing a pins properties
                Pins.Add(new DropsPin(pair.Value["label"], pair.Key));
            }

            DeleteCommand = new Command((OnDeleteButtonTapped));

            CreateCommand = new Command((OnCreateButtonTapped));

            //GetCommand = new Command(() =>
            //{
            //    foreach (DropsArea area in SubscribedAreas)
            //    {
            //        System.Diagnostics.Debug.WriteLine(area.AreaName);
            //    }
            //});
        }

        // NESTED TYPES
        public class DropsPin
        {
            // CONSTRUCTORS
            public DropsPin(string label, string key)
            {
                Label = label;

                Key = key;
            }
            // PROPERTIES
            public string Label { get; set; }

            public string Key { get; set; }
        }

        // PROPERTIES
        // public Dictionary<string, Dictionary<string, string>> Pins { get; set; }
        //public Dictionary<string, Dictionary<string, string>> Pins { get; set; }

        public ObservableCollection<DropsPin> Pins { get; set; }

        public ICommand CreateCommand { get; }

        public ICommand DeleteCommand { get; }

        public ICommand GetCommand { get; }

        public string LabelEntry { get; set; }

        public string LatitudeEntry { get; set; }

        public string LongitudeEntry { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        // METHODS
        // let's save this logic for map page once we get that shit fixed
        //public async void OnDeleteButtonTapped(object obj)
        //{
        //    var pin = obj as Pin;

        //    Pins.Remove(pin);

        //    AllAreas.ActiveArea.Pins.Remove();

        //    //CosmosDBService.UpdateArea
        //}

        // we need to setup a way to also keep track of the key value for each pin in Pins so they can be interacted with in the db
        // perhaps a custom data type?
        public async void OnDeleteButtonTapped(object obj)
        {
            System.Diagnostics.Debug.WriteLine("delete button tapped");

            var pin = obj as DropsPin;

            Pins.Remove(pin);

            AllAreas.ActiveArea.Pins.Remove(pin.Key);

            await CosmosDBService.UpdateArea(AllAreas.ActiveArea);
        }

        public async void OnCreateButtonTapped()
        {
            Pin pin = new Pin
            {
                Label = LabelEntry,

                Position = new Position(Convert.ToDouble(LatitudeEntry), Convert.ToDouble(LongitudeEntry))

            };

            Pins.Add(new DropsPin(pin.Label, Convert.ToString(AllAreas.ActiveArea.Pins.Count)));

            string newKey = Convert.ToString(AllAreas.ActiveArea.Pins.Count);

            Dictionary<string, string> newValue = new Dictionary<string, string>()
            {
                { "label", pin.Label },

                { "latitude", Convert.ToString(pin.Position.Latitude) },

                { "longitude", Convert.ToString(pin.Position.Longitude) }
            };


            AllAreas.ActiveArea.Pins.Add(newKey, newValue);

            await CosmosDBService.UpdateArea(AllAreas.ActiveArea);
        }
    }
}