using GridSteamworksCommon;
using Steamworks;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LobbyManagement
{
    internal static class Program
    {
        const int gridAppId = 44350;

        public static FontFamily FontAwesome { get; private set; }
        public static ulong UserId { get; private set; }

        [STAThread]
        static void Main()
        {
            if (!SteamAPI.IsSteamRunning())
            {
                return;
            }
            File.WriteAllText("steam_appid.txt", gridAppId.ToString());
            if (!SteamAPI.Init())
            {
                throw new Exception("steam api not initialized");
            }
            UserId = SteamUser.GetSteamID().m_SteamID;
            try
            {
                using PrivateFontCollection pfc = new();
                using var fontHandle = EmbeddedResourseManager.LoadFontAwesome(pfc);
                var families = pfc.Families;
                using var fontAwesome = families[0];
                FontAwesome = fontAwesome;

                using var runner = new SteamCallbackRunner();
                var query = new SteamDataContinuousQuery<LobbyMatchList_t>(SteamMatchmaking.RequestLobbyList, runner);
                using var enumerator = query.GetEnumerator();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using var form = new Form1(enumerator);
                Application.Run(form);
            }
            finally
            {
                SteamAPI.Shutdown();
            }
        }
    }

    public static class EmbeddedResourseManager
    {
        private static readonly string resPrefix = $"{nameof(LobbyManagement)}.Resources.";

        private static unsafe T ProcessResource<T>(string resName, Func<IntPtr, int, T> func)
        {
            var assembly = typeof(EmbeddedResourseManager).Assembly;
            using Stream stream = assembly.GetManifestResourceStream(resPrefix + resName);
            var length = (int)stream.Length;
            if (stream is UnmanagedMemoryStream unmanagedResourceStream)
            {
                var ptr = new IntPtr(unmanagedResourceStream.PositionPointer);
                return func(ptr, length);
            }
            else
            {
                var buffer = Marshal.AllocHGlobal(length);
                try
                {
                    using UnmanagedMemoryStream ums = new((byte*)buffer, stream.Length);
                    stream.CopyTo(ums);
                    return func(buffer, length);
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }

        public static SafeHandle LoadFontAwesome(PrivateFontCollection fc) => ProcessResource("fa-solid-900.ttf", (ptr, len) =>
        {
            int num = 0;
            //not directly used in code, but if font is not registered with this function,
            //it requires UseCompatibleTextRendering, manual antialiasing when painting, etc.
            var handle = GdiInterop.AddFontMemResourceEx(ptr, len, default, ref num);

            fc.AddMemoryFont(ptr, len);
            return handle;
        });
    }
}

