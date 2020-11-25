namespace LeafFilter.HelpDesk.TrackerApp.ViewModel
{
    public class MainWindowViewModel
    {
        //public object CurrentViewModel { get; set; }
        public object UserViewModel { get; set; }
        public object ProcessViewModel { get; set; }
        public object TicketViewModel { get; set; }
        public object IssueViewModel { get; set; }

        public MainWindowViewModel()
        {
            UserViewModel = new UserListViewModel();
            TicketViewModel = new TicketListViewModel();
            IssueViewModel = new IssueListViewModel();
            ProcessViewModel = new ProcessListViewModel();
        }
    }
}
