using System;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms.Maps;


namespace Drops.Models
{
    
    public class Area
    {
        // CONSTRUCTORS
        public Area(double latitude, double longitude, string name, string owner)
        {
            this.Latitude = latitude;

            this.Longitude = longitude;

            this.Drops = new ObservableCollection<Drop>();

            this.DropMap = new DropMap();

            this.ViewHeight = 1.0;

            this.Name = name;

            this.Owner = owner;
        }

        // PROPERTIES
        [PrimaryKey, AutoIncrement]

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double ViewHeight { get; set; }

        // private int ID { get; set; }

        private bool IsActive { get; set; }

        public ObservableCollection<Drop> Drops { get; set; }

        public DropMap DropMap { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        // METHODS
        private void FocusDropMap()
        {
            DropMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Latitude, Longitude), Distance.FromMiles(ViewHeight)));
        }


    }
}
