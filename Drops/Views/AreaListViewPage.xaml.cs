using Xamarin.Forms;
using Drops.Static;


namespace Drops.Views
{
    public partial class AreaListViewPage : ContentPage
    {
        public AreaListViewPage() { InitializeComponent(); }

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
