using System.Collections.Generic;
using System.Collections.ObjectModel;
using Drops.Services;
using Drops.Models;
using Xamarin.Forms.Maps;


namespace Drops.Static
{
    public static class AllAreas
    {
        // PROPERTIES
        public static DropsPin SelectedDrop { get; set; }

        public static ObservableCollection<DropsPin> ActiveAreaDropPins = new ObservableCollection<DropsPin>();

        public static ObservableCollection<DropsArea> Areas = new ObservableCollection<DropsArea>();

        public static DropsArea ActiveArea = new DropsArea()
        {
            Latitude = 41.7377780,

            Longitude = -111.8308330,

            AreaName = "default",

            Subscribers = new Dictionary<string, string>(),

            JSONPins = new Dictionary<string, Dictionary<string, string>>()
        };

        public static ObservableCollection<Pin> ActiveAreaJSONPins = new ObservableCollection<Pin>();

        // METHODS
        public static async void GetSubscribedAreas(ObservableCollection<DropsArea> areas)
        {
            // Iterates over the returned collection of DropsAreas
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
            // Iterates over the returned collection of DropsAreas
            foreach (DropsArea area in await CosmosDBService.GetAreas())
            {
                // Iterates over all the k-v pairs in the area's subscriber object
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
        public static async void GetActiveArea(DropsArea activeArea) 
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
                    activeArea = area; 

                    return;
                }
            }
        }

        public static async void UpdateActiveArea()
        {
            // updates the active area as long as the new name offered is not the reserved name of 'default'
            if(ActiveArea.AreaName != "default") { await CosmosDBService.UpdateArea(ActiveArea); }
        }

        public static async void UpdateActiveArea(DropsArea area)
        {
            // updates the area passed as an argument
            await CosmosDBService.UpdateArea(area);
        }
    }
}
