namespace Folder_analiser_console_v2
{
    public class DirModel
    {
        public string Name { get; set; }
        public string? Path { get; set; }
        public long Size { get; set; }
        public List<DirModel> SubDirectories { get; set; }

        public DirModel(string path, long size)
        {
            Name = System.IO.Path.GetFileName(path);
            Path = path;
            Size = size;
            SubDirectories = new List<DirModel>();
        }
    }
}
