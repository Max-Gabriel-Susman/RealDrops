using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Drops.Models;
using Drops.Static;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Drops.ViewModels
{
    public class MapControlPageViewModel : INotifyPropertyChanged // this means the class fires a property changed event every time one of it's properties change
    {
        // FIELDS
        // OnPropertyChanged method?
        DateTime dateTime; // this is the property being monitored
        public ObservableCollection<Pin> pins;
        /*
         * We need to add all the functionality of the old mappage while using this new functionaliy to 
         * implement self refreshing data
         */

        //System.Diagnostics.Debug.Write($"Pins has {All}");


        public event PropertyChangedEventHandler PropertyChanged; // this event handler 

        public MapControlPageViewModel()
        {
            // map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.7377780, -111.8308330), Distance.FromMiles(1.0)));

            this.DateTime = DateTime.Now; // property is assigned it's initial value

            // starts a recurring timer using the device's clock capabilities
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });
        }

        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;

                    if (PropertyChanged != null)
                    {
                        /*
                         * the firing of the event is wired right into the propertie getter right here
                         * propertychangeddvenargs is what tells the xaml the new value that's veen assigned to the property
                         * the property changed method is what encapsulates all the logic for this
                         */
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
            get
            {
                return dateTime;
            }
        }

        public ObservableCollection<Pin> Pins
        {
            set
            {
                if (pins != value)
                {
                    pins = value;

                    if (PropertyChanged != null)
                    {
                        /*
                         * the firing of the event is wired right into the propertie getter right here
                         * propertychangeddvenargs is what tells the xaml the new value that's veen assigned to the property
                         * the property changed method is what encapsulates all the logic for this
                         */
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
            get
            {
                return pins;
            }
        }

    }
}
