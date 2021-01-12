using LeafFilter.HelpDesk.TrackerApp.View._Navigation;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LeafFilter.HelpDesk.TrackerApp.View
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;

            LightModeToggleButton.IsChecked = new PaletteHelper().GetTheme().Equals(Theme.Light);
        }

        #region Events / Actions
        private void HelpDeskItemListBox_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar)
                    return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            MenuToggleButton.IsChecked = false;
        }

        private async void MenuImportButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dialogView = new OkCancelDialogView()
            {
                Message = { Text = ((ButtonBase)sender).Content.ToString() }
            };
            var result = (bool)await DialogHost.Show(dialogView, "RootDialog");
            if (result)
                Console.WriteLine("ERROR: Not Implemented Yet!");
        }

        private async void MenuExportButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dialogView = new OkCancelDialogView()
            {
                Message = { Text = ((ButtonBase)sender).Content.ToString() }
            };
            var result = (bool)await DialogHost.Show(dialogView, "RootDialog");
            if (result)
                Console.WriteLine("ERROR: Not Implemented Yet!");
        }

        private async void MenuSaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dialogView = new OkCancelDialogView()
            {
                Message = { Text = ((ButtonBase)sender).Content.ToString() }        
            };
            var result = (bool)await DialogHost.Show(dialogView, "RootDialog");
            if (result)
                Console.WriteLine("ERROR: Not Implemented Yet!");
        }

        private async void MenuQuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            var quitDialog = new OkCancelDialogView()
            {
                Message = { Text = ((ButtonBase)sender).Content.ToString() }
            };
            var result = (bool)await DialogHost.Show(quitDialog, "RootDialog");
            if (result)
                Environment.Exit(0);
        }

        private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
            => HelpDeskSearchBox.Focus();

        private void MenuLightModeButton_Click(object sender, RoutedEventArgs e)
            => ModifyTheme(LightModeToggleButton.IsChecked == true);

        #endregion

        #region Helper Methods
        /// <summary>
        /// Updates the base theme to the opposite of the current base theme
        /// </summary>
        /// <param name="isLightTheme"></param>
        private static void ModifyTheme(bool isLightTheme)
        {
            var palatteHelper = new PaletteHelper();
            var theme = palatteHelper.GetTheme();

            theme.SetBaseTheme(isLightTheme ? Theme.Dark : Theme.Light);
            palatteHelper.SetTheme(theme);
        }
        #endregion
    }
}
