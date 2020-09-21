using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Xamarin.Forms;


namespace Drops.Views
{
    public partial class AreaShareViewPage : ContentPage
    {
        // CONSTRUCTOR
        public AreaShareViewPage()
        {
            InitializeComponent();

            OwnedAreas = Userbase.ActiveUser.OwnedAreas;

            ShareCommand = new Command(OnShareAreaButtonClicked);

            BindingContext = this;
        }

        // PROPERTIES
        public ICommand ShareCommand { get; }

        public ObservableCollection<Area> OwnedAreas { get; set; } 

        public User Recipient { get; set; }

        // EVENT HANDLERS
        public void OnShareButtonClicked(object sender,EventArgs args)
        {
            // I want to iterate over each listview item and the area associated with it is to be appended to the target users sharedareas
            //foreach()
            foreach(User user in Userbase.Users)
            {
                Console.WriteLine(user.Username);
            }

            Navigation.PopAsync();
        }

        // Adds Area to the target Users ReceivedAreas collection
        public void OnShareAreaButtonClicked(object obj)
        {
            var area = obj as Area;

            Console.WriteLine(area.Name);

            Recipient.ReceiveArea(area);
        }



    }

}
