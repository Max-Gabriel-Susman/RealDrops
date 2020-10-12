using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Drops.Services;
using Drops.Models;
using Xamarin.Forms.Maps;


namespace Drops.Static
{
    public static class AllAreas
    {
        // switch to DropsArea
        // public static Area DefaultArea = new Area(41.7377780, -111.8308330, "Default Area", "Admin"); // make sure this guy doesn't get deyeeted
        // public static ObservableCollection<DropsArea> SubscribedAreas = new ObservableCollection<DropsArea>(); // lets include the default area in the collection initializer at a lat3r pooint in tm

        // FIELDS
        //public static ObservableCollection<DropsArea> subcribedAreas;

        // PROPERTIES
        public static DropsPin SelectedDrop { get; set; }

        public static ObservableCollection<DropsPin> ActiveAreaDropPins = new ObservableCollection<DropsPin>();

        public static ObservableCollection<DropsArea> Areas = new ObservableCollection<DropsArea>(); // we need to assign this to the areas gotten from the db

        public static DropsArea ActiveArea = new DropsArea()
        {
            Latitude = 41.7377780,

            Longitude = -111.8308330,

            AreaName = "default",

            Subscribers = new Dictionary<string, string>(),

            JSONPins = new Dictionary<string, Dictionary<string, string>>()
        };

        //public static Dictionary<string, Dictionary<string, string>> ActiveAreaJSONPins = new Dictionary<string, Dictionary<string, string>>();
        public static ObservableCollection<Pin> ActiveAreaJSONPins = new ObservableCollection<Pin>();

        public static Map ActiveMap { get; set; }

        // METHODS
        public static async void GetSubscribedAreas(ObservableCollection<DropsArea> areas)
        {
            foreach (DropsArea area in await CosmosDBService.GetAreas())
            {
                // Iterates over all the k-v pairs in an area's subscriber object
                foreach (var pair in area.Subscribers)
                {
                    // Checks if the key from the current iteration is equivalent to the User's username
                    if (pair.Key == AllUsers.ActiveUser.Username)
                    {
                        // If the key and username are equivalent then the area from the top level iteration is made accessible to the user
                        areas.Add(area);
                    }
                }
            }
        }

        public static async void GetOwnedAreas(ObservableCollection<DropsArea> areas)
        {
            foreach (DropsArea area in await CosmosDBService.GetAreas())
            {
                // Iterates over all the k-v pairs in an area's subscriber object
                foreach (var pair in area.Subscribers)
                {
                    // Checks if the key from the current iteration is equivalent to the User's username
                    if (pair.Key == AllUsers.ActiveUser.Username && pair.Value == "owner")
                    {
                        // If the key and username are equivalent then the area from the top level iteration is made accessible to the user
                        areas.Add(area);
                    }
                }
            }
        }

        // Assigns the area whose AreaName value matches the active user's ActiveAreaName value to the DropsArea argument
        public static async void GetActiveArea(DropsArea activeArea) // perhaps I should just invoke this earlier to account for it's latency?
        {
            System.Diagnostics.Debug.WriteLine($"This is the getactivearea method and the active area is {AllUsers.ActiveUser.ActiveAreaName}");
            // Iterates over all the areas in the DB
            foreach (DropsArea area in await CosmosDBService.GetAreas())
            {
                System.Diagnostics.Debug.WriteLine($"The area we're looking at is {area.AreaName}");
                // Checks if the current iterations area name is the same as the active user's activeareaname
                if (area.AreaName == AllUsers.ActiveUser.ActiveAreaName)
                {
                    System.Diagnostics.Debug.WriteLine("hey looky here we found the active area by name");
                    // assigns the current iteration to the area parameter 
                    activeArea = area; // it looks like it's working when I step through the code, let's just see if i can use it

                    return;
                }
            }
        }

        // Get an areas pins, pretty sure this is going to be dependant on the ability to know the active areas name
        public static async void GetActiveAreaPins(string activeArea, ObservableCollection<Pin> pins)
        {
            foreach(DropsArea area in await CosmosDBService.GetAreas())
            {
                if(area.AreaName == activeArea)
                {
                    foreach(var pair in area.JSONPins)
                    {
                        // first let's make sure we can pass the activearea name to mapcontrol as opposed to the active username
                    }
                }
            }
        }

        public static async void UpdateActiveArea()
        {
            // this means we should also prevent users from naming their areas as 'default' 
            if(ActiveArea.AreaName != "default") { await CosmosDBService.UpdateArea(ActiveArea); }
        }

        public static async void UpdateActiveArea(DropsArea area)
        {
            await CosmosDBService.UpdateArea(area);
        }
    }
}
