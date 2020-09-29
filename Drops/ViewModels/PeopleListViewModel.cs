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
            Users = new List<DropsUser>();

            RefreshCommand = new Command(async () => await ExecuteRefreshCommand());

            System.Diagnostics.Debug.WriteLine("People list code behind constructed");

            GetCommand = new Command(() =>
            {
                System.Diagnostics.Debug.WriteLine("Listing user properties ... NOW");
                foreach (DropsUser user in Users)
                {
                    System.Diagnostics.Debug.WriteLine(user.Username);
                    System.Diagnostics.Debug.WriteLine(user.Password);
                    System.Diagnostics.Debug.WriteLine(user.ActiveArea);
                    System.Diagnostics.Debug.WriteLine(user.ID);
                }
            });
            
        }

        // PROPERTIES
        public ICommand RefreshCommand { get; }

        public ICommand GetCommand { get; }

        // EVENT HANDLERS
        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Users = await CosmosDBService.GetUsers();
            }
            finally
            {
                IsBusy = false;
            }
        }

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
