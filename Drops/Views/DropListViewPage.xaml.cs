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


namespace Drops.Views
{

    public partial class DropListViewPage : ContentPage
    {
        public DropListViewPage() { InitializeComponent(); }

        void OnDropSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // we'll come back to this later, currently the issue is that I can't figure out how to tell the editor which pin it's tasked with editing

            //var dropsPin = sender as DropsPin;

            //AllAreas.ActivePinKey = dropsPin.Key;

            //System.Diagnostics.Debug.WriteLine($"the pin key is {dropsPin.Key}");

            //System.Diagnostics.Debug.WriteLine($"the static pin key is {AllAreas.ActivePinKey}");

            //Application.Current.MainPage.Navigation.PushAsync(new DropDetailViewPage()
            //{
            //    //ModifiedJSONPinKey = dropsPin.Key // it almost looks like the issue here is that dropsPin.Key is null
            //});

        }
    }


}
