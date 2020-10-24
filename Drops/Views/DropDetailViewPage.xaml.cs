using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Drops.Static;
using Drops.Services;

namespace Drops.Views
{
    public partial class DropDetailViewPage : ContentPage
    {
        // CONSTRUCTORS
        public DropDetailViewPage()
        {
            InitializeComponent();

            NewLabelEntry = "";

            EditDropCommand = new Command( async () =>
            {
                System.Diagnostics.Debug.WriteLine("EDITDROPCOMMAND INVOKED");

                if (NewLocationPin != null || NewLabelEntry != "") // I need to change this logic because the user should be able to change data without changing the location
                {
                    System.Diagnostics.Debug.WriteLine("MODIFIED PIN WAS NOT NULL");

                    string label = (NewLabelEntry != "") ? NewLabelEntry : AreasMeta.SelectedDrop.Label;

                    string latitude = (NewLocationPin != null) ? $"{NewLocationPin.Position.Latitude}" : AreasMeta.SelectedDrop.Latitude;

                    string longitude = (NewLocationPin != null) ? $"{NewLocationPin.Position.Longitude}" : AreasMeta.SelectedDrop.Longitude;

                    AreasMeta.SelectedDrop.Latitude = latitude;

                    AreasMeta.SelectedDrop.Longitude = longitude;

                    AreasMeta.SelectedDrop.Label = label;

                    AreasMeta.ActiveAreaDropPins.Add(AreasMeta.SelectedDrop);

                    AreasMeta.ActiveArea.JSONPins[AreasMeta.SelectedDrop.Key] = new Dictionary<string, string>()
                    {
                        { "label", label },

                        { "latitude", latitude },

                        { "longitude", longitude }  
                    };

                    await CosmosDBService.UpdateArea(AreasMeta.ActiveArea);

                    Navigation.InsertPageBefore(new DropListViewPage(), this);

                    await Navigation.PopAsync();


                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("MODIFIED PIN WAS NULL");
                }
            });

            BindingContext = this;
        }

        // PROPERTIES
        public ICommand SaveChangesCommand { get; }

        public ICommand EditDropCommand { get; }

        public string NewLabelEntry { get; set; }

        public Pin NewLocationPin { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        // METHODS
        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            map.Pins.Clear();

            Latitude = e.Position.Latitude;

            Longitude = e.Position.Longitude;

            Pin pin = new Pin()
            {
                Position = new Position(Latitude ?? 0.0, Longitude ?? 0.0),

                Label = "New Drop Location!"
            };

            NewLocationPin = pin;

            map.Pins.Add(pin);

            
        }
    }
}
