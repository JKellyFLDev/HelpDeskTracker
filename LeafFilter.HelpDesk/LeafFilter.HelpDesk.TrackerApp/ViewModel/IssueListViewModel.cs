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

        public ObservableCollection<Issue> Issues { get; set; }

        public IssueListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;
            Issues = new ObservableCollection<Issue>(Task.Run(() => _repository.GetAllIssuesAsync()).Result);
        }
    }
}
