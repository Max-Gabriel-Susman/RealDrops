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

            CreateAreaCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new AreaCreationDetailView());
            });

            GetCommand = new Command(() =>
            {
                foreach(DropsArea area in SubscribedAreas)
                {
                    System.Diagnostics.Debug.WriteLine(area.AreaName);
                }
            });
        }

        // PROPERTIES
        public ObservableCollection<DropsArea> SubscribedAreas { get; }

        public ICommand CreateAreaCommand { get; }

        public ICommand GetCommand { get; }

        // METHODS
        

        public void OnActivateAreaButtonClicked(object obj)
        {
            //DropsArea area = obj as DropsArea;

            //ActiveArea = area;

            //ActiveAreaName = $"{ActiveArea.Area} is the active area";

            //System.Diagnostics.Debug.WriteLine($"{area.Area} is the new active area");
        }
    }
}
