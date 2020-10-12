using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Drops.Models;
using Drops.Services;
using Drops.Views;
using Drops.Static;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Drops.ViewModels
{
    // what the fuck I literally had it working
    // I need to verify if BaseViewModel is actually used later I don't want to  look foolish
    public class DropListViewModel : BaseViewModel, INotifyPropertyChanged // I think the verb is 'including' the interface, I should find out so I don't sound stupid
    {
        // FIELDS
        public event PropertyChangedEventHandler PropertyChanged;

        // CONSTRUCTORS
        public DropListViewModel()
        {
            // Pins = new ObservableCollection<DropsPin>();
            ActiveAreaDropPins = AllAreas.ActiveAreaDropPins; // for some reason the map stops rendering new pins after we've navigated away from it, is it just navigtion to this page or the others as well?

            //System.Diagnostics.Debug.WriteLine($"Hey there are {AllAreas.ActiveArea.JSONPins.Count} pins in the active area");

            // populates the local pin collection with jsonpins
            // foreach (var pair in AllAreas.ActiveArea.JSONPins)
            System.Diagnostics.Debug.WriteLine($"Hey you AllArea.ActiveAreaJSONPins.count is {AllAreas.ActiveAreaJSONPins.Count}");

            //int key = 0;

            foreach (var pair in AllAreas.ActiveArea.JSONPins) // maybe I can try and use this logic in droplistviewpage
            {
                // within value in the dictionary is another set of key value pairs containing strings representing a pins properties
                Dictionary<string, string> JSONPin = pair.Value;

                //System.Diagnostics.Debug.WriteLine("Adding pin NOW!!!");
                // the properties are captured and converted if necessary so they may be used to instantiate the pin they represent
                string label = JSONPin["label"];

                string key = pair.Key;

                string latitude = JSONPin["latitude"];

                string longitude = JSONPin["longitude"];

                ActiveAreaDropPins.Add(new DropsPin
                {
                    Key = key,

                    Latitude = latitude,

                    Longitude = longitude,

                    Label = label
                });

                // in order to allow for global deletion we need to have the key of the item, so either we're going to have to use droppins to populate the listview or event args in the even handler

                //DropsPin pin = new DropsPin()
                //{
                //    Label = label,

                //    Position = new Position(latitude, longitude)
                //};

                // AllAreas.ActiveAreaJSONPins.Add(pin); // this guy's yelling because he needs a kv as opposed to an element
                //ActiveAreaJSONPins.Add(pin); // this guy's yelling because he needs a kv as opposed to an element
            }

            //foreach (Pin pin in AllAreas.ActiveAreaJSONPins)
            //{
            //    // within value in the dictionary is another set of key value pairs containing strings representing a pins properties
            //    // Pins.Add(new DropsPin(pair.Value["label"], pair.Key));
            //    ActiveAreaJSONPins.Add(pin);
            //}

            System.Diagnostics.Debug.WriteLine($"Hey you ActiveAreaJSONPins.count is {ActiveAreaDropPins.Count}");

            DeleteCommand = new Command((OnDeleteButtonTapped));

           
        }

        // NESTED TYPES - could the issues I'm dealing with be due to the fact that this is a nested type?
        //public class DropsPin
        //{
        //    public string Key { get; set; }

        //    public string Latitude { get; set; }

        //    public string Longitude { get; set; }

        //    public string Label { get; set; }
        //}


        // PROPERTIES

        // because of way this was implemented in the base class it had to be overriden to facillitate my current practices
         // would this event handler be considered a field, property, or something else entirely?
        // public new event PropertyChangedEventHandler PropertyChanged; // would this event handler be considered a field, property, or something else entirely?

        public ObservableCollection<DropsPin> Pins { get; set; }

        public ObservableCollection<DropsPin> ActiveAreaDropPins { get; set; }

        //public ObservableCollection<Pin> ActiveAreaJSONPins
        //{
        //    set
        //    {
        //        // checks if the underlying value is equivalent to 'set's 'value'
        //        if (AllAreas.ActiveAreaJSONPins != value)
        //        {
        //            AllAreas.ActiveAreaJSONPins = value;

        //            // I honestly have no idea how this works, I need to better understand it since it's so ubiquitous
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ActiveAreaJSONPins"));
        //        }
        //    }

        //    get => AllAreas.ActiveAreaJSONPins;
        //}
        

        public ICommand DeleteCommand { get; }

        public string LabelEntry { get; set; }

        public string LatitudeEntry { get; set; }

        public string LongitudeEntry { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        // METHODS
        //void OnDropSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    Application.Current.MainPage.Navigation.PushAsync(new DropDetailViewPage());
        //}

        public async void OnDeleteButtonTapped(object obj)
        {
            System.Diagnostics.Debug.WriteLine("delete button tapped");

            var dropsPin = obj as DropsPin;

            //double pinLatitude = Convert.ToDouble(dropsPin.Latitude);

            //double pinLongitude = Convert.ToDouble(dropsPin.Longitude);

            //Pin pin = new Pin()
            //{
            //    Label = dropsPin.Label,

            //    Position = new Position(pinLatitude, pinLongitude)
            //};

            // why the hell is there a triple redundancy?

            ActiveAreaDropPins.Remove(dropsPin); // we gotta change the itemsource of the listview
            // maybe instead I can make a static method that ammends the static value and the  db simultaneously
            // first I think we should restore thee ability to place pins on map
            // we can place pins, buy once we delete a pin in droplist view they are either no longer placing or just not rendering

            

            AllAreas.ActiveArea.JSONPins.Remove(dropsPin.Key); // null reference thrown after i deleted a shit ton of pins?

            await CosmosDBService.UpdateArea(AllAreas.ActiveArea);

            System.Diagnostics.Debug.WriteLine($"This area has {AllAreas.ActiveArea.DropsCreated} drops in it");
        }
    }
}