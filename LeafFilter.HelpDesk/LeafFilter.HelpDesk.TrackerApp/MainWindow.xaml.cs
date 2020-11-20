using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Models.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LeafFilter.HelpDesk.TrackerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ConnectedData _data = new ConnectedData();
        //private readonly HelpDeskContext _context = new HelpDeskContext();
        private Ticket _currentTicket;
        private User _currentUser;
        private bool _isListChanging;
        private bool _isLoading;
        private ObjectDataProvider _ticketViewSource;        

        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _isLoading = true;            
            ticketListBox.ItemsSource = _data.TicketsListInMemory();
            _ticketViewSource = (ObjectDataProvider)FindResource("ticketViewSource");
            _isLoading = false;
            ticketListBox.SelectedItem = 0;                        
        }

        //private void userListBox_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        //{            
        //}

        private void ticketListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_isLoading)
            {
                _isListChanging = true;
                _currentTicket = _data.LoadTicket((Guid)ticketListBox.SelectedValue);
                _ticketViewSource.ObjectInstance = _currentTicket;
                _isListChanging = false;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
