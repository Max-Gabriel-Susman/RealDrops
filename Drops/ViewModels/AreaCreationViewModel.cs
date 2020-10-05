using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace Drops.ViewModels
{
    public class AreaCreationViewModel 
    {
        // CONSTRUCTORS
        public AreaCreationViewModel()
        {
            Pin pin = new Pin();
            


            AreaNameEntry = "";

            // EVENT HANDLERS
            //CreateAreaCommand = new Command(() =>
            //{
            //    NewArea = new DropsArea()
            //    {
            //        Area = AreaNameEntry,

            //        //Latitude = , // let's use a pin placed bythe user to get the latitude and the longitude for the area

            //        //Latitude = ,

            //        Pins = new Dictionary<string, Dictionary<string, string>>(),

            //        Subscribers = new Dictionary<string, string>()
            //        {
            //            // use the collection initializer to add an item representing the user that created the area as it's owner
            //        }
            //    };


            //    CosmosDBService.InsertArea(NewArea);

            //    Application.Current.MainPage.Navigation.PopAsync();
            //});
        }

        // PROPERTIES
        //public ICommand CreateAreaCommand { get; }

        public DropsArea NewArea { get; set; }

        public string AreaNameEntry { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Label { get; set; } // is this even necessary?

    }
}
