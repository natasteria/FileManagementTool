// ErrorHandling/ErrorLogger.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManagementTool.ErrorHandling
{
    public class ErrorLogger
    {
        private static ErrorLogger _instance;
        private readonly List<LogEntry> _logEntries;
        private readonly string _logFilePath;

        // Singleton pattern - only one logger instance
        public static ErrorLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ErrorLogger();
                }
                return _instance;
            }
        }

        private ErrorLogger()
        {
            _logEntries = new List<LogEntry>();

            // Create log file in AppData
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(appDataPath, "FileManagementTool", "Logs");

            // Ensure directory exists
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }

            // Create log file with timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            _logFilePath = Path.Combine(appFolder, $"log_{timestamp}.txt");

            // Write initial log header
            WriteToFile($"=== File Management Tool Log ===\r\nStarted: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n\r\n");
        }

        public void LogError(string message, Exception exception = null)
        {
            string fullMessage = message;
            if (exception != null)
            {
                fullMessage += $"\r\nException: {exception.Message}\r\nStack Trace: {exception.StackTrace}";
            }

            AddLogEntry(LogLevel.Error, fullMessage);
        }

        public void LogWarning(string message)
        {
            AddLogEntry(LogLevel.Warning, message);
        }

        public void LogInfo(string message)
        {
            AddLogEntry(LogLevel.Info, message);
        }

        public void LogOperation(string operation, string details = "")
        {
            string message = $"Operation: {operation}";
            if (!string.IsNullOrEmpty(details))
            {
                message += $"\r\nDetails: {details}";
            }

            AddLogEntry(LogLevel.Info, message);
        }

        public void LogFileOperation(string fileName, string operation, bool success, string message = "")
        {
            string status = success ? "SUCCESS" : "FAILED";
            string logMessage = $"{operation}: {fileName} - {status}";

            if (!string.IsNullOrEmpty(message))
            {
                logMessage += $" ({message})";
            }

            AddLogEntry(success ? LogLevel.Info : LogLevel.Error, logMessage);
        }

        private void AddLogEntry(LogLevel level, string message)
        {
            var entry = new LogEntry
            {
                Timestamp = DateTime.Now,
                Level = level,
                Message = message
            };

            _logEntries.Add(entry);

            // Write to file immediately
            string logLine = $"[{entry.Timestamp:yyyy-MM-dd HH:mm:ss}] {level.ToString().ToUpper()}: {message}\r\n";
            WriteToFile(logLine);

            // Also write to console for debugging
            Console.WriteLine(logLine.Trim());
        }

        private void WriteToFile(string content)
        {
            try
            {
                File.AppendAllText(_logFilePath, content);
            }
            catch (Exception ex)
            {
                // If we can't write to file, at least show in console
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }

        public string GetLogSummary()
        {
            int errorCount = 0;
            int warningCount = 0;
            int infoCount = 0;

            foreach (var entry in _logEntries)
            {
                switch (entry.Level)
                {
                    case LogLevel.Error:
                        errorCount++;
                        break;
                    case LogLevel.Warning:
                        warningCount++;
                        break;
                    case LogLevel.Info:
                        infoCount++;
                        break;
                }
            }

            return $"Total entries: {_logEntries.Count} (Errors: {errorCount}, Warnings: {warningCount}, Info: {infoCount})";
        }

        public string GetFullLog()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== File Management Tool - Complete Log ===");
            sb.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine();

            foreach (var entry in _logEntries)
            {
                sb.AppendLine($"[{entry.Timestamp:yyyy-MM-dd HH:mm:ss}] {entry.Level.ToString().ToUpper()}: {entry.Message}");
            }

            return sb.ToString();
        }

        public List<LogEntry> GetErrorEntries()
        {
            return _logEntries.FindAll(e => e.Level == LogLevel.Error);
        }

        public List<LogEntry> GetWarningEntries()
        {
            return _logEntries.FindAll(e => e.Level == LogLevel.Warning);
        }

        public void ClearLog()
        {
            _logEntries.Clear();

            // Start a new log file
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(appDataPath, "FileManagementTool", "Logs");
            string newLogFilePath = Path.Combine(appFolder, $"log_{timestamp}.txt");

            // In a real app, you might want to keep the old log
            // For simplicity, we'll just note that log was cleared
            WriteToFile($"=== Log cleared at {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===\r\n");
        }

        public string GetLogFilePath()
        {
            return _logFilePath;
        }

        // Helper method to open log folder
        public void OpenLogFolder()
        {
            try
            {
                string logFolder = Path.GetDirectoryName(_logFilePath);
                if (Directory.Exists(logFolder))
                {
                    System.Diagnostics.Process.Start("explorer.exe", logFolder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to open log folder: {ex.Message}");
            }
        }
    }

    // Supporting classes
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
    }
}