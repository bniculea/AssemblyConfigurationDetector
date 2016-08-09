using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using ApplicationStartup.Model;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ApplicationStartup
{
    public partial class MainWindow : Window
    {
        private string SelectedPath { get; set; }
        private ObservableCollection<AssemblyConfigurationModel> AssemblyModelsCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBrowse_OnClick(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog("Select folder:");
            commonOpenFileDialog.IsFolderPicker = true;
            CommonFileDialogResult result = commonOpenFileDialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                TxtSelectedPath.Text = commonOpenFileDialog.FileName;
                SelectedPath = TxtSelectedPath.Text;
            }
        }

        private void AssemblyConfigurationDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dependencyObject = (DependencyObject)e.OriginalSource;
            while (dependencyObject != null && !(dependencyObject is DataGridCell) &&
                   !(dependencyObject is DataGridColumnHeader))
            {
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            if (dependencyObject == null) return;
            OpenExplorerAtSelectedLocation(dependencyObject);
        }

        private void OpenExplorerAtSelectedLocation(DependencyObject dependencyObject)
        {
            if (dependencyObject is DataGridCell)
            {
                DataGridCell selectedDataGridCell = dependencyObject as DataGridCell;
                ContentPresenter contentPresenter = selectedDataGridCell.Content as ContentPresenter;

                AssemblyConfigurationModel assemblyModel = contentPresenter?.Content as AssemblyConfigurationModel;
                if (assemblyModel != null && File.Exists(assemblyModel.Location))
                {
                    string filePath = Path.GetDirectoryName(assemblyModel.Location);
                    if (filePath != null) Process.Start(filePath);
                }
            }
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void ButtonRun_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsOutputPathSelected())
            {
                EnableControls(false);
               await Task.Run(() =>
                {
                    Controller controller = new Controller(SelectedPath);
                    AssemblyModelsCollection = controller.GetModelsCollection();
                });
                
                DataContext = AssemblyModelsCollection;
                EnableControls(true);
                MessageBox.Show(this, "Running finished!", "Assembly Configuration Detector", MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(this, "Please select a location.", "Assembly Configuration Detector", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
           
        }

        private void EnableControls(bool isEnabled)
        {
            InputPanel.IsEnabled = isEnabled;
            ControlPanel.IsEnabled = isEnabled;
            OutputPanel.IsEnabled = isEnabled;
            ProgressbarStatus.IsIndeterminate = !isEnabled;
        }

        private bool IsOutputPathSelected()
        {
            return !string.IsNullOrEmpty(SelectedPath);
        }
    }
}
