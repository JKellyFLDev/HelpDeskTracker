namespace LeafFilter.HelpDesk.TrackerApp.ViewModel
{
    public class MainWindowViewModel
    {
        public object CurrentViewModel { get; set; }
        public MainWindowViewModel()
        {
            CurrentViewModel = new UserListViewModel();
        }
    }
}
