using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.Static;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class AreaListViewModel : BaseViewModel
    {
        // CONSTRUCTORS
        public AreaListViewModel()
        {
            SubscribedAreas = new ObservableCollection<DropsArea>();

            AreasMeta.GetSubscribedAreas(SubscribedAreas);

            ActiveAreaNameLabel = $"The active area is {AreasMeta.ActiveArea.AreaName}";

            NumberOfSubscribersLabel = $"This area has {AreasMeta.ActiveArea.Subscribers.Count}"; 

            // COMMANDS
            CreateAreaCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.InsertPageBefore(new AreaCreationDetailView(), PagesMeta.ThisPage);

                Application.Current.MainPage.Navigation.PopAsync();
            });

            SelectCommand = new Command(OnActivateAreaButtonClicked);
        }

        // PROPERTIES
        public ObservableCollection<DropsArea> SubscribedAreas { get; }

        public ICommand CreateAreaCommand { get; }

        public ICommand SelectCommand { get; }

        public string ActiveAreaNameLabel { get; set; } 

        public string OwnershipLabel { get; set; } 

        public string NumberOfSubscribersLabel { get; set; } 

        // EVENT HANDLERS
        public void OnActivateAreaButtonClicked(object obj)
        {
            DropsArea area = obj as DropsArea;

            AreasMeta.ActiveArea = area;

            UsersMeta.ActiveUser.ActiveAreaName = area.AreaName;

            UsersMeta.UpdateActiveUser();

            AreasMeta.UpdateActiveArea(area);

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
