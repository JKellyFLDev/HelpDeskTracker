using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using LeafFilter.HelpDesk.TrackerApp.Utilities;
using LeafFilter.HelpDesk.TrackerApp.View.IssueView;
using LeafFilter.HelpDesk.TrackerApp.View.ProcessView;
using LeafFilter.HelpDesk.TrackerApp.View.TicketView;
using LeafFilter.HelpDesk.TrackerApp.View.UserView;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<HelpDeskItem> _allItems;
        private ObservableCollection<HelpDeskItem> _helpDeskItems;
        private HelpDeskItem _selectedItem;
        private int _selectedIndex;
        private string _serachKeyword;
                
        public MainWindowViewModel()
        {
            _allItems = GenerateHelpDeskItems();
            FilterItems(null);
            SelectedItem = _allItems[0];
        }

        public ObservableCollection<HelpDeskItem> HelpDeskItems
        {
            get => _helpDeskItems;
            set
            {
                _helpDeskItems = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HelpDeskItems)));
            }
        }

        public HelpDeskItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == null || value.Equals(_selectedItem))
                    return;
                _selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndex)));
            }
        }

        public string SearchKeyword
        {
            get => _serachKeyword;
            set
            {
                _serachKeyword = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchKeyword)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private ObservableCollection<HelpDeskItem> GenerateHelpDeskItems()
            => new ObservableCollection<HelpDeskItem>
            {
                new HelpDeskItem("Ticket View", new TicketView()),
                new HelpDeskItem("Tickets", new TicketListView())
                {
                    VerticalScrollBarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto
                },                  
                new HelpDeskItem("Issues", new IssueListView()),
                new HelpDeskItem("Process", new ProcessListView()),
                new HelpDeskItem("Users", new UserListView())
            };        

        private void FilterItems(string keyword)
        {
            HelpDeskItems = new ObservableCollection<HelpDeskItem>(
                string.IsNullOrWhiteSpace(keyword)
                ? _allItems
                : _allItems.Where(i => i.Name.ToLower().Contains(keyword!.ToLower())));
        }              
    }
}
