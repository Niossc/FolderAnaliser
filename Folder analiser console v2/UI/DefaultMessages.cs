using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Folder_analiser_console_v2
{
    static class DefaultMessages
    {
        public const string StartMessage = $"Tip: you can use {ShutdownCommand} to exit the app;\n{MenuCommand} to get back to menu;\n/start to... start";

        public const string ShutdownCommand = "/shutdown";
        public const string MenuCommand = "/menu";
    }
}

