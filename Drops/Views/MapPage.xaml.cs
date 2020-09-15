﻿using System;
using System.Collections.Generic;

// I'll leave them for now but i don't think I'll end up needing these 4 namespaces
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Drops.Models;

namespace Drops.Views
{
    public partial class MapPage : ContentPage
    {
        // MARK: - Constructors
        public MapPage()
        {

            InitializeComponent();

            // Centers map on Logan Utah on App entry, in the future the map will be centered on the users location on app entry
            dropMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.7377780, -111.8308330), Distance.FromMiles(1.0)));

            // Pulls the list of drops from the database
            List<Drop> drops = App.Database.GetDropsAsync().Result;

            // Populates the map with the list of drops pulled from the database
            for(int i = 0; i < drops.Count; i++)
            {
                // Instantiates a pin that will represent a drop from the database
                dropMap.Pins.Add(new Pin {

                    Position = new Position(drops[i].Latitude, drops[i].Longitude),

                    Label = drops[i].Label

                });
            }
        }

        // MARK: - Methods
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

            
            await Navigation.PushAsync(new DropListViewpage
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

            // Creates a drop that will be used to represent the new pin inside of the database
            App.Database.SaveDropAsync(new Drop(pin));
        }
    }
}