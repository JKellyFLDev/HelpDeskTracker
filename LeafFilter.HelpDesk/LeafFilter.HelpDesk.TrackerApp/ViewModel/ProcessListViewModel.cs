using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel
{
    public class ProcessListViewModel
    {
        private IProcessRepository _repository = new ProcessRepository();

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

            Processes = new ObservableCollection<Process>(Task.Run(() => _repository.GetAllProcessesAsync()).Result);
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
