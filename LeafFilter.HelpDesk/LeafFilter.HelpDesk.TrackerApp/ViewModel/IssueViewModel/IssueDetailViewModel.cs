using LeafFilter.HelpDesk.Model;
using LeafFilter.HelpDesk.Model.Conditions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LeafFilter.HelpDesk.Service;
using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Repository;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.IssueViewModel
{
    public class IssueDetailViewModel : INotifyPropertyChanged
    {
        private readonly IIssueService _issueService;
        private Issue _selectedIssue;        
        private int _selectedIndexSeverity;

        public List<SeverityType> Severities { get; set; }

        public IssueDetailViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
               new System.Windows.DependencyObject())) return;

            HelpDeskContext context = new HelpDeskContext();
            _issueService = new IssueService(new IssueRepository(context), new SeverityTypeRepository(context), context);
            
            Severities = Task.Run(() => _issueService.GetAllSeverity()).Result;
        }        

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
                if (value.SeverityType != null)
                {
                    SelectedIndexSeverity = Severities.FindIndex(x => x.Id.Equals(value.SeverityType.Id));
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIssue)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
