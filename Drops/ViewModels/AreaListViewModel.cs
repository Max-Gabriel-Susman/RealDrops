using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.Services;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class AreaListViewModel : BaseViewModel
    {
        public AreaListViewModel()
        {
            SubscribedAreas = new ObservableCollection<DropsArea>();

            AllAreas.GetSubscribedAreas(SubscribedAreas);

            ActiveAreaName = AllAreas.ActiveArea.AreaName;

            CreateAreaCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new AreaCreationDetailView());
            });

            SelectCommand = new Command(OnActivateAreaButtonClicked);
            //SelectCommand = new Command(() =>
            //{
            //    System.Diagnostics.Debug.WriteLine("Select command invoked");
            //});

            GetCommand = new Command(() =>
            {
                foreach(DropsArea area in SubscribedAreas)
                {
                    System.Diagnostics.Debug.WriteLine(area.AreaName);
                }
            });

            foreach(DropsArea area in SubscribedAreas)
            {
                System.Diagnostics.Debug.WriteLine($"the area's name is {area.AreaName}");
            }
        }

        // PROPERTIES
        public ObservableCollection<DropsArea> SubscribedAreas { get; }

        public ICommand CreateAreaCommand { get; }

        public ICommand GetCommand { get; }

        public ICommand SelectCommand { get; }

        public string ActiveAreaName { get; set; }

        // METHODS


        public void OnActivateAreaButtonClicked(object obj)
        {
            System.Diagnostics.Debug.WriteLine($"The active area is {AllAreas.ActiveArea.AreaName} before update");

            DropsArea area = obj as DropsArea;

            AllAreas.ActiveArea = area;

            // AllAreas.ActiveAreaJSONPins.Clear();

            // now populate it

            AllUsers.ActiveUser.ActiveAreaName = area.AreaName;

            AllUsers.UpdateActiveUser();

            AllAreas.UpdateActiveArea(area);

            System.Diagnostics.Debug.WriteLine($"The active area is {AllAreas.ActiveArea.AreaName} after update");

            System.Diagnostics.Debug.WriteLine($"The active user's active area is {AllUsers.ActiveUser.ActiveAreaName} after update");
        }
    }
}
