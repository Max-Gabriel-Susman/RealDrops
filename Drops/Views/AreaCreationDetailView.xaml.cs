using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.Services;
using Drops.Static;
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

            SubscribedAreas = new ObservableCollection<DropsArea>();

            AreasMeta.GetSubscribedAreas(SubscribedAreas);

            // Creates an area locally and inserts it into the DB
            CreateAreaCommand = new Command( async () =>
            {
                System.Diagnostics.Debug.WriteLine("create are acommand invoked");

                if(Latitude != null && Longitude != null && AreaNameEntry != null)
                {
                    NewArea = new DropsArea()
                    {
                        AreaName = AreaNameEntry,

                        Latitude = Latitude ?? 0.0,

                        Longitude = Longitude ?? 0.0,

                        JSONPins = new Dictionary<string, Dictionary<string, string>>(),

                        Subscribers = new Dictionary<string, string>()
                        {
                            {UsersMeta.ActiveUser.Username, "owner"}
                        },

                        DropsCreated = 0
                    };

                    // Original

                    AreasMeta.ActiveArea = NewArea;

                    UsersMeta.ActiveUser.ActiveAreaName = NewArea.AreaName;

                    UsersMeta.UpdateActiveUser();

                    await CosmosDBService.InsertArea(NewArea);

                    //AreasMeta.PopulateAreas(); // maybe?

                    //DropsArea newAreaWithID = new DropsArea();

                    //foreach(DropsArea area in AreasMeta.Areas)
                    //{
                    //    if(area.AreaName == NewArea.AreaName)
                    //    {
                    //        System.Diagnostics.Debug.WriteLine("newAreaWithID was assigned");
                    //        newAreaWithID = area;
                    //    }
                    //}

                    //AreasMeta.ActiveArea = newAreaWithID;

                    //AreasMeta.ActiveArea.JSONPins = newAreaWithID.JSONPins;

                    //UsersMeta.ActiveUser.ActiveAreaName = newAreaWithID.AreaName;

                    

                    // Pallete cleanser

                    //DropsArea PublicArea = AreasMeta.PublicArea;

                    //AreasMeta.ActiveArea = PublicArea;

                    //UsersMeta.ActiveUser.ActiveAreaName = PublicArea.AreaName;

                    //UsersMeta.UpdateActiveUser();

                    //// return of the king                   
                    //AreasMeta.ActiveArea = NewArea;

                    //UsersMeta.ActiveUser.ActiveAreaName = NewArea.AreaName;

                    //UsersMeta.UpdateActiveUser();


                    await Application.Current.MainPage.Navigation.PopAsync();

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Area creation has failed");

                    // We need to provide the user with additional feedback
                }
            });

            BindingContext = this;
        }

        // PROPERTIES
        public ObservableCollection<DropsArea> SubscribedAreas { get; set; }

        public DropsArea NewArea { get; set; }

        public ICommand CreateAreaCommand { get; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Label { get; set; }

        public string AreaNameEntry { get; set; }


        // EVENT HANDLER
        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            map.Pins.Clear();

            Latitude = e.Position.Latitude;

            Longitude = e.Position.Longitude;

            Pin pin = new Pin()
            {   
                Position = new Position(Latitude ?? 0.0, Longitude ?? 0.0),

                Label = "Undeclared"
            };

            map.Pins.Add(pin);
        }

        // LIFECYCLE METHODS
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //AllAreas.SubscribedAreas = CosmosDBService.GetAreas();
        }
    }
}
