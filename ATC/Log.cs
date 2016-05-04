using System;

namespace ATC
{
    class Log
    {
        public enum LogType
        {
            DEBUG,
            ERROR,
            INFO,
            WARNING,
            VERBOSE
        };

        private void output(string str)
        {
            Console.WriteLine(str);
        }

        private static String getTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss::ffff");
        }

        public void log(string str, LogType t)
        {
            output(getTimestamp() + "\t" + t.ToString() + ":\t" + str);
        }

        // Log a debug message
        public void d(string str)
        {
            log(str, LogType.DEBUG);
        }

        // Log an error
        public void e(string str)
        {
            log(str, LogType.ERROR);
        }

        // Log a warning
        public void w(string str)
        {
            log(str, LogType.WARNING);
        }

        // Log a notification / info
        public void i(string str)
        {
            log(str, LogType.INFO);
        }

        // Log a verbose message
        public void v(string str)
        {
            log(str, LogType.VERBOSE);
        }
    }
}
