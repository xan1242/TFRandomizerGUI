using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace TFRandomizerGUI
{
    internal static class Program
    {
#if DEBUG
        internal static class NativeMethods
        {
            // http://msdn.microsoft.com/en-us/library/ms681944(VS.85).aspx
            /// <summary>
            /// Allocates a new console for the calling process.
            /// </summary>
            /// <returns>nonzero if the function succeeds; otherwise, zero.</returns>
            /// <remarks>
            /// A process can be associated with only one console,
            /// so the function fails if the calling process already has a console.
            /// </remarks>
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern int AllocConsole();

            // http://msdn.microsoft.com/en-us/library/ms683150(VS.85).aspx
            /// <summary>
            /// Detaches the calling process from its console.
            /// </summary>
            /// <returns>nonzero if the function succeeds; otherwise, zero.</returns>
            /// <remarks>
            /// If the calling process is not already attached to a console,
            /// the error code returned is ERROR_INVALID_PARAMETER (87).
            /// </remarks>
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern int FreeConsole();
        }
#endif
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
#if DEBUG
            NativeMethods.AllocConsole();
#endif
            Application.Run(new Form1());
#if DEBUG
            NativeMethods.FreeConsole();
#endif
        }
    }

    public static class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }

            return value.ToString();
        }
    }


    public class GameInfo
    {
        public enum GameType
        {
            [Description("Tag Force 3 (ULES-01183)")]
            TF3_EU,

            [Description("Tag Force 5 (ULUS-10555)")]
            TF5_US,
        }

        public static Dictionary<GameType, string> GameShortNames = new Dictionary<GameType, string>()
        {
            { GameType.TF3_EU , "TF3_EU"},
            { GameType.TF5_US , "TF5_US"},
        };
    }

    public class GameShopInfo
    {
        public int BoxInfoOffset;
        public int SegmentOffset;
        public int BoxCount;

        public static Dictionary<GameInfo.GameType, int> BoxInfoOffsets = new Dictionary<GameInfo.GameType, int>()
        {
            { GameInfo.GameType.TF3_EU , 0x2031C},
            { GameInfo.GameType.TF5_US , 0x23090},
        };

        public static Dictionary<GameInfo.GameType, int> SegmentOffsets = new Dictionary<GameInfo.GameType, int>()
        {
            { GameInfo.GameType.TF3_EU , 0x54},
            { GameInfo.GameType.TF5_US , 0x54},
        };

        public static Dictionary<GameInfo.GameType, int> BoxCounts = new Dictionary<GameInfo.GameType, int>()
        {
            {  GameInfo.GameType.TF3_EU , 48},
            {  GameInfo.GameType.TF5_US , 60},
        };

        GameShopInfo()
        {
            BoxInfoOffset = 0;
            SegmentOffset = 0;
            BoxCount = 0;
        }
    }
}