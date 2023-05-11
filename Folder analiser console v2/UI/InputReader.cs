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
                        case "/start":
                            StartAnalising();
                            break;

                        default:
                            Console.WriteLine("Command not found");
                            break;
                    }
                }

            }
        }
        private void StartAnalising()
        {
            string? path = "";

            while (true)
            {
                Console.WriteLine("Enter directory size:");
                path = Console.ReadLine();

                if (!CheckIsDefaultCommand(path))
                {
                    if (!Directory.Exists(path))
                    {
                        Console.WriteLine("Directory doesn't exist");
                        continue;
                    }

                    long directorySize = FileSystemInfoProvider.GetDirectorySize(path);
                    string userFriendlySize = ValueConverter.BytesToUserFriendly(directorySize);
                    Console.WriteLine(userFriendlySize);
                }
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
