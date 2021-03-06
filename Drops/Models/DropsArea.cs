﻿using System;
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
        // PROPERTIES
        int dropsCreated;
        [JsonProperty("dropsCount")]
        public int DropsCreated
        {
            get => dropsCreated;
            set
            {
                if (dropsCreated == value)
                    return;

                dropsCreated = value;
            }
        }

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
            }
        }

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
            }
        }

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
            }
        }
    }
}