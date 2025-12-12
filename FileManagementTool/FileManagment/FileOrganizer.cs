// FileManagement/FileOrganizer.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace FileManagementTool.FileManagement
{
    public class FileOrganizer
    {
        public event EventHandler<FileProgressEventArgs> FileProgress;
        public event EventHandler<OperationProgressEventArgs> OperationProgress;

        private int totalFiles;
        private int processedFiles;
        private int successfullyProcessed;
        private int failedFiles;

        public FileOrganizerResult OrganizeFiles(List<ScannedFile> files,
                                                Dictionary<string, List<ScannedFile>> categorizedFiles,
                                                string destinationPath,
                                                CategoryManager categoryManager,
                                                bool preserveOriginal = true)
        {
            var result = new FileOrganizerResult();
            totalFiles = files.Count;
            processedFiles = 0;
            successfullyProcessed = 0;
            failedFiles = 0;

            try
            {
                // Ensure destination directory exists
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                // Create category folders
                var categoryFolders = CreateCategoryFolders(destinationPath, categorizedFiles.Keys, categoryManager);

                // Process each category
                foreach (var category in categorizedFiles.Keys)
                {
                    string categoryFolder = categoryFolders[category];

                    // Process each file in this category
                    foreach (var file in categorizedFiles[category])
                    {
                        ProcessSingleFile(file, categoryFolder, preserveOriginal, result);
                    }
                }

                // Final result
                result.IsSuccess = true;
                result.Message = $"Processed {successfullyProcessed} files successfully. {failedFiles} files failed.";
                result.TotalFiles = totalFiles;
                result.SuccessfulFiles = successfullyProcessed;
                result.FailedFiles = failedFiles;

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Error during file organization: {ex.Message}";
                return result;
            }
        }

        private Dictionary<string, string> CreateCategoryFolders(string basePath,
                                                               IEnumerable<string> categories,
                                                               CategoryManager categoryManager)
        {
            var folderPaths = new Dictionary<string, string>();

            foreach (var category in categories)
            {
                string folderName = categoryManager.GetFolderNameForCategory(category);
                string folderPath = Path.Combine(basePath, folderName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                folderPaths[category] = folderPath;
            }

            return folderPaths;
        }

        private void ProcessSingleFile(ScannedFile file, string destinationFolder,
                              bool preserveOriginal, FileOrganizerResult result)
        {
            try
            {
                processedFiles++;

                // Update operation progress
                OnOperationProgress($"Copying {file.FileName}...",
                                   (int)((processedFiles * 100.0) / totalFiles));

                // Generate destination path
                string destinationFilePath = GetUniqueFilePath(destinationFolder, file.FileName);

                // Copy the file
                File.Copy(file.FullPath, destinationFilePath, false);

                // Record successful operation
                var fileResult = new FileOperationResult
                {
                    FileName = file.FileName,
                    OriginalPath = file.FullPath,
                    NewPath = destinationFilePath,
                    IsSuccess = true,
                    Message = "File copied successfully"
                };

                result.FileResults.Add(fileResult);
                successfullyProcessed++;

                // Update file progress
                OnFileProgress(file.FileName, destinationFilePath, true, "");
            }
            catch (UnauthorizedAccessException ex)
            {
                failedFiles++;

                var fileResult = new FileOperationResult
                {
                    FileName = file.FileName,
                    OriginalPath = file.FullPath,
                    IsSuccess = false,
                    Message = $"Access denied: {ex.Message}"
                };

                result.FileResults.Add(fileResult);
                OnFileProgress(file.FileName, "", false, "Access denied");
            }
            catch (IOException ex)
            {
                failedFiles++;

                var fileResult = new FileOperationResult
                {
                    FileName = file.FileName,
                    OriginalPath = file.FullPath,
                    IsSuccess = false,
                    Message = $"IO Error: {ex.Message}"
                };

                result.FileResults.Add(fileResult);
                OnFileProgress(file.FileName, "", false, "IO Error");
            }
            catch (Exception ex)
            {
                failedFiles++;

                var fileResult = new FileOperationResult
                {
                    FileName = file.FileName,
                    OriginalPath = file.FullPath,
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };

                result.FileResults.Add(fileResult);
                OnFileProgress(file.FileName, "", false, "Error");
            }
        }

        private string GetUniqueFilePath(string folder, string fileName)
        {
            string baseName = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string newFilePath = Path.Combine(folder, fileName);

            // If file doesn't exist, use the original name
            if (!File.Exists(newFilePath))
            {
                return newFilePath;
            }

            // Generate a unique name by appending a number
            int counter = 1;
            while (File.Exists(newFilePath))
            {
                string newFileName = $"{baseName} ({counter}){extension}";
                newFilePath = Path.Combine(folder, newFileName);
                counter++;

                // Safety check to prevent infinite loop
                if (counter > 1000)
                {
                    throw new Exception("Cannot find unique filename after 1000 attempts.");
                }
            }

            return newFilePath;
        }

        protected virtual void OnFileProgress(string fileName, string destination, bool success, string message)
        {
            FileProgress?.Invoke(this, new FileProgressEventArgs
            {
                FileName = fileName,
                DestinationPath = destination,
                IsSuccess = success,
                Message = message,
                CurrentFile = processedFiles,
                TotalFiles = totalFiles
            });
        }

        protected virtual void OnOperationProgress(string operation, int percentage)
        {
            OperationProgress?.Invoke(this, new OperationProgressEventArgs
            {
                Operation = operation,
                Percentage = percentage
            });
        }
    }

    // Event and Result Classes
    public class FileProgressEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public string DestinationPath { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int CurrentFile { get; set; }
        public int TotalFiles { get; set; }
    }

    public class OperationProgressEventArgs : EventArgs
    {
        public string Operation { get; set; }
        public int Percentage { get; set; }
    }

    public class FileOrganizerResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalFiles { get; set; }
        public int SuccessfulFiles { get; set; }
        public int FailedFiles { get; set; }
        public List<FileOperationResult> FileResults { get; set; }

        public FileOrganizerResult()
        {
            FileResults = new List<FileOperationResult>();
        }
    }

    public class FileOperationResult
    {
        public string FileName { get; set; }
        public string OriginalPath { get; set; }
        public string NewPath { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}