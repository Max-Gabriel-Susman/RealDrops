using System.ComponentModel;


namespace Drops.ViewModels
{
    // Once I get base functionality established I'm going to start migrating code from MapControlPage.xaml.cs here
    public class MapControlPageViewModel : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged; 

        public MapControlPageViewModel()
        {
           
        }
    }
}
