using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drops.Models;
using Drops.ViewModels;
using Drops.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

/*  ________________________________________________________
 *  |                                                       |
 *  |                  !!! ATENTION !!!                     |
 *  |                                                       |
 *  |   Just a note to anybody who's viewing this,          |
 *  |   I am aware that basically all of these members      |
 *  |   belong in the corresponding view model, however     |
 *  |   binding the map was proving to be a tad tricky so   |
 *  |   I'll be migrating this functionality to the view    |
 *  |   model in the future.                                |
 *  |                                                       |
 *  |                  !!! ATENTION !!!                     |
 *  |                                                       |
 *  |_______________________________________________________|
 */


namespace Drops.Views
{
    public partial class MapPage : ContentPage
    {
        // CONSTRUCTORS
        public MapPage()
        {
            InitializeComponent();

            
            System.Diagnostics.Debug.WriteLine($"Hey the active user is {AllUsers.ActiveUser.ActiveAreaName}");

            //ActiveArea = new DropsArea
            //{
            //    Pins = new Dictionary<string, Dictionary<string, string>>()
            //};

            // AllAreas.GetActiveArea(AllAreas.ActiveArea); // wot

            System.Diagnostics.Debug.WriteLine($"Hey there are {AllAreas.ActiveArea.Pins.Count} pins in the active area");

            //System.Diagnostics.Debug.WriteLine($"The name of the active area is {ActiveArea.AreaName}");

            //AllAreas.ActiveMap = map;

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.7377780, -111.8308330), Distance.FromMiles(1.0)));

           

            foreach (var pair in AllAreas.ActiveArea.Pins)
            {
                // within value in the dictionary is another set of key value pairs containing strings representing a pins properties
                Dictionary<string, string> drop = pair.Value;

                System.Diagnostics.Debug.WriteLine("Adding pin NOW!!!");
                // the properties are captured and converted if necessary so they may be used to instantiate the pin they represent
                string label = drop["label"];

                double latitude = Convert.ToDouble(drop["latitude"]);

                double longitude = Convert.ToDouble(drop["longitude"]);

                Pin pin = new Pin()
                {
                    Label = label,

                    Position = new Position(latitude, longitude)
                };

                //map.Pins.Add(pin);
                
            }

            //System.Diagnostics.Debug.WriteLine($"This area has {map.Pins.Count } pins");

            // BindingContext = this;
        }

        // PROPERTIES
        public Map ActiveMap { get; set; } //= Userbase.ActiveUser.ActiveArea.ActiveMap; // maybe for later

        public DropsArea ActiveArea { get; set; }

        public bool IsSafeToPopulateMapWithPins = AllUsers.IsSafeToPopulateMapWithPins;

        public ObservableCollection<Pin> AreaDrops { get; set; }

        //public ObservableCollection<DropsArea> 

        // METHODS
        void SwitchIsSafeToPopulateWithPins() { IsSafeToPopulateMapWithPins = !IsSafeToPopulateMapWithPins; }

        // EVENT HANDLERS
        public async void OnMapClicked(object sender, MapClickedEventArgs e)
        // Handles Map Clicks
        {
            var pin = new Pin()
            {
                Position = new Position(e.Position.Latitude, e.Position.Longitude),

                Label = "Unknown"
            };
            // The blank pin is placed on the map where the users touch input was registered
            // map.Pins.Add(pin);

            // An blank pin is instantiated
            //if (ActiveArea != null)
            //{
            //    var pin = new Pin()
            //    {
            //        Position = new Position(e.Position.Latitude, e.Position.Longitude),

            //        Label = "Unknown"
            //    };
            //    // The blank pin is placed on the map where the users touch input was registered
            //    map.Pins.Add(pin);


            //    string newPinLatitude = Convert.ToString(e.Position.Latitude);

            //    string newPinLongitude = Convert.ToString(e.Position.Longitude);

            //    string newPinKey = Convert.ToString(ActiveArea.Pins.Count - 1);

            //    Dictionary<string, string> newPinValue = new Dictionary<string, string>()
            //{
            //    { "label", "Unknown" },

            //    { "latitude", newPinLatitude },

            //    { "longitude", newPinLongitude }
            //};

            //    Dictionary<string, Dictionary<string, string>> jsonPin = new Dictionary<string, Dictionary<string, string>>()
            //{ { newPinKey, newPinValue } };


            //    ActiveArea.Pins.Add(newPinKey, newPinValue);

            //    await CosmosDBService.UpdateArea(ActiveArea); // stringToEscape is null wtf
            //}
            //else
            //{
            //    System.Diagnostics.Debug.WriteLine("Active area is null dumbass");
            //}

        }
    }
}