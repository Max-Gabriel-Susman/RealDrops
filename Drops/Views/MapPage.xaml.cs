using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drops.Models;
using Drops.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace Drops.Views
{
    public partial class MapPage : ContentPage
    {
        // CONSTRUCTORS
        public MapPage()
        {
            InitializeComponent();
            // BindingContext = new MainPageViewModel();
            ActiveArea = Userbase.ActiveUser.ActiveArea;

            DefaultArea = Userbase.DefaultArea;
            // Centers map on Logan Utah on App entry, in the future the map will be centered on the users location on app entry
            if (ActiveArea == null)
            {
                // This Navigates to the the default area, we shuld use location tracking to make it follow the user
                dropMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position( DefaultArea.Latitude, DefaultArea.Latitude), Distance.FromMiles(DefaultArea.ViewHeight)));
            }
            else
            {
                dropMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(ActiveArea.Latitude, ActiveArea.Longitude), Distance.FromMiles(ActiveArea.ViewHeight)));
            }


            //// Pulls the list of drops from the database
            //List<Drop> drops = App.Database.GetDropsAsync().Result;

            //// Populates the map with the list of drops pulled from the database
            //for(int i = 0; i < drops.Count; i++)
            //{
            //    // Instantiates a pin that will represent a drop from the database
            //    dropMap.Pins.Add(new Pin {

            //        Position = new Position(drops[i].Latitude, drops[i].Longitude),

            //        Label = drops[i].Label

            //    });
            //}

            BindingContext = this;
            // BindingContext = new MapPageViewModel();
        }

        // PROPERTIES
        public Area ActiveArea { get; }

        public Area DefaultArea { get; }

        // EVENT HANDLERS
        async void OnSearchBarButtonClicked(object sender, EventArgs e)
        // Handles Search button clicks
        {
            // Adds a SearchResultsListViewPage to the stack
            await Navigation.PushAsync(new SearchResultsListViewPage
            {

            });
        }

        
        async void OnOptionsButtonClicked(object sender, EventArgs e)
        // Handles Options button clicks
        {
            // Adds a OptionsListViewPage to the stack
            await Navigation.PushAsync(new OptionsListViewPage
            {
                
            });
        }

        
        async void OnDropsButtonClicked(object sender, EventArgs e)
        // Handles Drops Button CLicks
        {

            // Adds a DropListViewPage to the stack
            await Navigation.PushAsync(new DropListViewPage
            {
                // let's save all the drops
                
                // App.Database.SaveDropAsync();
            });
        }

        
        async void OnPeopleButtonClicked(object sender, EventArgs e)
        // Handles People Button Clicks
        {
            // Adds a PeopleListViewPage to the stack
            await Navigation.PushAsync(new PeopleListViewPage
            {
                
            });
        }

        async void OnAreasButtonClicked(object sender, EventArgs e)
        // Handles Areas Button Clicks
        {

            // Adds an AreaListViewPage to the stack
            await Navigation.PushAsync(new AreaListViewPage
            {
               

                
                
            });
        }

        
        private void OnMapClicked(object sender, MapClickedEventArgs e)
        // Handles Map Clicks
        {
            // An blank pin is instantiated
            var pin = new Pin()
            {
                
                Position = new Position(e.Position.Latitude, e.Position.Longitude),

                Label = "Unknown"

            };

            // The blank pin is placed on the map where the users touch input was registered
            dropMap.Pins.Add(pin);

            DropMap.Drops.Add(new Drop(pin));

            
        }
    }
}