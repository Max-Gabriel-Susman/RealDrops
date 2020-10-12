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
    public class RegistrationPageViewModel : ValidationViewModel
    {
        // CONSTRUCTORS
        public RegistrationPageViewModel()
        {
            User = new DropsUser();

            SaveCommand = new Command(async () =>
            {
                
                System.Diagnostics.Debug.WriteLine("EXECUTESAVECOMMAND INVOKED");
                // Enforcces Unique usernames
                foreach (DropsUser user in await CosmosDBService.GetUsers())
                {
                    System.Diagnostics.Debug.WriteLine("Checking against existing user");

                    if (user.Username == UsernameEntry)
                    {
                        System.Diagnostics.Debug.WriteLine("USERNAME DOPPLEGANGER FOUND, METHOD RETURNED");
                        return;
                    }
                }


                System.Diagnostics.Debug.WriteLine($"The length of passwordentry is {PasswordEntry}");
                System.Diagnostics.Debug.WriteLine($"The length of passwordentry is {PasswordEntry.Length}");

                // Enforces a minimum password length of 8 characters
                if (PasswordEntry.Length >= 8)
                {


                    User.Username = UsernameEntry;

                    User.Password = PasswordEntry;

                    User.ActiveAreaName = "default"; // need to change this to the areas name

                    User.Areas = new Dictionary<string, string>();

                    // first population
                    //PopulateUsersCommand.Execute(null);

                    await CosmosDBService.InsertUser(User);

                    AllUsers.Users.Add(User);

                    //SaveComplete?.Invoke(this, new EventArgs());

                    AllUsers.ActiveUser = User;

                    if (AllUsers.ActiveUser == null)
                    {
                        System.Diagnostics.Debug.WriteLine($"ACTIVE USER IS NULL AT THE ENDE OF REGISTRATION");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"ACTIVE USER IS NOT NULL AT THE ENDE OF REGISTRATION");


                    }



                    System.Diagnostics.Debug.WriteLine($"IsValid is currently {IsValid}");
                }

                
            });
        }

        // PROPERTIES (old content)

        public DropsUser User { get; set; }

        public ICommand SaveCommand { get; }

        public event EventHandler SaveComplete;
        
        // METHODS
        //async Task ExecuteSaveCommand()
        //{
        //    System.Diagnostics.Debug.WriteLine("EXECUTESAVECOMMAND INVOKED");
        //    // Enforcces Unique usernames
        //    foreach (DropsUser user in await CosmosDBService.GetUsers())
        //    {
        //        System.Diagnostics.Debug.WriteLine("Checking against existing user");

        //        if (user.Username == UsernameEntry)
        //        {
        //            System.Diagnostics.Debug.WriteLine("USERNAME DOPPLEGANGER FOUND, METHOD RETURNED");
        //            return;
        //        }
        //    }

        //    System.Diagnostics.Debug.WriteLine($"The length of passwordentry is {PasswordEntry}");
        //    System.Diagnostics.Debug.WriteLine($"The length of passwordentry is {PasswordEntry.Length}");

        //    // Enforces a minimum password length of 8 characters
        //    if (PasswordEntry.Length >= 8)
        //    {
                

        //        User.Username = UsernameEntry;

        //        User.Password = PasswordEntry;

        //        User.ActiveAreaName = "default";

        //        User.Areas = new Dictionary<string, string>();

        //        // first population
        //        //PopulateUsersCommand.Execute(null);

        //        await CosmosDBService.InsertUser(User);

        //        AllUsers.Users.Add(User);

        //        SaveComplete?.Invoke(this, new EventArgs());

        //        AllUsers.ActiveUser = User;

        //        if(AllUsers.ActiveUser == null)
        //        {
        //            System.Diagnostics.Debug.WriteLine($"ACTIVE USER IS NULL AT THE ENDE OF REGISTRATION");
        //        }
        //        else
        //        {
        //            System.Diagnostics.Debug.WriteLine($"ACTIVE USER IS NOT NULL AT THE ENDE OF REGISTRATION");

                   
        //        }



        //        System.Diagnostics.Debug.WriteLine($"IsValid is currently {IsValid}");
        //    }

        //}
    }
}
