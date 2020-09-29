using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.ViewModels;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class PeopleListViewPage : ContentPage
    {
        // FIELDS
        PeopleListViewModel vm;

        // CONSTRUCTORS
        public PeopleListViewPage()
        {
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine("People list code behind constructed");

            vm = new PeopleListViewModel();

            BindingContext = vm;

            vm.Title = "People";
        }

        // LIFECYCLE METHODS
        // we need to move this functionality to the login page
        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.RefreshCommand.Execute(null);
        }
    }
}
