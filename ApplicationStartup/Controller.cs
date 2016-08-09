using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Markup;
using ApplicationStartup.Model;
using AssemblyConfigurationDetector;
using DirectoryUtilities;

namespace ApplicationStartup
{
    public class Controller
    {
        private string SelectedPath { get; set; }

        public Controller(string selectedPath)
        {
            SelectedPath = selectedPath;
        }


        private List<string> GetFiles()
        {
            FilesFinder filesFinder = new FilesFinder(new ExtensionFilterCondition(".dll"));
            return filesFinder.GetFiles(SelectedPath);
        }

        public ObservableCollection<AssemblyConfigurationModel> GetModelsCollection()
        {
            ObservableCollection<AssemblyConfigurationModel> modelsCollection = new ObservableCollection<AssemblyConfigurationModel>();
            FileNameExtractor fileNameExtractor = new FileNameExtractor();
            int id = 1;
            foreach (string assemblyPath in GetFiles())
            {
                string assemblyName = fileNameExtractor.Extract(assemblyPath);
                string architecture = GetAssemblyArchitecture(assemblyPath);
                string location = assemblyPath;
                modelsCollection.Add(new AssemblyConfigurationModel(id++,assemblyName, architecture, location));
            }
            return modelsCollection;
            
        }

        private string GetAssemblyArchitecture(string assemblyPath)
        {
            CorFlagsReader corFlagsReadear = CorFlagsReader.ReadAssemblyMetadata(assemblyPath);
            if (corFlagsReadear == null)
                return GeneralMachineType.Invalid.ToString();
            return corFlagsReadear.GetGeneralMachineType().ToString();
        }
    }
}