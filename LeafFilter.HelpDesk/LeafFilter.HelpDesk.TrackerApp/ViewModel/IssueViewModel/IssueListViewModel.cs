using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using LeafFilter.HelpDesk.TrackerApp.Utilities;
using LeafFilter.HelpDesk.TrackerApp.View.IssueView;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.IssueViewModel
{
    public class IssueListViewModel
    {
        private IIssueRepository _repository = new IssueRepository();

        private ObservableCollection<Issue> _issues;
        private HelpDeskItem _selectedDetailView;
        public ObservableCollection<Issue> Issues
        {
            get { return _issues; }
            set { _issues = value; }
        }

        private Issue _selectedIssue;
        public Issue SelectedIssue
        {
            get { return _selectedIssue; }
            set
            {
                _selectedIssue = value;
                SelectedDetailView = new HelpDeskItem("", new IssueDetailView() { DataContext = new IssueDetailViewModel() { SelectedIssue = SelectedIssue } });
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public HelpDeskItem SelectedDetailView
        {
            get { return _selectedDetailView; }
            set
            {
                _selectedDetailView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedDetailView)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand DeleteCommand { get; private set; }

        public IssueListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            DeleteCommand = new RelayCommand(OnDelete, CanDelete);

            Issues = new ObservableCollection<Issue>(Task.Run(() => _repository.GetAllIssuesAsync()).Result);
            SelectedIssue = Issues[0];
        }

        private void OnDelete()
        {
            Issues.Remove(SelectedIssue);
        }

        private bool CanDelete()
        {
            return SelectedIssue != null;
        }
    }
}
