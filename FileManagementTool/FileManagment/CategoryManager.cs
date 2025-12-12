// FileManagement/CategoryManager.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileManagementTool.FileManagement
{
    public class CategoryManager
    {
        private Dictionary<string, CategoryMapping> categoryMap;

        public CategoryManager(List<Models.Category> categories)
        {
            BuildCategoryMap(categories);
        }

        private void BuildCategoryMap(List<Models.Category> categories)
        {
            categoryMap = new Dictionary<string, CategoryMapping>(StringComparer.OrdinalIgnoreCase);

            foreach (var category in categories)
            {
                foreach (var extension in category.Extensions)
                {
                    string extKey = extension.StartsWith(".") ? extension.ToLower() : "." + extension.ToLower();

                    if (!categoryMap.ContainsKey(extKey))
                    {
                        categoryMap[extKey] = new CategoryMapping
                        {
                            CategoryName = category.Name,
                            FolderName = category.FolderName,
                            OriginalExtension = extension
                        };
                    }
                }
            }
        }

        public string GetCategoryForFile(string extension)
        {
            if (string.IsNullOrEmpty(extension))
                return "Unknown";

            string extKey = extension.StartsWith(".") ? extension.ToLower() : "." + extension.ToLower();

            if (categoryMap.ContainsKey(extKey))
                return categoryMap[extKey].CategoryName;

            return "Unknown";
        }

        public string GetFolderNameForCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName) || categoryName == "Unknown")
                return "Unknown";

            // Find the first category with this name
            var mapping = categoryMap.Values.FirstOrDefault(m => m.CategoryName == categoryName);
            return mapping?.FolderName ?? categoryName;
        }

        public Dictionary<string, List<ScannedFile>> CategorizeFiles(List<ScannedFile> files)
        {
            var categorizedFiles = new Dictionary<string, List<ScannedFile>>();

            foreach (var file in files)
            {
                string category = GetCategoryForFile(file.Extension);

                if (!categorizedFiles.ContainsKey(category))
                {
                    categorizedFiles[category] = new List<ScannedFile>();
                }

                categorizedFiles[category].Add(file);
            }

            return categorizedFiles;
        }

        public List<string> GetAllCategories()
        {
            return categoryMap.Values
                .Select(m => m.CategoryName)
                .Distinct()
                .ToList();
        }

        private class CategoryMapping
        {
            public string CategoryName { get; set; }
            public string FolderName { get; set; }
            public string OriginalExtension { get; set; }
        }
    }
}