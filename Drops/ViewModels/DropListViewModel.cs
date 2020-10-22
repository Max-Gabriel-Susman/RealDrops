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
        // I should probably stop misusing commands and swap them for methods where appropriate

        // FIELDS
        public event PropertyChangedEventHandler PropertyChanged;

        // CONSTRUCTORS
        public DropListViewModel()
        {
            // all this functionality needs to be reintegrated
            AreasMeta.ActiveAreaDropPins.Clear(); // I think we'll handle clearing and instantiating in one move instead

            ActiveAreaDropPins = AreasMeta.ActiveAreaDropPins;

            // vm.PopulateItemSource();

            // System.Diagnostics.Debug.WriteLine($"The length of ACTIVEAREADROPPINS is {vm.ActiveAreaDropPins.Count} AS seen in droplistviewpage");

            System.Diagnostics.Debug.WriteLine("POPULATEITEMSOURCE INVOKED");

            //if(ActiveAreaDropPins.Count == 0)
            //{
                foreach (var pair in AreasMeta.ActiveArea.JSONPins) // maybe I can try and use this logic in droplistviewpage
                {
                    System.Diagnostics.Debug.WriteLine("ADDING DROPIN NOW");

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
                }
            // }


            // has List.Length been deprecated? why was it in the codecademy tutorial?
            System.Diagnostics.Debug.WriteLine($"The length of ACTIVEAREADROPPINS is {ActiveAreaDropPins.Count}");
            // when to use debug statements as opposed to breakpoints as opposed to Trace statments

            DeleteCommand = new Command((OnDeleteButtonTapped));  
        }

        // PROPERTIES
        public ObservableCollection<DropsPin> Pins { get; set; }

        public ObservableCollection<DropsPin> ActiveAreaDropPins { get; set; }

        public ICommand DeleteCommand { get; }

        public string LabelEntry { get; set; }

        public string LatitudeEntry { get; set; }

        public string LongitudeEntry { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        // METHODS
        public async void OnDeleteButtonTapped(object obj)
        {
            System.Diagnostics.Debug.WriteLine("delete button tapped");

            var dropsPin = obj as DropsPin;

            ActiveAreaDropPins.Remove(dropsPin);

            AreasMeta.ActiveArea.JSONPins.Remove(dropsPin.Key); 

            await CosmosDBService.UpdateArea(AreasMeta.ActiveArea);

            System.Diagnostics.Debug.WriteLine($"This area has {AreasMeta.ActiveArea.DropsCreated} drops in it");
        }

        //public void PopulateItemSource()
        //{
        //    System.Diagnostics.Debug.WriteLine("POPULATEITEMSOURCE INVOKED");

        //    foreach (var pair in AllAreas.ActiveArea.JSONPins) // maybe I can try and use this logic in droplistviewpage
        //    {
        //        System.Diagnostics.Debug.WriteLine("ADDING DROPIN NOW");

        //        // within value in the dictionary is another set of key value pairs containing strings representing a pins properties
        //        Dictionary<string, string> JSONPin = pair.Value;

        //        //System.Diagnostics.Debug.WriteLine("Adding pin NOW!!!");
        //        // the properties are captured and converted if necessary so they may be used to instantiate the pin they represent
        //        string label = JSONPin["label"];

        //        string key = pair.Key;

        //        string latitude = JSONPin["latitude"];

        //        string longitude = JSONPin["longitude"];

        //        ActiveAreaDropPins.Add(new DropsPin
        //        {
        //            Key = key,

        //            Latitude = latitude,

        //            Longitude = longitude,

        //            Label = label
        //        });
        //    }
            

        //    // has List.Length been deprecated? why was it in the codecademy tutorial?
        //    System.Diagnostics.Debug.WriteLine($"The length of ACTIVEAREADROPPINS is {ActiveAreaDropPins.Count}");
        //    // when to use debug statements as opposed to breakpoints as opposed to Trace statments
        //}

    }
}