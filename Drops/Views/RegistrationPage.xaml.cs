using System;
using System.Collections.Generic;
using Drops.ViewModels;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class RegistrationPage : ContentPage
    {
        // FIELDS
        RegistrationPageViewModel vm;

        // CONSTRUCTORS
        public RegistrationPage()
        {
            InitializeComponent();

            vm = new RegistrationPageViewModel();

            BindingContext = vm;
        }

        // EVENT HANDLERS
        async void OnRegistrationButtonClicked(object sender, EventArgs e)
        {
            vm.SaveCommand.Execute(null);

            System.Diagnostics.Debug.WriteLine($"IsValid is {vm.IsValid}");

            // we'll handle the actual navigation here
            if (true)//(vm.IsValid)
            {
                Navigation.InsertPageBefore(new MapControlPage(), this);
                await Navigation.PopAsync();
            }

            else
            {
                // Login failed
                System.Diagnostics.Debug.WriteLine("registration failed");
            }
        }
    }
}
