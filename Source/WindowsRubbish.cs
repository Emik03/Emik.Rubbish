// SPDX-License-Identifier: MPL-2.0
namespace Emik;
#pragma warning disable S101, SA1307, SA1310
/// <summary>Implementation for trashing files on Windows.</summary>
static class WindowsRubbish
{
    /// <summary><see cref="SHFILEOPSTRUCT"/> for <see cref="WindowsRubbish.SHFileOperationW"/> from <c>COM</c>.</summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct SHFILEOPSTRUCT
    {
        internal nint hwnd;
        internal uint wFunc;
        internal string pFrom, pTo;
        internal ushort fFlags;

        [MarshalAs(UnmanagedType.Bool)]
        internal bool fAnyOperationsAborted;

        internal nint hNameMappings;
        internal string lpszProgressTitle;
    }

    /// <inheritdoc cref="Rubbish.Move"/>
    internal static bool Move(string path)
    {
        const ushort

            // Do not show a dialog during the process.
            FOF_SILENT = 0x0004,

            // Delete the file to the recycle bin. Required flag to send a file to the bin.
            FOF_ALLOWUNDO = 0x0040,

            // Warn if files are too big to fit in the recycle bin and will need to be deleted completely.
            FOF_WANTNUKEWARNING = 0x4000;

        // Delete (or recycle) the objects.
        const uint FO_DELETE = 0x0003;

        var fs = new SHFILEOPSTRUCT
        {
            wFunc = FO_DELETE,
            pFrom = $"{path}\0\0",
            fFlags = FOF_SILENT | FOF_ALLOWUNDO | FOF_WANTNUKEWARNING,
        };

        try
        {
            return SHFileOperationW(ref fs) is 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    [DllImport("shell32.dll", CharSet = CharSet.Unicode, EntryPoint = nameof(SHFileOperationW))]
#pragma warning disable SYSLIB1054 // 'SHFILEOPSTRUCT' is not supported by source-generated P/Invokes.
    static extern int SHFileOperationW(ref SHFILEOPSTRUCT FileOp);
#pragma warning restore SYSLIB1054
}
