using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel
{
    public class IssueListViewModel
    {
        private IIssueRepository _repository = new IssueRepository();

        private ObservableCollection<Issue> _issues;
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
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand DeleteCommand { get; private set; }

        public IssueListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            DeleteCommand = new RelayCommand(OnDelete, CanDelete);

            Issues = new ObservableCollection<Issue>(Task.Run(() => _repository.GetAllIssuesAsync()).Result);
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
