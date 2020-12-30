using System;
using System.Collections.Generic;
using System.Windows.Input;
using Drops.Models;
using Drops.SharedResources;
using Drops.Services;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class RegistrationPageViewModel : ValidationViewModel
    {
        // CONSTRUCTORS
        public RegistrationPageViewModel()
        {
            ConfigureValidationEntries("Create a new username", "Create a new password");
        }

        // METHODS
        public string RegistrationValidation(string username, string password)
        {
            // checks if username entry is currently in use
            bool usernameTaken = ExistenceCheck(username);

            // Validates Registration Attempts
            if (!usernameTaken)
            {
                if (username.Length >= 8)
                {
                    if (password.Length >= 8)
                    {
                        UsersMeta.Registration(username, password);

                        return "REGISTER";
                    }
                    else
                    {
                        return "PASSWORD_SHORT";
                    }
                }
                else
                {
                    return "USERNAME_SHORT";
                }
            }

            return "INVALID";
        }
    }
}
