namespace LeafFilter.HelpDesk.TrackerApp.ViewModel
{
    public class MainWindowViewModel
    {
        //public object CurrentViewModel { get; set; }
        public object TopViewModel { get; set; }
        public object BottomViewModel { get; set; }
        public object CenterAViewModel { get; set; }
        public object CenterBViewModel { get; set; }

        public MainWindowViewModel()
        {
            TopViewModel = new UserListViewModel();
            CenterAViewModel = new TicketListViewModel();
            CenterBViewModel = new IssueListViewModel();
            BottomViewModel = new ProcessListViewModel();
        }
    }
}
