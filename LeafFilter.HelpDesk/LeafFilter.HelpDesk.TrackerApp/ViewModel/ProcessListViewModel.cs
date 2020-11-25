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

        public ObservableCollection<Process> Processes { get; set; }

        public ProcessListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;
            Processes = new ObservableCollection<Process>(Task.Run(() => _repository.GetAllProcessesAsync()).Result);
        }
    }
}
