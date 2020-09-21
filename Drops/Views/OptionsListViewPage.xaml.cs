using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Drops.Models;
using Drops.ViewModels;

namespace Drops.Views
{
    public partial class OptionsListViewPage : ContentPage
    {
        public IList<Option> Options { get; private set; }

        public OptionsListViewPage()
        {
            InitializeComponent();
            // BindingContext = new MainPageViewModel();
            Options = new List<Option>();

            Options.Add(new Option
            {
                Title = "Location Services",

            });

            BindingContext = this;
            // BindingContext = new OptionListViewModel();
        }



        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (true)
            {
                await Navigation.PushAsync(new OptionsDetailViewPage
                {

                });
            }
        }


        // using keyword?
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // optionsListView.ItemsSource = new List<string> { "this", "is", "a", "test"};

        }


    }


}