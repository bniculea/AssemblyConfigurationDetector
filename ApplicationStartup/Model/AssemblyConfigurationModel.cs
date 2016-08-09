using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationStartup.Model
{
    public class AssemblyConfigurationModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }
        public string Architecture { get; set; }
        public string Location { get; set; }

        public AssemblyConfigurationModel(int id, string fileName, string architecture, string location)
        {
            Id = id;
            FileName = fileName;
            Architecture = architecture;
            Location = location;
        }
    }
}
