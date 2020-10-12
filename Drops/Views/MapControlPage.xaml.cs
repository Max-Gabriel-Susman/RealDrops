using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.Static;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace Drops.Views
{
    public partial class MapControlPage : ContentPage, INotifyPropertyChanged
    {
        // CONSTRUCTORS
        public MapControlPage()
        {
            InitializeComponent();

            foreach(DropsArea area in AllAreas.Areas) 
            {
                // for Registration flow 'activeuser' is null
                if(area.AreaName == AllUsers.ActiveUser.ActiveAreaName)
                {
                    AllAreas.ActiveArea = area;

                    System.Diagnostics.Debug.WriteLine("and active area was assigned");
                }
            }

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.7377780, -111.8308330), Distance.FromMiles(1.0)));

            System.Diagnostics.Debug.WriteLine($"There are {AllAreas.ActiveAreaJSONPins.Count} pins in the active area ");

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
        public ICommand DropListCommand { get; }

        public ICommand AreaListCommand { get; }

        public ICommand PeopleListCommand { get; }

        public ICommand LogoutCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged; 

        public ObservableCollection<Pin> ActiveAreaJSONPins
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

        // Handles Map Clicks
        public void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            // Prevents 
            if(AllAreas.ActiveArea.AreaName != "default")
            {
                var pin = new Pin()
                {
                    Position = new Position(e.Position.Latitude, e.Position.Longitude),

                    Label = "Unknown"
                };

                // newKey and newValue are defined using values from pin's properties and OnMapClicked's args
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

                AllAreas.ActiveArea.DropsCreated++;

                AllAreas.UpdateActiveArea();


            }
            else
            {
                System.Diagnostics.Debug.WriteLine("You've attempted to add a pin to the default area, that's not an option.");
                // Give the user some feed back when this occurs
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            System.Diagnostics.Debug.WriteLine("you are now entering the map bitch");

            // Clears Pins to prevent Duplicate Pins after the Collection is Populated
            AllAreas.ActiveAreaJSONPins.Clear();

            // Populates the collection with pins
            foreach (var pair in AllAreas.ActiveArea.JSONPins) 
            {
                Dictionary<string, string> drop = pair.Value;

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

                AllAreas.ActiveAreaJSONPins.Add(pin);
            }
        }
    }
}
