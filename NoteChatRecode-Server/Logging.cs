using System;
using System.IO;

namespace NoteChatRecode_Server
{
    public class Logger
    {
        private static readonly object _lock = new object();
        private static string _logFilePath = "server.log";
        public static bool EnableDebug = true;
        public enum LogLevel
        {
            Info,
            Warning,
            Error,
            Debug
        }

        public static void Log(LogLevel level, string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            Console.WriteLine(logMessage);
            WriteToFile(logMessage);
        }

        public static void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        public static void Warning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        public static void Error(string message)
        {
            Log(LogLevel.Error, message);
        }
        public static void Debug(string message)
        {
            if (EnableDebug)
            {
                Log(LogLevel.Debug, message);
            }
        }

        private static void WriteToFile(string message)
        {
            lock (_lock)
            {
                    File.AppendAllText(_logFilePath, message + Environment.NewLine);
            }
        }
    }
}