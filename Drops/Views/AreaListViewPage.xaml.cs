using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Drops.Models;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class AreaListViewPage : ContentPage
    {
      
        // Constructor
        public AreaListViewPage()
        {
            InitializeComponent();

            AllAreas = new ObservableCollection<Area>()
            {
                new Area(0.0, 0.0, "deez"),

                new Area(0.0, 0.0, "robot"),

                new Area(0.0, 0.0, "nutz")
            };

            BindingContext = this;
        }

        // Properties
        public User ActiveUser { get; set; }

        public ObservableCollection<Area> AllAreas { get; set; }

        public ObservableCollection<string> AllAreaNames { get; set; }


        //public ObservableCollection<Area> Areas { get; set; }

        // Methods
        //async voi=


        async void OnAreaButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AreaCreationDetailView
            {

            });
        }
        
    }
}
