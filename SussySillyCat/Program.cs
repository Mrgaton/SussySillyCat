using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SussySillyCat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("kernel32.dll")] private static extern bool AttachConsole(int pid);
        [DllImport("user32.dll")] private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [STAThread]
        static void Main()
        {
            //if (!AttachConsole(-1)) AllocConsole();


            /*var newOut = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
            Console.SetOut(newOut);
            Console.SetError(newOut);

            var ptr = GetConsoleWindow();*/

            //SetWindowLong(ptr, -16, 0x50000000);
            //SetWindowPos(ptr, IntPtr.Zero, 0, 0, 300, 300, 0);


            using (var s = File.OpenRead(Assembly.GetExecutingAssembly().Location))
            {
                var startPos = (s.Length / 2) + ((s.Length / 5) * 2);

                RawAudioPlayer.PlayRawPCMData(File.ReadAllBytes(Assembly.GetExecutingAssembly().Location).Take(16000 * 2).ToArray(), 16000 / 2, 2, 8);
                s.Position = startPos;
                s.CopyTo(Console.OpenStandardOutput());
            }

            ShowWindow(GetConsoleWindow(), 0);

            Console.WriteLine("dsfsdfd");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CatForm());
        }
    }
}
