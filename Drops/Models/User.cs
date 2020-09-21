using System;
using System.Collections.ObjectModel;
using SQLite;


namespace Drops.Models
{
    public class User
    {
        // CONSTRUCTORS
        public User() { }

        public User(string username, string password, ObservableCollection<Area> ownedAreas, ObservableCollection<Area> receivedAreas)
        {
            this.Username = username;

            this.Password = password;

            this.OwnedAreas = ownedAreas;

            this.RecievedAreas = receivedAreas;

            this.AllAreas = new ObservableCollection<Area>();

            foreach (Area area in this.OwnedAreas)

                this.AllAreas.Add(area);

            foreach (Area area in this.RecievedAreas)

                this.AllAreas.Add(area);

        }

        // PROPERTIES
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }

        public string Username { get; set; }

        public string Password { get; private set; }

        public Area ActiveArea { get; set; }

        // public ObservableCollection<Area> OwnedAreas = new ObservableCollection<Area>();        
        public ObservableCollection<Area> OwnedAreas { get; set; }

        public ObservableCollection<Area> RecievedAreas { get; set; }

        // Currently populated with mockdata
        public ObservableCollection<Area> AllAreas { get; set; } // = new ObservableCollection<Area>()
        
        // Methods
        public void UpdateUsername(string newUsername)
        {
            this.Username = newUsername;
        }

        public void UpdatePassword(string newPassword)
        {
            this.Password = newPassword;
        }

        public void CreateArea(double latitude, double longitude, string name)
        {
            Area area = new Area(latitude, longitude, name, this.Username);

            OwnedAreas.Add(area);

            AllAreas.Add(area);
        }

        public void ReceiveArea(Area area)
        {
            RecievedAreas.Add(area);

            AllAreas.Add(area);
        }

        public ObservableCollection<Area> GetAreas()
        {
            // Returns all areas available to the User
            return this.OwnedAreas;
        }

        // we want 
    //    public bool GetArea(int id, out Area areaWithID)
    //    {
    //        //return this.OwnedAreas.
    //        return true;
    //    }
    }
}
