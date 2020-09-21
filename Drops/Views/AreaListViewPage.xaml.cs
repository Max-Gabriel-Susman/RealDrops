using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.ViewModels;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class AreaListViewPage : ContentPage
    {
        // CONSTRUCTORS
        public AreaListViewPage()
        {
            InitializeComponent();

            AllAreas = Userbase.ActiveUser.AllAreas;

            ActiveArea = (Userbase.ActiveUser.ActiveArea != null) ? Userbase.ActiveUser.ActiveArea : Userbase.DefaultArea;

            ActiveAreaBanner = $"{ActiveArea.Name} is the active area";

            ActivateCommand = new Command(OnActivateAreaButtonClicked);

            BindingContext = this;
            // BindingContext = new AreaListViewModel();


        }

        // PROPERTIES
        public ICommand ActivateCommand { get; }

        public Area ActiveArea { get; set; }

        public string ActiveAreaBanner { get; set; }

        public ObservableCollection<Area> AllAreas { get; set; }

        public ObservableCollection<string> AllAreaNames { get; set; }


        //public ObservableCollection<Area> Areas { get; set; }

        // EVENT HANDLERS
        //async voi=


        async void OnAreaButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AreaCreationDetailView
            {

            });
        }

        public void OnActivateAreaButtonClicked(object obj)
        {
            Area area = obj as Area;

            ActiveArea = area;

            ActiveAreaBanner = $"{ActiveArea.Name} is the active area";

            System.Diagnostics.Debug.WriteLine($"{area.Name} is the new active area");
        }
        
    }
}
