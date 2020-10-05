using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace Drops.ViewModels
{
    public class MapPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        // CONSTRUCTORS
        public MapPageViewModel()
        {
            SubscribedAreas = new ObservableCollection<DropsArea>();

            AllAreas.GetSubscribedAreas(SubscribedAreas);


            System.Diagnostics.Debug.WriteLine("listing areas in local subscribed areas for MapPageViewmodel");
            foreach (DropsArea area in SubscribedAreas)
            {
                System.Diagnostics.Debug.WriteLine($"{area.AreaName} is in local subscribed areas");
            }
            System.Diagnostics.Debug.WriteLine("");

            foreach (DropsArea area in SubscribedAreas)
            {
                System.Diagnostics.Debug.WriteLine($"you are subscribed to {area} and this is map view model");
            }

            // prolly gonna delete
            ActivateAreaCommand = new Command(async () =>
            {
                List<DropsArea> areas = await CosmosDBService.GetAreas();

                foreach (DropsArea area in areas)
                {
                    if (area.AreaName == AllUsers.ActiveUser.ActiveAreaName)
                    {
                        ActiveArea = area;
                    }
                }

                // area index null?
                //ActiveArea = areas[areaIndex];
            });

            // EVENT HANDLERS
            DropListCommand = new Command(() =>
            {
                // Application.Current.MainPage.Navigation.PushAsync(new DropListViewPage());
                Application.Current.MainPage.Navigation.PushAsync(new DropListViewPage());
            });

            AreaListCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new AreaListViewPage());
            });

            PeopleListCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new PeopleListViewPage());
            });
        }
        // PROPERTIES
        public ObservableCollection<DropsArea> SubscribedAreas { get; set; }



        public DropsArea ActiveArea { get; set; }

        public ICommand DropListCommand { get; }

        public ICommand AreaListCommand { get; }

        public ICommand PeopleListCommand { get; }

        public ICommand ActivateAreaCommand { get; }

       

        
    }
}
