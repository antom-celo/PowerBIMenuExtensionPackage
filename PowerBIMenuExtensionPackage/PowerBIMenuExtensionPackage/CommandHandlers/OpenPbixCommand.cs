using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace PowerBIMenuExtension.CommandHandlers
{
    internal sealed class OpenPbixCommand
    {
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("YOUR-GUID-HERE");
        private readonly AsyncPackage package;

        private OpenPbixCommand(AsyncPackage package)
        {
            this.package = package;
        }

        public static async Task InitializeAsync(AsyncPackage package)
        {
            var commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(Execute, menuCommandID);
            commandService?.AddCommand(menuItem);
        }

        private static void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var selectedItem = GetSelectedFilePath();
            if (selectedItem != null && Path.GetExtension(selectedItem).Equals(".pbix", StringComparison.OrdinalIgnoreCase))
            {
                Process.Start("powerbi://", selectedItem);
            }
        }

        private static string GetSelectedFilePath()
        {
            // Implementace získání cesty k vybranému souboru v Solution Exploreru
            return null; // TODO: Implementovat
        }
    }
}
