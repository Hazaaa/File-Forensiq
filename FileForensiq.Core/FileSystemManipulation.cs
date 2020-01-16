using FileForensiq.Core.Interfaces;
using FileForensiq.Core.Logger;
using FileForensiq.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileForensiq.Core
{
    public class FileSystemManipulation : IFileSystemManipulation
    {
        public FileSystemManipulation(){}

        /// <summary>
        /// Returns list of TreeNode that represents children of directory.
        /// </summary>
        /// <param name="directoryPath">Directory for which children is collected.</param>
        /// <returns>List of directory children.</returns>
        public ChildNodesResult GetDirectoryChildren(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);
            var result = new ChildNodesResult();

            try
            {
                var directoryChilds = directoryInfo.EnumerateDirectories();
                var filesChilds = directoryInfo.EnumerateFiles();

                foreach (var directory in directoryChilds)
                {
                    var directoryNode = new DirectoryTreeNode(directory.Name)
                    {
                        Tag = directory,
                        ImageKey = "folder.png",
                        SelectedImageKey = "folder.png",
                    };
                    directoryNode.Nodes.Add("dummy");

                    result.ChildNodes.Add(directoryNode);
                }

                foreach(var file in filesChilds)
                {
                    var icon = GetFileIcon(file.Extension);
                    result.ChildNodes.Add(new TreeNode(file.Name) 
                    { 
                        Tag = file,
                        ImageKey = icon,
                        SelectedImageKey = icon,
                    });
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                ErrorLogger.LogError("Unauthorized access to file: " + ex.Message);
                result.Error = ex;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError("Exception thrown: " + ex.Message);
                result.Error = ex;
            }

            return result;
        }

        /// <summary>
        /// Calculates size for dictionary in bytes.
        /// </summary>
        /// <param name="directory">Directory for which size is calculated.</param>
        public long CalculateDirectorySize(DirectoryInfo directory)
        {
            if(directory == null)
            {
                return 0;
            }

            long size = 0;

            try
            {
                var subDirectories = directory.EnumerateDirectories();
                var files = directory.EnumerateFiles();

                foreach (var subdirectory in subDirectories)
                {
                    size += CalculateDirectorySize(subdirectory);
                }

                foreach (var file in files)
                {
                    size += file.Length;
                }
            }
            catch (Exception)
            {
                return 0;
            }

            return size;
        }

        /// <summary>
        /// Calculates number of files for every dictionary including files in his sub-directories.
        /// </summary>
        /// <param name="rootNode">Root node.</param>
        public int CalculateNumberOfFiles(DirectoryInfo rootNode)
        {
            if (rootNode == null)
            {
                return 0;
            }

            var result = 0;

            try
            {
                var subDirectories = rootNode.EnumerateDirectories();
                foreach (var subDirectory in subDirectories)
                {
                    result += CalculateNumberOfFiles(subDirectory);
                }

                result += rootNode.EnumerateFiles().Count();
            }
            catch (Exception)
            {
                return 0;
            }

            return result;
        }

        /// <summary>
        /// Returns correct icon given file extension if exists or it will be shown default file icon.
        /// </summary>
        /// <param name="extension">File extension.</param>
        /// <returns>Name of icon.</returns>
        public string GetFileIcon(string extension)
        {
            return String.IsNullOrEmpty(extension) ? "folder.png" : extension.Replace(".", string.Empty).Trim() + ".png";
        }

        /// <summary>
        /// Opens directory or file that are in tag property in tree node from treeview control.
        /// </summary>
        /// <param name="file">TreeNode object from treeview control.</param>
        public void OpenFile(TreeNode file)
        {
            try
            {
                string path = "";
                if (file is DirectoryTreeNode)
                {
                    var tag = (DirectoryInfo)file.Tag;
                    path = tag.FullName;
                }
                else
                {
                    var tag = (FileInfo)file.Tag;
                    path = tag.FullName;
                }

                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError("Unable to open file: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Recursively populates DataTable object with info about every directory and file so those info can be cached in db.
        /// </summary>
        public CacheResult PrepareFileDetailsForCache(DirectoryInfo rootDirectory, DataTable data)
        {
            
            if (rootDirectory == null)
            {
                return new CacheResult();
            }

            CacheResult result = new CacheResult();

            try
            {
                var directories = rootDirectory.EnumerateDirectories();
                var files = rootDirectory.EnumerateFiles();

                foreach (var childDirectory in directories)
                {
                    var tmpRes = PrepareFileDetailsForCache(childDirectory, data);

                    result.Size += tmpRes.Size;
                    result.NumberOfFiles += tmpRes.NumberOfFiles;
                }

                foreach (var childFile in files)
                {
                    result.Size += childFile.Length;
                    result.NumberOfFiles++;

                    var fileRow = data.NewRow();

                    fileRow["Name"] = childFile.FullName;
                    fileRow["Type"] = childFile.Extension.Split('.')[1];
                    fileRow["Size"] = childFile.Length;
                    fileRow["NumberOfFiles"] = 0;
                    fileRow["CreationTime"] = childFile.CreationTime;
                    fileRow["LastAccessTime"] = childFile.LastAccessTime;
                    fileRow["LastModificationTime"] = childFile.LastWriteTime;

                    data.Rows.Add(fileRow);
                }
            }
            catch (Exception)
            {
                return new CacheResult();
            }

            var directoryRow = data.NewRow();

            directoryRow["Name"] = rootDirectory.FullName;
            directoryRow["Type"] = "folder";
            directoryRow["Size"] = result.Size;
            directoryRow["NumberOfFiles"] = result.NumberOfFiles;
            directoryRow["CreationTime"] = rootDirectory.CreationTime;
            directoryRow["LastAccessTime"] = rootDirectory.LastAccessTime;
            directoryRow["LastModificationTime"] = rootDirectory.LastWriteTime;

            data.Rows.Add(directoryRow);

            return result;
        }
    }
}
