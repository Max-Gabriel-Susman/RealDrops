using Xamarin.Forms;
using Drops.Static;


namespace Drops.Views
{
    // This functionality in this class is currently under maintenance as well
    public partial class DropListViewPage : ContentPage
    {
        // DropListViewModel vm;

        // CONSTRUCTORS
        public DropListViewPage()
        {
            InitializeComponent();

            //System.Diagnostics.Debug.WriteLine("People list code behind constructed");

            //vm = new DropListViewModel();

            //BindingContext = vm;
        }

        void OnDropSelected(object sender, SelectedItemChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"The index of the drop you've selected is {e.SelectedItemIndex}");

            AreasMeta.SelectedDrop = AreasMeta.ActiveAreaDropPins[e.SelectedItemIndex];

            Application.Current.MainPage.Navigation.PushAsync(new DropDetailViewPage());
        }

        // going to attempt to migrate to the vm, not sure why the fuck this isn't working, I'm just going to move back to the way it was to get shit working
        //protected override void OnAppearing() // could I be calling this method from my view model? I need to grok the timing of all this
        //{
        //    base.OnAppearing();

        //    AllAreas.ActiveAreaDropPins.Clear(); // I think we'll handle clearing and instantiating in one move instead

        //    vm.ActiveAreaDropPins = AllAreas.ActiveAreaDropPins;

        //    vm.PopulateItemSource();

        //    System.Diagnostics.Debug.WriteLine($"The length of ACTIVEAREADROPPINS is {vm.ActiveAreaDropPins.Count} AS seen in droplistviewpage");
        //}
    }


}
