// Models/Category.cs
using System;
using System.Collections.Generic;

namespace FileManagementTool.Models
{
    public class Category
    {
        public string Name { get; set; }
        public List<string> Extensions { get; set; }
        public string FolderName { get; set; }

        public Category()
        {
            Extensions = new List<string>();
        }

        public Category(string name, string folderName, params string[] extensions)
        {
            Name = name;
            FolderName = folderName;
            Extensions = new List<string>(extensions);
        }

        // For display in ListBox
        public override string ToString()
        {
            return Name;
        }
    }
}