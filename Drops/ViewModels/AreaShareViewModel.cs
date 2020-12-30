using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.SharedResources;
using Drops.Services;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class AreaShareViewModel 
    {
        // CONSTRUCTORS
        public AreaShareViewModel()
        {
            OwnedAreas = new ObservableCollection<DropsArea>();

            AreasMeta.GetOwnedAreas(OwnedAreas);

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
                // Checks the area's subscriber against the current user by username to prevent redundant subscriptions
                if(pair.Key == UsersMeta.TargetUser.Username)
                {
                    return;
                }
            }

            area.Subscribers.Add(UsersMeta.TargetUser.Username , "recipient");

            await CosmosDBService.UpdateArea(area);
        }
    }
}
