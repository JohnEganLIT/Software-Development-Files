using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.InteropServices;

// ************************************************************************
// Event Logger Manager Class
// All events are logged to file both locally on the Client and remotely on
// the Server. The Servers log is considerred the Master Log.
// ************************************************************************
namespace Security {
    public class Logger {
        public bool Echo;
        public StreamWriter log;
        private string user;
        private Dictionary<string, ConsoleColor> color;
        private Object locker;
        private string lastEntry;

        public Logger() {
            Echo = true;
            user = "null";
            locker = new Object();
            lastEntry = "";

            color = new Dictionary<string, ConsoleColor>();
            color.Add("DEBUG", ConsoleColor.DarkYellow);
            color.Add("INFO", ConsoleColor.Cyan);
            color.Add("TEST", ConsoleColor.Blue);
            color.Add("SEND", ConsoleColor.Green);
            color.Add("RECV", ConsoleColor.Green);
            color.Add("PASS", ConsoleColor.Green);
            color.Add("WARN", ConsoleColor.Yellow);
            color.Add("FAIL", ConsoleColor.Red);
            color.Add("ALERT", ConsoleColor.Yellow);
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        public void Show() {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_SHOW);
        }

        public void Hide() {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }

        public bool Open(string path) {
            try { log = File.AppendText(@path); } catch { return false; }

            try {
                Info("Starting Up\r\n");
            } catch { return false; }
            return true;
        }

        public bool Close() {
            try {
                Info("Shutting Down");
                log.Close();
            } catch { return false; }
            return true;
        }

        public void SetUser(string userid) {
            user = userid;
        }

        public string GetLastEntry() {
            return lastEntry;
        }

        public void Debug(string format, params object[] optional) {
            if (format == null) return;
            Write("DEBUG", format, optional);
        }

        public void Info(string format, params object[] optional) {
            if (format == null) return;
            Write("INFO", format, optional);
        }

        public void Test(string format, params object[] optional) {
            if (format == null) return;
            Write("TEST", format, optional);
        }

        public void Send(string format, params object[] optional) {
            if (format == null) return;
            Write("SEND", format, optional);
        }

        public void Recv(string format, params object[] optional) {
            if (format == null) return;
            Write("RECV", format, optional);
        }

        public void Pass(string format, params object[] optional) {
            if (format == null) return;
            Write("PASS", format, optional);
        }

        public void Warn(string format, params object[] optional) {
            if (format == null) return;
            Write("WARN", format, optional);
        }

        public void Fail(string format, params object[] optional) {
            if (format == null) return;
            Write("FAIL", format, optional);
        }

        public bool Alert(string format, params object[] optional) {
            if (format == null) return false;
            Write("ALERT", format, optional);
            return false;
        }

        private void Write(string tag, string f, params object[] o) {

            // strip out newlines and tabs
            string format = Regex.Replace(f, @"\t|\n|\r", " ");
            string[] args = new string[o.Length];
            for (int i = 0; i < o.Length; i++) {
                args[i] = Regex.Replace(o[i].ToString(), @"\t|\n|\r", " ");
            }

            // formatted prefix
            string info = (args.Length > 0)
                ? string.Format(format + "\r\n", args)
                : string.Format(format + "\r\n");
            string text = string.Format("{0} {1}",
                    DateTime.Now.ToShortDateString(),
                    DateTime.Now.ToLongTimeString());

            lastEntry = string.Format("{0} {1} [{2}] {3}", text, user, tag, info);

            // commit to file
            try {
                locker = "FileIO";
                lock (locker) {
                    log.Write("{0} [{1}] {2}", text, tag, info);
                    log.Flush();
                }

                if (Echo) {
                    locker = "Console";
                    lock (locker) {
                        Console.Write("{0} ", text);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("[{0}] ", user);
                        Console.ForegroundColor = color[tag];
                        Console.Write("[{0}] ", tag);
                        Console.ResetColor();
                        Console.Write("{0}", info);
                    }
                }

                if (tag == "Alert") MessageBox.Show(info);
            } catch { }
        }
    }
}
