using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Drops.Views
{
    public partial class AreaCreationDetailView : ContentPage
    {
        // CONSTRUCTORS
        public AreaCreationDetailView()
        {
            InitializeComponent();

            CreateCommand = new Command(OnCreateButtonClicked);

            BindingContext = this;

            Pin = new Pin();

            AreaNameEntry = "";

            // BindingContext = new AreaCreationViewModel();
        }

        // PROPERTIES
        public ICommand CreateCommand { get; }

        public Pin Pin { get; set; } 

        public string AreaNameEntry { get; set; }

        // EVENT HANDLERS

        // Clears previous pin and then creates a new one where the user has tapped
        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            // Clears previous pin if present
            dropMap.Pins.Clear();

            // Instantiates a new pin
            Pin = new Pin()
            {
                Position = new Position(e.Position.Latitude, e.Position.Longitude),

                Label = "Undeclared"
            };

            // Stores the new pin
            dropMap.Pins.Add(Pin);
        }

        // Stores user input in the AreaNameEntry in a local Property
        void OnAreaNameEntryChanged(object sender, TextChangedEventArgs e)
        {
            AreaNameEntry = e.NewTextValue;

            System.Diagnostics.Debug.WriteLine(AreaNameEntry);
        }

        // Creates an area and pops the AreaCreationDetailView from the stack
        public void OnCreateButtonClicked(object obj)
        {
            // A new area is created and added to ActiveUser's OwnedArea Collectio
            System.Diagnostics.Debug.WriteLine(AreaNameEntry);

            if(true)
            {
                Userbase.ActiveUser.CreateArea(Pin.Position.Latitude, Pin.Position.Longitude, AreaNameEntry);

                Navigation.PopAsync();
            }
            else
            {
                // Give feedback for Invalid Area Creation
            }



        }
    }
}
