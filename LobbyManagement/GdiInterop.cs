using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace LobbyManagement
{
    static class GdiInterop
    {
        private const string Gdi32 = "gdi32.dll";

        [DllImport(Gdi32, ExactSpelling = true, SetLastError = false)]
        public static extern SafeFontMemResourceHandle AddFontMemResourceEx(IntPtr pFileView, int cjSize, IntPtr pvResrved, [In] ref int pNumFonts);

        [DllImport(Gdi32, ExactSpelling = true, SetLastError = false)]
        public static extern bool RemoveFontMemResourceEx(IntPtr h);

        public class SafeFontMemResourceHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public SafeFontMemResourceHandle() : base(true)
            { }

            protected override bool ReleaseHandle()
            {
                return RemoveFontMemResourceEx(handle);
            }
        }
    }
}

