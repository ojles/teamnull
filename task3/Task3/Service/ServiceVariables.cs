using System;
using System.IO;
using System.Reflection;

namespace Task3.Service
{
    class ServiceVariables
    {
        private static readonly string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string AssemblyLocation = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string MenuFilePath = Path.Combine(AssemblyLocation, @"..\..\..\Data\Menu.xml");
        public static readonly string DataFolder = Path.Combine(AppDataFolder, "SushiOrdering");
        public static readonly string OrdersFolderPath = Path.Combine(DataFolder, "Orders");
    }
}
