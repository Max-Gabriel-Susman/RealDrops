using System;
namespace Drops.Models
{
    public class DropsPin
    {
        // CONSTRUCTORS
        public DropsPin(string label, string key)
        {
            Label = label;

            Key = key;
        }
        // PROPERTIES
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Label { get; set; }

        public string Key { get; set; }
    }
}
