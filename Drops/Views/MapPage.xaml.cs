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
        // FIELDS
        private double DefaultLatitude = 41.7377780;

        private double DefaultLongitude = -111.8308330;

        private double DefaultViewHeight = 1.0;

        // CONSTRUCTORS
        public MapPage()
        {
            InitializeComponent();
            // BindingContext = new MainPageViewModel();
            ActiveArea = Userbase.ActiveUser.ActiveArea;
            // Centers map on Logan Utah on App entry, in the future the map will be centered on the users location on app entry
            if (ActiveArea == null)
            {
                // This Navigates to the the default area 
                dropMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.7377780, -111.8308330), Distance.FromMiles(1.0)));
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
        }

        // Properties
        public Area ActiveArea { get; set; }

        // EVENT HANDLERS
        async void OnSearchBarButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchResultsListViewPage
            {

            });
        }

        // Handles Navigation to OptionsListViewPage
        async void OnOptionsButtonClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new OptionsListViewPage
            {
                
            });
        }

        // Handles Navigation to PinsListViewPage
        async void OnPinsButtonClicked(object sender, EventArgs e)
        {

            
            await Navigation.PushAsync(new DropListViewPage
            {
                // let's save all the drops
                
                // App.Database.SaveDropAsync();
            });
        }

        // Handles Switching between satellite(Hybrid) and street map views INACTIVE
        async void OnPeopleButtonClicked(object sender, EventArgs e) {

            await Navigation.PushAsync(new PeopleListViewPage
            {
                
            });
        }

        

        async void OnAreasButtonClicked(object sender, EventArgs e)
        {
            

            await Navigation.PushAsync(new AreaListViewPage
            {
               

                
                
            });
        }

        // Handles Drop Creation
        void OnMapClicked(object sender, MapClickedEventArgs e)
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