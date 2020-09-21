using System;
using System.Collections.Generic;
using Drops.ViewModels;
using Xamarin.Forms;


namespace Drops.Views
{
    public partial class DropDetailViewPage : ContentPage
    {
        
        public DropDetailViewPage()
        {
            InitializeComponent();
            // BindingContext = new MainPageViewModel();
            BindingContext = new DropDetailViewModel();
        }
    }
}
