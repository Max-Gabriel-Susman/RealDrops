using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace Drops.Models
{
    public class DropsUser : INotifyPropertyChanged
    {
        // PROPERTIES
        public event PropertyChangedEventHandler PropertyChanged;

        string id;
        [JsonProperty("id")]
        public string ID
        {
            get => id;
            set
            {
                if (id == value)
                    return;

                id = value;

                HandlePropertyChanged();
            }
        }

        string username;
        [JsonProperty("user")]
        public string Username
        {
            get => username;
            set
            {
                if (username == value)
                    return;

                username = value;

                HandlePropertyChanged();
            }
        }

        string password;
        [JsonProperty("password")]
        public string Password
        {
            get => password;
            set
            {
                if (password == value)
                    return;

                password = value;

                HandlePropertyChanged();
            }
        }

        string activeArea;
        [JsonProperty("activeArea")]
        public string ActiveAreaName
        {
            get => activeArea;
            set
            {
                if (activeArea == value)
                    return;

                activeArea = value;

                HandlePropertyChanged();
            }
        }

        Dictionary<string, string> areas;
        [JsonProperty("areas")]
        public Dictionary<string, string> Areas
        {
            get => areas;
            set
            {
                if (areas == value)
                    return;

                areas = value;

                HandlePropertyChanged();
            }
        }

        // METHODS
        void HandlePropertyChanged([CallerMemberName] string propertyName = "")
        {
            var eventArgs = new PropertyChangedEventArgs(propertyName);

            PropertyChanged?.Invoke(this, eventArgs);
        }

    }
}
