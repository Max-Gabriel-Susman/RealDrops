using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.Static;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class PeopleListViewModel //: BaseViewModel
    {
        // CONSTRUCTORS
        public PeopleListViewModel()
        {
            OtherUsers = new ObservableCollection<DropsUser>();

            UsersMeta.GetOtherUsers(OtherUsers);

            ShareAreaCommand = new Command(OnShareTapped);
        }

        // PROPERTIES
        public ICommand ShareAreaCommand { get; }

        public ObservableCollection<DropsUser> OtherUsers { get; set; }

        // EVENT HANDLERS
        public void OnShareTapped(object obj)
        {
            var user = obj as DropsUser;

            UsersMeta.TargetUser = user;

            Application.Current.MainPage.Navigation.PushAsync(new AreaShareViewPage
            {

            });


        }
    }
}
