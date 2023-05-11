namespace Folder_analiser_console_v2
{
    public static class ValueConverter
    {
        private static string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
        public static string BytesToUserFriendly(long size)
        {
            decimal convertedSize = size;
            int suffix = 0;
            while (convertedSize >= 1024 & suffix < 4)
            {
                convertedSize = (convertedSize / 1024);
                convertedSize = Math.Round(convertedSize, 2);
                suffix++;
            }

            return $"{convertedSize} {suffixes[suffix]}";
        }
    }
}
