using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.Static;
using Drops.Services;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class AreaListViewModel : BaseViewModel
    {
        public AreaListViewModel()
        {
            SubscribedAreas = new ObservableCollection<DropsArea>();

            AreasMeta.GetSubscribedAreas(SubscribedAreas);

            //bool ownership = false;

            //string owner = "";

            //// definitely worth creating a more efficient set of logic
            //foreach(DropsArea area in SubscribedAreas)
            //{
            //    foreach(var pair in area.Subscribers)
            //    {
            //        if(pair.Value == "owner")
            //        {
            //            owner = pair.Key;

            //            ownership = true;
            //        }
            //    }
            //}

            ActiveAreaNameLabel = $"The active area is {AreasMeta.ActiveArea.AreaName}"; //AllAreas.ActiveArea.AreaName;

            // rename to ownership label
            // OwnershipLabel = (ownership) ? "Ownership: You own this area": $"Ownership: This is {owner}'s area" ; // if user is owner ? this is your area : other user's area

            NumberOfSubscribersLabel = $"This area has {AreasMeta.ActiveArea.Subscribers.Count}"; // area subscribers collection count

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

        public string ActiveAreaNameLabel { get; set; } 

        public string OwnershipLabel { get; set; } // How are we going to get this from areas?

        public string NumberOfSubscribersLabel { get; set; } // How are we going to get this from areas?

        // <Label Text = "{Binding ActiveAreaName}"
        //       VerticalOptions="CenterAndExpand"
        //       HeightRequest="25"/>
        //<Label Text = "{Binding Ownership}"
        //       VerticalOptions="CenterAndExpand"
        //       HeightRequest="25"/>
        //<Label Text = "{Binding NumberOfSubscribers}"
        //       VerticalOptions="CenterAndExpand"
        //       HeightRequest="25"/>

        // METHODS
        public void OnActivateAreaButtonClicked(object obj)
        {
            System.Diagnostics.Debug.WriteLine($"The active area is {AreasMeta.ActiveArea.AreaName} before update");

            DropsArea area = obj as DropsArea;

            AreasMeta.ActiveArea = area;

            // AllAreas.ActiveAreaJSONPins.Clear();

            // now populate it

            UsersMeta.ActiveUser.ActiveAreaName = area.AreaName;

            UsersMeta.UpdateActiveUser();

            AreasMeta.UpdateActiveArea(area);

            System.Diagnostics.Debug.WriteLine($"The active area is {AreasMeta.ActiveArea.AreaName} after update");

            System.Diagnostics.Debug.WriteLine($"The active user's active area is {UsersMeta.ActiveUser.ActiveAreaName} after update");

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
