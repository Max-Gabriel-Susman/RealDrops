using Xamarin.Forms;
using Drops.SharedResources;


namespace Drops.Views
{
    public partial class DropListViewPage : ContentPage
    {
        // CONSTRUCTORS
        public DropListViewPage()
        {
            InitializeComponent();
        }

        // EVENT HANDLERS
        void OnDropSelected(object sender, SelectedItemChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"The index of the drop you've selected is {e.SelectedItemIndex}");

            AreasMeta.SelectedDrop = AreasMeta.ActiveAreaDropPins[e.SelectedItemIndex];

            Navigation.InsertPageBefore(new DropDetailViewPage(), this);

            Navigation.PopAsync();
        }

        // LIFECYCLE METHODS
        protected override void OnAppearing()
        {
            base.OnAppearing();

            PagesMeta.ThisPage = this;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            PagesMeta.ThisPage = null;
        }
    }


}
