using Scripting;

namespace Folder_analiser_console_v2
{
    public static class FileSystemInfoProvider
    {
        public static long GetDirectorySize(string path)
        {
            FileSystemObject fso = new FileSystemObject();
            var directory = fso.GetFolder(path);

            long size = 0;
            //bytes
            try
            {
                size = (long)directory.Size;
            }
            catch(System.Security.SecurityException)
            {
                return 0;
            }
            return size;
        }
    }
}
