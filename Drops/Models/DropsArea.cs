using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamarin.Forms.Maps;


namespace Drops.Models
{
    public class DropsArea
    {
        // Probably going to get rid of it because I don't think we need it in this paradigm
        //// CONSTRUCTORS
        //public DropsArea(string id,
        //                 string area,
        //                 double latitude,
        //                 double longitude,
        //                 Dictionary<string, string> subscribers,
        //                 Dictionary<string, Dictionary<string, string>> pins)
        //{
        //    ID = id;

        //    Owner = owner;

        //    Area = area;

        //    Latitude = latitude;

        //    Longitude = longitude;

        //    Pins = pins;
        //}

        // PROPERTIES
        public event PropertyChangedEventHandler PropertyChanged;
        
        string id;
        [JsonProperty("id")]
        public string ID
        {
            get => id;
            set
            {
                if (id == value)
                    return;

                id = value;

                HandlePropertyChanged();
            }
        }

        double latitude;
        [JsonProperty("latitude")]
        public double Latitude
        {
            get => latitude;
            set
            {
                if (latitude == value)
                    return;

                latitude = value;

                HandlePropertyChanged();
            }
        }

        double longitude;
        [JsonProperty("longitude")]
        public double Longitude
        {
            get => longitude;
            set
            {
                if (longitude == value)
                    return;

                longitude = value;

                HandlePropertyChanged();
            }
        }

        // perhaps the fact that subscribers is in fact a dictionary<string, string> and not an observable collection is what's impeding it's accessiblilty 
        Dictionary<string, string> subscribers;
        [JsonProperty("subscribers")]
        public Dictionary<string, string> Subscribers
        {
            get => subscribers;
            set
            {
                if (subscribers == value)
                    return;

                subscribers = value;

                HandlePropertyChanged();
            }
        }

        string areaName;
        [JsonProperty("area")]
        public string AreaName
        {
            get => areaName;
            set
            {
                if (areaName == value)
                    return;

                areaName = value;

                HandlePropertyChanged();
            }
        }

        // array of arrays of strings
        Dictionary<string, Dictionary<string, string>> jsonPins;
        [JsonProperty("pins")]
        public Dictionary<string, Dictionary<string, string>> JSONPins 
        {
            get => jsonPins;
            set
            {
                if (jsonPins == value)
                    return;

                jsonPins = value;

                HandlePropertyChanged();
            }
        }

        // METHODS
        void HandlePropertyChanged([CallerMemberName] string propertyName = "")
        {
            var eventArgs = new PropertyChangedEventArgs(propertyName);

            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}