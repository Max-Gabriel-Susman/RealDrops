using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.Services;
using Drops.Static;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

// If we have't moved this content to the view mdoel by the time we're showing this off we should move the disclaimer here

namespace Drops.Views
{
    public partial class MapControlPage : ContentPage, INotifyPropertyChanged
    {
        // FIELDS
        //DateTime dateTime; // this is the property being monitored
        //public Dictionary<string, Dictionary<string, string>> jsonPins;
        // public ObservableCollection<Pin> activeAreaJSONPins;
        // let's switch back to the observablecollection paradigm becauase I actually had that working

        // CONSTRUCTORS
        public MapControlPage()
        {
            InitializeComponent();

            foreach(DropsArea area in AllAreas.Areas) 
            {
                if(area.AreaName == AllUsers.ActiveUser.ActiveAreaName)
                {
                    AllAreas.ActiveArea = area;

                    System.Diagnostics.Debug.WriteLine("and active area was assigned");
                }
            }

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.7377780, -111.8308330), Distance.FromMiles(1.0)));

            // ActiveAreaJSONPins = new Dictionary<string, Dictionary<string, string>>();
            //ActiveAreaJSONPins = new ObservableCollection<Pin>();

            //foreach (var pair in AllAreas.ActiveArea.JSONPins) // maybe I can try and use this logic in droplistviewpage
            //{
            //    // within value in the dictionary is another set of key value pairs containing strings representing a pins properties
            //    Dictionary<string, string> drop = pair.Value;

            //    //System.Diagnostics.Debug.WriteLine("Adding pin NOW!!!");
            //    // the properties are captured and converted if necessary so they may be used to instantiate the pin they represent
            //    string label = drop["label"];

            //    double latitude = Convert.ToDouble(drop["latitude"]);

            //    double longitude = Convert.ToDouble(drop["longitude"]);

            //    Pin pin = new Pin()
            //    {
            //        Label = label,

            //        Position = new Position(latitude, longitude)
            //    };

            //    AllAreas.ActiveAreaJSONPins.Add(pin); // this guy's yelling because he needs a kv as opposed to an element
            //}


            // System.Diagnostics.Debug.WriteLine($"There are {ActiveAreaJSONPins.Count} pins in the active area ");
            System.Diagnostics.Debug.WriteLine($"There are {AllAreas.ActiveAreaJSONPins.Count} pins in the active area ");



            // We're going to need at least some of this logic to populate the map with pins from the db


            //this.DateTime = DateTime.Now; // property is assigned it's initial value

            //// starts a recurring timer using the device's clock capabilities
            //Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            //{
            //    this.DateTime = DateTime.Now;
            //    return true;
            //});

            // EVENT HANDLERS
            DropListCommand = new Command(() =>
            {
                // Application.Current.MainPage.Navigation.PushAsync(new DropListViewPage());
                Application.Current.MainPage.Navigation.PushAsync(new DropListViewPage());
            });

            AreaListCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new AreaListViewPage());
            });

            PeopleListCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new PeopleListViewPage());
            });

            LogoutCommand = new Command(() =>
            {
                Navigation.InsertPageBefore(new LoginPage(), this);

                Navigation.PopAsync();
            });

            BindingContext = this;

            System.Diagnostics.Debug.WriteLine($"This area has {AllAreas.ActiveArea.DropsCreated} drops in it");
        }

        // PROPERTIES
        //public string ActiveAreaName { get; set; }
        
        public ICommand DropListCommand { get; }

        public ICommand AreaListCommand { get; }

        public ICommand PeopleListCommand { get; }

        public ICommand LogoutCommand { get; }

        //public ICommand ActivateAreaCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged; // this event handler

        // are we actually using this one anymore?
        public DropsArea ActiveArea
        {
            set
            {
                if (AllAreas.ActiveArea != value)
                {
                    AllAreas.ActiveArea = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ActiveArea"));
                }
            }
            get => AllAreas.ActiveArea;
        }

        // we are going to need to convert between Dictionary<string, Dictionary<string, string>> and ObservableCollection<Pin>
        // what are the naming conventions for static classes in c# and how can i better adhere to them?
        // public Dictionary<string, Dictionary<string, string>> ActiveAreaJSONPins//ObservableCollection<Pin> Pins
        public ObservableCollection<Pin> ActiveAreaJSONPins//ObservableCollection<Pin> Pins
        {
            set
            {
                
                if (AllAreas.ActiveAreaJSONPins != value)
                {
                    AllAreas.ActiveAreaJSONPins = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ActiveAreaJSONPins"));
                }
            }
            get => AllAreas.ActiveAreaJSONPins;
        }

        public void OnMapClicked(object sender, MapClickedEventArgs e)
        // Handles Map Clicks
        {
            // A pin is instantiated using the args from OnMapClicked
            var pin = new Pin()
            {
                Position = new Position(e.Position.Latitude, e.Position.Longitude),

                Label = "Unknown"
            };

            // newKey and newValue are defined using values from pin's properties and OnMapClicked's args
            AllAreas.ActiveArea.DropsCreated++;

            string newKey = Convert.ToString(AllAreas.ActiveArea.DropsCreated);

            System.Diagnostics.Debug.WriteLine(AllAreas.ActiveArea.DropsCreated);

            Dictionary<string, string> newValue = new Dictionary<string, string>()
            {
                { "label", pin.Label },

                { "latitude", Convert.ToString(pin.Position.Latitude) },

                { "longitude", Convert.ToString(pin.Position.Longitude) }
            };

            
            AllAreas.ActiveAreaJSONPins.Add(pin);

            AllAreas.ActiveArea.JSONPins.Add(newKey, newValue);

            AllAreas.UpdateActiveArea(); // this assumes that activeareaJsonpins is ultimately referenced to AllAreas.ActiveArea.Pins

            // System.Diagnostics.Debug.WriteLine("pin added to everything babe");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            System.Diagnostics.Debug.WriteLine("you are now entering the map bitch");

            // this works let's handle pins refreshing here
            AllAreas.ActiveAreaJSONPins.Clear();

            foreach (var pair in AllAreas.ActiveArea.JSONPins) // maybe I can try and use this logic in droplistviewpage
            {
                // within value in the dictionary is another set of key value pairs containing strings representing a pins properties
                Dictionary<string, string> drop = pair.Value;

                //System.Diagnostics.Debug.WriteLine("Adding pin NOW!!!");
                // the properties are captured and converted if necessary so they may be used to instantiate the pin they represent
                string key = pair.Key;

                string label = drop["label"];

                string latitude = drop["latitude"];

                string longitude = drop["longitude"];

                double doubleLatitude = Convert.ToDouble(drop["latitude"]);

                double doubleLongitude = Convert.ToDouble(drop["longitude"]);

                Pin pin = new Pin()
                {
                    Label = label,

                    Position = new Position(doubleLatitude, doubleLongitude)
                };

                DropsPin dropsPin = new DropsPin()
                {
                    Key = key,

                    Latitude = latitude,

                    Longitude = longitude,

                    Label = label
                };

                AllAreas.ActiveAreaJSONPins.Add(pin); // this guy's yelling because he needs a kv as opposed to an element

                AllAreas.ActiveAreaDropPins.Add(dropsPin);

                AllAreas.ActiveArea.DropsCreated++;
            }
        }
    }
}
