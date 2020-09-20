using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Drops.ViewModels;


namespace Drops.Views
{

    public partial class DropListViewPage : ContentPage
    {
        public DropListViewPage()
        {
            InitializeComponent();
            BindingContext = new DropListViewModel();
        }
    }
}
