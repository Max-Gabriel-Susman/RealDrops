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
        // FIELDS
        List<DropsArea> areas;

        // CONSTRUCTORS
        public AreaListViewModel()
        {
        }

        // PROPERTIES
        

        
        public ICommand GetCommand { get; }

       

        //public AreaListViewModel()
        //{
        //    AllAreas = Userbase.ActiveUser.AllAreas;

        //    ActiveArea = (Userbase.ActiveUser.ActiveArea != null) ? Userbase.ActiveUser.ActiveArea : Userbase.DefaultArea;

        //    ActiveAreaName = $"{ActiveArea.Name} is the active area";

        //    ActivateAreaCommand = new Command(OnActivateAreaButtonClicked);

        //    CreateAreaCommand = new Command(() =>
        //    {
        //        Application.Current.MainPage.Navigation.PushAsync(new AreaCreationDetailView());
        //    });
        //}

        //// PROPERTIES
        //public ICommand ActivateAreaCommand { get; }

        //public ICommand CreateAreaCommand { get; }

        //public Area ActiveArea { get; set; }

        //public string ActiveAreaName { get; set; }

        //public ObservableCollection<Area> AllAreas { get; set; }

        //public ObservableCollection<string> AllAreaNames { get; set; }

        //public void OnActivateAreaButtonClicked(object obj)
        //{
        //    Area area = obj as Area;

        //    ActiveArea = area;

        //    ActiveAreaName = $"{ActiveArea.Name} is the active area";

        //    System.Diagnostics.Debug.WriteLine($"{area.Name} is the new active area");
        //}
    }
}
