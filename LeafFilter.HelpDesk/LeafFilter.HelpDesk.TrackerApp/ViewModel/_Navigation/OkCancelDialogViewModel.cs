using LeafFilter.HelpDesk.TrackerApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel._Navigation
{
    public class OkCancelDialogViewModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => this.MutateVerbose(ref _name, value, RaisePropertyChanged());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
            => args => PropertyChanged?.Invoke(this, args);
    }
}
