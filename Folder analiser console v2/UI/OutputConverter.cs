using System.Security.Cryptography.X509Certificates;

namespace Folder_analiser_console_v2
{
    public static class OutputConverter
    {
        private static string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
        public static string BytesToUserFriendly(long size)
        {
            int suffix = 0;
            double convertedSize = size;
            for (int level = 4; level > 0; level--)
            {
                double oneUnitInPower =  Math.Pow(1024, level);
                if (size >= oneUnitInPower)
                {
                    convertedSize = Math.Round(size / oneUnitInPower, 2);
                    suffix = level;
                    break;
                }
            }
            return $"{convertedSize} {suffixes[suffix]}";
        }

        public static string DriveModelToUserFriendly(DriveModel driveModel)
        {
            (string letter, string name, long freeSpace, long avaibleSpace, string fileSystem) = driveModel;
            string message = $"Drive name: {letter}\n\nFreeSpace: {BytesToUserFriendly(freeSpace)}\nAvaibleSpace: " +
                $"{BytesToUserFriendly(avaibleSpace)}\nFileSystem{fileSystem}\n";
            return message;
        }

        public static string DirTreeToUserFriendly(DirModel mainDir)
        {
            List<DirModel> sorted = mainDir.SubDirectories.OrderByDescending(x => x.Size).ToList();
            string convertedTree = CreateDirTreeLine(mainDir.Name, mainDir.Size);

            int maxDirNameSize = mainDir.SubDirectories.Max(x => x.Name.Length);
            foreach (DirModel subdir in sorted)
            {
                convertedTree += CreateDirTreeLine(subdir.Name, subdir.Size, 1, maxDirNameSize - subdir.Name.Length);
            }
            return convertedTree;
        }

        private static string CreateDirTreeLine(string name, long size, int levelIndent = 0, int alignmentIndentSize = 0)
        {
            return new string(Configuration.IndentChar, levelIndent * Configuration.IndentSize) + name + new string(' ', Configuration.AfterNameIndentSize + alignmentIndentSize) + BytesToUserFriendly(size) + '\n';
        }
    }
}
