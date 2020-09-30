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
    public class PeopleListViewModel : BaseViewModel
    {
        // CONSTRUCTORS
        public PeopleListViewModel()
        {
           
        }

        // PROPERTIES
        

        //public PeopleListViewModel()
        //{
        //    OtherUsers = Userbase.OtherUsers;

        //    // EVENT HANDLERS
        //    ShareAreaCommand = new Command(OnShareTapped);
        //}

        //// PROPERTIES
        //public ICommand ShareAreaCommand { get; }

        //public ObservableCollection<User> OtherUsers { get; set; }

        //// EVENT HANDLERS
        //async void OnShareTapped(object obj)
        //{

        //    Userbase.TargetUser = obj as User;

        //    await Application.Current.MainPage.Navigation.PushAsync(new AreaShareViewPage
        //    {

        //    });


        //}
    }
}
