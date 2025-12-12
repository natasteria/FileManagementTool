// FileManagement/FileScanner.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace FileManagementTool.FileManagement
{
    public class FileScanner
    {
        public List<ScannedFile> ScanFiles(string sourcePath)
        {
            var fileList = new List<ScannedFile>();

            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new ArgumentException("Source path cannot be empty.");
            }

            if (!Directory.Exists(sourcePath))
            {
                throw new DirectoryNotFoundException($"Source directory not found: {sourcePath}");
            }

            try
            {
                // Get all files in the directory (non-recursive)
                string[] allFiles = Directory.GetFiles(sourcePath, "*.*", SearchOption.TopDirectoryOnly);

                foreach (string filePath in allFiles)
                {
                    try
                    {
                        var fileInfo = new FileInfo(filePath);

                        // Skip hidden/system files
                        if ((fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ||
                            (fileInfo.Attributes & FileAttributes.System) == FileAttributes.System)
                        {
                            continue;
                        }

                        var scannedFile = new ScannedFile
                        {
                            FullPath = filePath,
                            FileName = fileInfo.Name,
                            Extension = fileInfo.Extension.ToLower(),
                            SizeInBytes = fileInfo.Length,
                            LastModified = fileInfo.LastWriteTime
                        };

                        fileList.Add(scannedFile);
                    }
                    catch (Exception ex)
                    {
                        // Skip files we can't access and continue with others
                        Console.WriteLine($"Skipped file {filePath}: {ex.Message}");
                        continue;
                    }
                }

                return fileList;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error scanning directory '{sourcePath}': {ex.Message}", ex);
            }
        }
    }

    public class ScannedFile
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long SizeInBytes { get; set; }
        public DateTime LastModified { get; set; }

        // Helper properties
        public string SizeFormatted
        {
            get
            {
                if (SizeInBytes >= 1073741824) // GB
                    return $"{(SizeInBytes / 1073741824.0):F1} GB";
                else if (SizeInBytes >= 1048576) // MB
                    return $"{(SizeInBytes / 1048576.0):F1} MB";
                else if (SizeInBytes >= 1024) // KB
                    return $"{(SizeInBytes / 1024.0):F1} KB";
                else
                    return $"{SizeInBytes} bytes";
            }
        }
    }
}