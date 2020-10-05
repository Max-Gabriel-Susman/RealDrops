using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.Services;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class AreaShareViewModel 
    {
        public AreaShareViewModel()
        {
            OwnedAreas = new ObservableCollection<DropsArea>();

            AllAreas.GetOwnedAreas(OwnedAreas);

            ShareAreaCommand = new Command(OnShareAreaButtonClicked);

        }

        // PROPERTIES
        public ICommand ShareAreaCommand { get; }

        public ObservableCollection<DropsArea> OwnedAreas { get; set; }

        // EVENT HANDLERS
        async void OnShareAreaButtonClicked(object obj)
        {
            var area = obj as DropsArea;

            foreach(var pair in area.Subscribers)
            {
                if(pair.Key == AllUsers.TargetUser.Username)
                {
                    System.Diagnostics.Debug.WriteLine("user has already been added to db");
                    return;
                }
            }

            area.Subscribers.Add(AllUsers.TargetUser.Username , "recipient");

            await CosmosDBService.UpdateArea(area);
        }
    }
}
