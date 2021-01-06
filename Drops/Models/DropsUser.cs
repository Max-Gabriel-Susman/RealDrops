using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace Drops.Models
{
    public class DropsUser 
    {
        // PROPERTIES
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
            }
        }
    }
}
