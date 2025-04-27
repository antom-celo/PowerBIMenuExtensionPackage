using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace PowerBIMenuExtension
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(PowerBIMenuExtensionPackage.PackageGuidString)]
    public sealed class PowerBIMenuExtensionPackage : AsyncPackage
    {
        public const string PackageGuidString = "d0c1f3a4-1f3a-4f3a-9f3a-1f3a1f3a1f3a";

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);
            await OpenPbixCommand.InitializeAsync(this);
        }
    }
}