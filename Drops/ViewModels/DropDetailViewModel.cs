using System;
using System.Collections.Generic;
using System.Windows.Input;
using Drops.Models;
using Drops.Static;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class DropDetailViewModel
    {
        // CONSTRUCTORS
        public DropDetailViewModel()
        {
            SaveChangesCommand = new Command(async () =>
            {
                // as long as the new logic prevents duplicate pin keys in pin collections we're god to use the key
                //AllAreas.ActiveArea.JSONPins.Element
            });
        }

        

        // PROPERTIES
        ICommand SaveChangesCommand { get; }

        string PinKey;

        string NewLabelEntry { get; set; }

    }
}
