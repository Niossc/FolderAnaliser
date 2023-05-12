using System.Net.Http.Headers;
using System.Reflection.Metadata;

namespace Folder_analiser_console_v2
{
    public class InputReader
    {
        public void OpenMenu()
        {
            Console.WriteLine(DefaultMessages.StartMessage);

            string? userMessage;
            while (true)
            {
                userMessage = Console.ReadLine().Replace(" ", string.Empty).ToLower();

                if (!CheckIsDefaultCommand(userMessage))
                {
                    switch (userMessage)
                    {
                        case DefaultMessages.DirectoryModeCommand:
                            StartAnalisingDirectories();
                            break;
                        case DefaultMessages.DriveModeCommand:
                            StartAnalisingDrives();
                            break;
                        default:
                            Console.WriteLine("Command not found");
                            break;
                    }
                }

            }
        }
        private void StartAnalisingDirectories()
        {
            string? path = "";

            while (true)
            {
                Console.WriteLine("Enter directory path:");
                path = Console.ReadLine();
                if (CheckIsDefaultCommand(path))
                {
                    return;
                }

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Directory doesn't exist");
                    continue;
                }

                DirModel dirModel = FileSystemInfoProvider.CreateDirectoryTree(path);
                Console.WriteLine(OutputConverter.DirTreeToUserFriendly(dirModel));
            }
        }

        private void StartAnalisingDrives()
        {
            string? path = "";

            while (true)
            {
                Console.WriteLine("Enter drive path:");
                path = Console.ReadLine();
                if (CheckIsDefaultCommand(path))
                {
                    return;
                }

                if (!FileSystemInfoProvider.IsDrive(path))
                {
                    Console.WriteLine("Drive not found");
                    continue;
                }

                DriveModel driveModel = FileSystemInfoProvider.GetDriveModel(path);
                Console.WriteLine(OutputConverter.DriveModelToUserFriendly(driveModel));
            }
        }
        
        public bool CheckIsDefaultCommand(string? userCommand)
        {
            switch (userCommand)
            {
                case DefaultMessages.ShutdownCommand:
                    Environment.Exit(0);
                    return true;
                case DefaultMessages.MenuCommand:
                    OpenMenu();
                    return true;
                default:
                    return false;
            }
        }
    }
}
