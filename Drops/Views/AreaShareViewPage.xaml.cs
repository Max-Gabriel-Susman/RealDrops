using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Drops.Models;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class AreaShareViewPage : ContentPage
    {
        public AreaShareViewPage()
        {
            InitializeComponent();

            

            OwnedAreas = Userbase.ActiveUser.OwnedAreas; 

            BindingContext = this;
        }

        public ObservableCollection<Area> OwnedAreas { get; set; } 
       

    }

}
