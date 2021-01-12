using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Model;
using LeafFilter.HelpDesk.Repository;
using LeafFilter.HelpDesk.Service;
using LeafFilter.HelpDesk.TrackerApp.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.ProcessViewModel
{
    public class ProcessListViewModel
    {        
        private readonly IProcessService _processService;

        private ObservableCollection<Process> _processes;
        public ObservableCollection<Process> Processes
        {
            get { return _processes; }
            set { _processes = value; }
        }

        private Process _selectedProcess;
        public Process SelectedProcess
        {
            get { return _selectedProcess; }
            set
            {
                _selectedProcess = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand DeleteCommand { get; private set; }

        public ProcessListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            DeleteCommand = new RelayCommand(OnDelete, CanDelete);

            HelpDeskContext context = new HelpDeskContext();
            _processService = new ProcessService(new ProcessRepository(context), context);

            Processes = new ObservableCollection<Process>(Task.Run(() => _processService.LoadAllAsync()).Result);
        }

        private void OnDelete()
        {
            Processes.Remove(SelectedProcess);
        }

        private bool CanDelete()
        {
            return SelectedProcess != null;
        }
    }
}
