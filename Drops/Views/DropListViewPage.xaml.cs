using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Drops.ViewModels;
using Drops.Models;
using Drops.Static;


namespace Drops.Views
{

    public partial class DropListViewPage : ContentPage
    {
        public DropListViewPage() { InitializeComponent(); }

        void OnDropSelected(object sender, SelectedItemChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"The index of the drop you've selected is {e.SelectedItemIndex}");

            // AllAreas.SelectedDropKey = e.SelectedItemIndex;

            Application.Current.MainPage.Navigation.PushAsync(new DropDetailViewPage());
        }
    }


}
