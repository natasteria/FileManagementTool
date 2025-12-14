// Configuration/ConfigurationManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileManagementTool.Models;
using Newtonsoft.Json;

namespace FileManagementTool.Configuration
{
    public class ConfigurationManager
    {
        private List<Category> _categories;
        private string _configFilePath;
        private bool _isCustomConfig;

        // Default categories if no config exists
        private readonly List<Category> _defaultCategories = new List<Category>
        {
            new Category("Documents", "Documents", ".txt", ".doc", ".docx", ".pdf", ".xlsx", ".pptx", ".rtf"),
            new Category("Images", "Images", ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".svg"),
            new Category("Videos", "Videos", ".mp4", ".avi", ".mov", ".wmv", ".mkv", ".flv"),
            new Category("Audio", "Audio", ".mp3", ".wav", ".aac", ".flac", ".m4a", ".ogg"),
            new Category("Archives", "Archives", ".zip", ".rar", ".7z", ".tar", ".gz"),
            new Category("Executables", "Executables", ".exe", ".msi", ".bat", ".cmd")
        };

        public ConfigurationManager()
        {
            _categories = new List<Category>();
            _configFilePath = GetConfigFilePath();
            _isCustomConfig = false;
        }

        public bool LoadConfiguration()
        {
            try
            {
                // Check if config file exists
                if (File.Exists(_configFilePath))
                {
                    // Load from file using Newtonsoft.Json
                    string json = File.ReadAllText(_configFilePath);
                    _categories = JsonConvert.DeserializeObject<List<Category>>(json);

                    if (_categories == null || _categories.Count == 0)
                    {
                        throw new Exception("Configuration file is empty or invalid");
                    }

                    // Validate the loaded configuration
                    if (!ValidateConfiguration(_categories))
                    {
                        throw new Exception("Configuration validation failed");
                    }

                    _isCustomConfig = true;
                    return true;
                }
                else
                {
                    // Config file doesn't exist, use defaults
                    _categories = new List<Category>(_defaultCategories);
                    _isCustomConfig = false;

                    // Create default config file
                    SaveConfiguration();

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log error and fall back to defaults
                ErrorHandling.ErrorLogger.Instance.LogError("Failed to load configuration", ex);

                _categories = new List<Category>(_defaultCategories);
                _isCustomConfig = false;

                return false;
            }
        }

        public bool SaveConfiguration(List<Category> categories = null)
        {
            try
            {
                if (categories != null)
                {
                    _categories = categories;
                }

                // Validate before saving
                if (!ValidateConfiguration(_categories))
                {
                    throw new Exception("Configuration validation failed");
                }

                // Ensure directory exists
                string configDir = Path.GetDirectoryName(_configFilePath);
                if (!Directory.Exists(configDir))
                {
                    Directory.CreateDirectory(configDir);
                }

                // Save to file using Newtonsoft.Json
                string json = JsonConvert.SerializeObject(_categories, Formatting.Indented);
                File.WriteAllText(_configFilePath, json);

                _isCustomConfig = true;
                ErrorHandling.ErrorLogger.Instance.LogInfo($"Configuration saved to: {_configFilePath}");

                return true;
            }
            catch (Exception ex)
            {
                ErrorHandling.ErrorLogger.Instance.LogError("Failed to save configuration", ex);
                return false;
            }
        }

        public bool ValidateConfiguration(List<Category> categories)
        {
            if (categories == null || categories.Count == 0)
            {
                ErrorHandling.ErrorLogger.Instance.LogError("Configuration has no categories");
                return false;
            }

            var seenCategoryNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var seenFolderNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var seenExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var category in categories)
            {
                // Check category name
                if (string.IsNullOrWhiteSpace(category.Name))
                {
                    ErrorHandling.ErrorLogger.Instance.LogError("Category has empty name");
                    return false;
                }

                if (seenCategoryNames.Contains(category.Name))
                {
                    ErrorHandling.ErrorLogger.Instance.LogError($"Duplicate category name: {category.Name}");
                    return false;
                }
                seenCategoryNames.Add(category.Name);

                // Check folder name
                if (string.IsNullOrWhiteSpace(category.FolderName))
                {
                    ErrorHandling.ErrorLogger.Instance.LogError($"Category '{category.Name}' has empty folder name");
                    return false;
                }

                // Validate folder name (Windows file name rules)
                char[] invalidChars = Path.GetInvalidFileNameChars();
                foreach (char c in category.FolderName)
                {
                    if (invalidChars.Contains(c))
                    {
                        ErrorHandling.ErrorLogger.Instance.LogError($"Category '{category.Name}' has invalid folder name character: {c}");
                        return false;
                    }
                }

                if (seenFolderNames.Contains(category.FolderName))
                {
                    ErrorHandling.ErrorLogger.Instance.LogWarning($"Duplicate folder name: {category.FolderName} (Category: {category.Name})");
                    // Warning but not fatal - folder names can be the same
                }
                seenFolderNames.Add(category.FolderName);

                // Check extensions
                if (category.Extensions == null || category.Extensions.Count == 0)
                {
                    ErrorHandling.ErrorLogger.Instance.LogError($"Category '{category.Name}' has no extensions");
                    return false;
                }

                foreach (var extension in category.Extensions)
                {
                    if (string.IsNullOrWhiteSpace(extension))
                    {
                        ErrorHandling.ErrorLogger.Instance.LogError($"Category '{category.Name}' has empty extension");
                        return false;
                    }

                    // Ensure extension starts with dot
                    string ext = extension.StartsWith(".") ? extension : "." + extension;

                    // Check for duplicate extensions across all categories
                    if (seenExtensions.Contains(ext))
                    {
                        ErrorHandling.ErrorLogger.Instance.LogWarning($"Duplicate extension: {ext} (Category: {category.Name})");
                        // Warning but not fatal - extensions can be in multiple categories
                    }
                    seenExtensions.Add(ext);
                }
            }

            return true;
        }

        public List<Category> GetCategories()
        {
            return new List<Category>(_categories); // Return copy
        }

        public List<Category> GetDefaultCategories()
        {
            return new List<Category>(_defaultCategories);
        }

        public bool IsCustomConfig => _isCustomConfig;

        public string ConfigFilePath => _configFilePath;

        public void ResetToDefaults()
        {
            _categories = new List<Category>(_defaultCategories);
            _isCustomConfig = false;
            SaveConfiguration();
        }

        public string GetConfigurationJson()
        {
            return JsonConvert.SerializeObject(_categories, Formatting.Indented);
        }

        private string GetConfigFilePath()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(appData, "FileManagementTool", "categories.json");
        }
    }
}