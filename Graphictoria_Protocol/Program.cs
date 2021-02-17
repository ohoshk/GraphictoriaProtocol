using Microsoft.Win32;
using System;

namespace Graphictoria_Protocol
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Graphictoria 2008 Protocol Installer";
            Console.WriteLine("Installing Graphictoria 2008...");
            try
            {
                const string protocolValue = "GraphictoriaClient2";
                Registry.SetValue(
                    @"HKEY_CLASSES_ROOT\GraphictoriaClient2",
                    string.Empty,
                    protocolValue,
                    RegistryValueKind.String);
                Registry.SetValue(
                    @"HKEY_CLASSES_ROOT\GraphictoriaClient2",
                    "URL Protocol",
                    String.Empty,
                    RegistryValueKind.String);

                const string binaryName = "Launcher.exe";
                string command = string.Format("\"{0}{1}\" \"%1\"", AppDomain.CurrentDomain.BaseDirectory, binaryName);
                Registry.SetValue(@"HKEY_CLASSES_ROOT\GraphictoriaClient2\shell\open\command", string.Empty, command, RegistryValueKind.String);
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\GraphictoriaClient2",
                    string.Empty,
                    protocolValue,
                    RegistryValueKind.String);
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\GraphictoriaClient2\shell\open\command",
                    string.Empty,
                    command,
                    RegistryValueKind.String);

                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\GraphictoriaClient2\Capabilities\URLAssociations",
                    "GraphictoriaClient2",
                    "GraphictoriaClient2",
                    RegistryValueKind.String);
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\RegisteredApplications",
                    "Graphictoria2008",
                    @"SOFTWARE\GraphictoriaClient2\Capabilities",
                    RegistryValueKind.String);

                Console.WriteLine("Graphictoria 2008 has been installed. Press any key to exit this window.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Could not install Graphictoria because access has been denied. Try running again but as an administrator.");
                Console.ReadKey();
            }
        }
    }
}
