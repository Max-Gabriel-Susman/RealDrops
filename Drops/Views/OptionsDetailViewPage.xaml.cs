using System;
using System.Collections.Generic;
using Drops.ViewModels;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class OptionsDetailViewPage : ContentPage
    {
        public OptionsDetailViewPage()
        {
            InitializeComponent();
            BindingContext = new OptionsDetailViewModel();
        }
    }
}