using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
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
                
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            

        }

        private void ButtonRun_OnClick(object sender, RoutedEventArgs e)
        {
           Controller controller = new Controller(SelectedPath);
           AssemblyModelsCollection = controller.GetModelsCollection();
           DataContext = AssemblyModelsCollection;
        }
    }
}
