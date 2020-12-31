using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Drops.Models;
using Drops.Services;
using Drops.Views;
using Drops.SharedResources;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Drops.ViewModels
{
    public class DropListViewModel : BaseViewModel, INotifyPropertyChanged
    {
        // FIELDS
        public event PropertyChangedEventHandler PropertyChanged;

        // CONSTRUCTORS
        public DropListViewModel()
        {
            AreasMeta.ActiveAreaDropPins.Clear(); 

            ActiveAreaDropPins = AreasMeta.ActiveAreaDropPins;

            foreach (var pair in AreasMeta.ActiveArea.JSONPins) 
            {
                Dictionary<string, string> JSONPin = pair.Value;

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

            DeleteCommand = new Command(OnDeleteButtonTapped);
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

        // EVENT HANDLERS
        public async void OnDeleteButtonTapped(object obj)
        {
            var dropsPin = obj as DropsPin;

            ActiveAreaDropPins.Remove(dropsPin);

            AreasMeta.ActiveArea.JSONPins.Remove(dropsPin.Key); 

            await CosmosDBService.UpdateArea(AreasMeta.ActiveArea);
        }
    }
}