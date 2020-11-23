using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.Models.Types;
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
        private Ticket _currentTicket;        
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
            statusComboBox.ItemsSource = _data.LoadTickStatuses().Select(s => s.Name).ToList();
            _ticketViewSource = (ObjectDataProvider)FindResource("ticketViewSource");
            _isLoading = false;
            ticketListBox.SelectedItem = 0;
        }

        private void statusTextBox_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!_isLoading && !_isListChanging)
            {                
                _currentTicket.Status = _data.LoadSingleStatus(statusComboBox.SelectedValue.ToString());
            }
        }

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
            if (_data.ChangesNeedToBeSaved())
            {
                e.Cancel = PromptSaveChanges();
            }
        }



        private void NewTicketButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTicket = _data.CreateNewTicket();
            _ticketViewSource.ObjectInstance = _currentTicket;
            ticketListBox.SelectedItem = _currentTicket;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ticketListBox.SelectedItem = _currentTicket;
            if (_currentTicket.Status.Name == "Done")
            {
                _currentTicket.DateClosed = DateTime.Now;
            }
            _data.SaveChanges();

        }

        private bool PromptSaveChanges()
        {
            string messageBoxText = "There are unsaved changes. Do you want to save them?";
            var result = MessageBox.Show(messageBoxText, "Help Desk Tracker", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            bool cancelOperation = false;
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _data.SaveChanges();
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    cancelOperation = true;
                    break;
            }
            return cancelOperation;
        }

        private void requestByFirstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_isLoading && !_isListChanging)
            {
                if (_currentTicket.RequestedBy == null)
                {
                    _currentTicket.RequestedBy = new User();
                }
                _currentTicket.RequestedBy.FirstName = ((TextBox)sender).Text;
            }
        }

        private void requestByLastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_isLoading && !_isListChanging)
            {                
                if(_currentTicket.RequestedBy == null)
                {
                    _currentTicket.RequestedBy = new User();
                }
                _currentTicket.RequestedBy.LastName = ((TextBox)sender).Text;
            }
        }      

        private void assignedToFirstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_isLoading && !_isListChanging)
            {
                if (_currentTicket.AssignedTo == null)
                {
                    _currentTicket.AssignedTo = new User();
                }
                _currentTicket.AssignedTo.FirstName = ((TextBox)sender).Text;
            }
        }

        private void assignedToLastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_isLoading && !_isListChanging)
            {
                if (_currentTicket.AssignedTo == null)
                {
                    _currentTicket.AssignedTo = new User();
                }
                _currentTicket.AssignedTo.LastName = ((TextBox)sender).Text;
            }
        }
    }
}
