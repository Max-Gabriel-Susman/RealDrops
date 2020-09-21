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
        public DropListViewPage()
        {
            InitializeComponent();
            

            Drops = DropMap.Drops;

            DeleteCommand = new Command(OnDeleteTapped);

            BindingContext = this;

        }

        public ObservableCollection<Drop> Drops { get; set; } // = DropMap.Drops;

        public ObservableCollection<Pin> Pins { get; set; } // = DropMap.Drops;

        public ICommand DeleteCommand { get; }

        private void OnDeleteTapped(object obj)
        {
            var drop = obj as Drop;

            Drops.Remove(drop);
        }
    }
}
