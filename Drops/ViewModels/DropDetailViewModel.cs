using System;
using System.Windows.Input;
using Drops.Models;
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
                // we need to take in a label latitude, longitude a d key ammend the pin clientside and then update the area it belongs to in the db
                //AllAreas.ActiveArea.JSONPins[PinKey];
            });
        }

        // PROPERTIES
        ICommand SaveChangesCommand { get; }

        string PinKey;

        string NewLabelEntry { get; set; }

    }
}
