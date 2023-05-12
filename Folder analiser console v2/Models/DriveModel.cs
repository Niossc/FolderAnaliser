using System.Xml.Linq;

namespace Folder_analiser_console_v2
{ 
    public class DriveModel
    {
        public string Letter { get; set; }
        public string Name { get; set; }
        public long FreeSpace { get; set; }
        public long AvaibleSpace { get; set; }
        public string FileSystem { get; set; }

        public void Deconstruct(out string letter, out string name, out long freeSpace, out long avaibleSpace, out string fileSystem)
        {
            letter = Letter;
            name = Name;
            freeSpace = FreeSpace;
            avaibleSpace = AvaibleSpace;
            fileSystem = FileSystem;          
        }
    }
}
