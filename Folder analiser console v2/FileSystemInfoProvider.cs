using Scripting;

namespace Folder_analiser_console_v2
{
    public static class FileSystemInfoProvider
    {
        static FileSystemObject fso = new FileSystemObject();
        public static DirModel CreateDirectoryTree(string path)
        {
            var mainDir = new DirModel(path, 0);
            long totalSize = 0;

            string[] subDirectories = Directory.GetDirectories(path);
            foreach (string subPath in subDirectories)
            {
                if (IsSystemObject(subPath)) continue;    
                DirModel subDir = GetDirModel(subPath);
                totalSize += subDir.Size;
                mainDir.SubDirectories.Add(subDir);
            }
            mainDir.Size = totalSize;

            return mainDir;
        }
        public static DirModel GetDirModel(string path)
        {
            DirModel dirModel = new DirModel(path, 0)
            {
                Size = GetObjectSize(path),
            };
            return dirModel;
        }
        public static long GetObjectSize(string path)
        {
            var directory = fso.GetFolder(path);

            long size = 0;
            //bytes
            try
            {
                size = (long)directory.Size;
            }
            catch (System.Security.SecurityException)
            {
                return 0;
            }
            return size;
        }
        public static bool IsDrive(string path)
        {
            return fso.DriveExists(path);
        }
        public static DriveModel GetDriveModel(string path)
        {
            var drive = fso.GetDrive(path);
            DriveModel driveModel = new DriveModel()
            {
                Letter = drive.DriveLetter,
                Name = drive.ShareName,
                FreeSpace = (long)drive.FreeSpace,
                AvaibleSpace = (long)drive.AvailableSpace,
                FileSystem = drive.FileSystem
            };

            return driveModel;
        }
        private static bool IsSystemObject(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            var atb = dirInfo.Attributes;

            if (atb.HasFlag(FileAttributes.System))
                return true;
            return false;
        }
    }
}
