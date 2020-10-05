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
    public class PeopleListViewModel //: BaseViewModel
    {
        // CONSTRUCTORS
        public PeopleListViewModel()
        {
            // perhaps we need to instntiate otherusers like we do with owned areas
            OtherUsers = new ObservableCollection<DropsUser>();

            AllUsers.GetOtherUsers(OtherUsers);

            //OtherUsers = AllUsers.OtherUsers;

            ShareAreaCommand = new Command(OnShareTapped);
        }

        // PROPERTIES
        public ICommand ShareAreaCommand { get; }

        public ObservableCollection<DropsUser> OtherUsers { get; set; }

        // EVENT HANDLERS
        // was the async keyword causing obj to be null?
        public void OnShareTapped(object obj)
        {
            

            // perhaps the issue was the lack of an explicit comand parameter? that wass it yay

            // why is this obj parameter null?
            //AllUsers.TargetUser = obj as DropsUser;
            // perhaps the issue was the lack of a var type
            var user = obj as DropsUser;

            //System.Diagnostics.Debug.WriteLine($"the username of user is {user.Username}");

            AllUsers.TargetUser = user;

            // I need to be able to store the user associated with the cell that was clicked in the value target usr
            // so that I caan share areas with said user in the next content page

            // obj is null
            // System.Diagnostics.Debug.WriteLine($"The target user is {AllUsers.TargetUser.Username}");

            // could the issue be this navigation method? it wan't the issue

            // both of the code behind pages are the same so that's not the issue
            Application.Current.MainPage.Navigation.PushAsync(new AreaShareViewPage
            {

            });


        }
    }
}
