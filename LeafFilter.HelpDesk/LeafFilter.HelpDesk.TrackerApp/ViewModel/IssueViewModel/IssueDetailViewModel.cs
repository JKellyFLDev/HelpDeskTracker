using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LeafFilter.HelpDesk.Models.Types;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.IssueViewModel
{
    public class IssueDetailViewModel : INotifyPropertyChanged
    {
        private IIssueRepository _issueRepository = new IssueRepository();
        private Issue _selectedIssue;
        //private List<IssueSeverity> _issueSeverities;
        private int _selectedIndexSeverity;

        public List<IssueSeverity> Severities { get; set; }

        public IssueDetailViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
               new System.Windows.DependencyObject())) return;
            
            Severities = Task.Run(() => _issueRepository.GetAllSeveritiesAsync()).Result;
        }

        //public List<IssueSeverity> IssueSeverities
        //{
        //    get => _issueSeverities;
        //    set
        //    {
        //        _issueSeverities = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IssueSeverities)));
        //    }
        //}

        public int SelectedIndexSeverity
        {
            get => _selectedIndexSeverity;
            set
            {
                _selectedIndexSeverity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndexSeverity)));
            }
        }

        public Issue SelectedIssue
        {
            get => _selectedIssue;
            set
            {
                _selectedIssue = value;
                if (value.IssueSeverity != null)
                {
                    SelectedIndexSeverity = Severities.FindIndex(x => x.Id.Equals(value.IssueSeverity.Id));
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIssue)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
