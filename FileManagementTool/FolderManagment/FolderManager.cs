// FolderManagement/FolderManager.cs
using System;
using System.IO;

namespace FileManagementTool.FolderManagement
{
    public class FolderManager
    {
        public string CreateTimestampedFolder(string basePath, string prefix = "Organized Files")
        {
            if (string.IsNullOrWhiteSpace(basePath))
            {
                // Default to Desktop if basePath is not provided
                basePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            // Ensure base directory exists
            if (!Directory.Exists(basePath))
            {
                throw new DirectoryNotFoundException($"Base directory not found: {basePath}");
            }

            // Generate timestamp (format: Organized Files_2024-01-15_14-30-00)
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            // Clean up prefix (remove invalid characters)
            string cleanPrefix = CleanFolderName(prefix);
            string folderName = $"{cleanPrefix}_{timestamp}";
            string fullPath = Path.Combine(basePath, folderName);

            return CreateFolder(fullPath);
        }

        public string CreateFolder(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine($"Created folder: {folderPath}");
                }
                return folderPath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating folder '{folderPath}': {ex.Message}", ex);
            }
        }

        private string CleanFolderName(string folderName)
        {
            // Remove invalid characters from folder name
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidChars)
            {
                folderName = folderName.Replace(c.ToString(), "");
            }

            // Trim and ensure not empty
            folderName = folderName.Trim();
            if (string.IsNullOrEmpty(folderName))
            {
                folderName = "Organized";
            }

            return folderName;
        }

        public bool IsFolderWritable(string folderPath)
        {
            try
            {
                // Test if we can create and delete a file in the folder
                string testFile = Path.Combine(folderPath, "write_test.tmp");
                File.WriteAllText(testFile, "test");
                File.Delete(testFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public long GetFolderSize(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                return 0;

            long size = 0;
            var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                try
                {
                    var fileInfo = new FileInfo(file);
                    size += fileInfo.Length;
                }
                catch
                {
                    // Skip files we can't access
                }
            }

            return size;
        }

        // Helper method to get common system folders
        public string GetDesktopPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public string GetDocumentsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public string GetDownloadsPath()
        {
            // Note: Environment.SpecialFolder.MyDownloads is only available in .NET 8+
            // For older .NET, we can use a common path
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        }
    }
}