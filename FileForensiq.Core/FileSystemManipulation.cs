using FileForensiq.Core.Interfaces;
using FileForensiq.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileForensiq.Core
{
    public class FileSystemManipulation : IFileSystemManipulation
    {
        public FileSystemManipulation(){}

        /// <summary>
        /// Returns files tree (from root path) that are used in TreeView control.
        /// </summary>
        /// <param name="rootPath">Root path from which processing starts.</param>
        /// <returns>PartitionProcessingResult object with all files full names and number of errors.</returns>
        public PartitionProcessingResult GetPartitionFileTree(string rootPath, bool includeFiles = false)
        {
            PartitionProcessingResult result = new PartitionProcessingResult();
            Stack<DirectoryTreeNode> fileTreeNodeStack = new Stack<DirectoryTreeNode>();

            var rootDirectory = new DirectoryInfo(rootPath);
            var rootNode = new DirectoryTreeNode(rootDirectory.Name) { Tag = rootDirectory };

            fileTreeNodeStack.Push(rootNode);
            result.NumberOfFolders++;

            DirectoryTreeNode currentNode;
            while (fileTreeNodeStack.Count > 0)
            {
                try
                {
                    currentNode = fileTreeNodeStack.Pop();
                    var currentNodeInfo = (DirectoryInfo)currentNode.Tag;

                    foreach(var childDirectory in currentNodeInfo.EnumerateDirectories())
                    {
                        var childNode = new DirectoryTreeNode(childDirectory.Name)
                        {
                            Tag = childDirectory,
                            ImageKey = "folder.png",
                            SelectedImageKey = "folder.png",
                        };
                        
                        currentNode.Nodes.Add(childNode);
                        result.NumberOfFolders++;

                        fileTreeNodeStack.Push(childNode);
                    };

                    if(includeFiles)
                    {
                        var directoryFiles = currentNodeInfo.EnumerateFiles();
                        currentNode.NumberOfFiles += directoryFiles.Count();
                        foreach(var file in directoryFiles)
                        {
                            var iconName = GetFileIcon(file.Extension);
                            currentNode.Nodes.Add(new TreeNode(file.Name)
                            {
                                Tag = file,
                                ImageKey = iconName,
                                SelectedImageKey = iconName
                            });
                            currentNode.Size += file.Length;
                            result.NumberOfFiles++;
                        };
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine("Unauthorized access to file: " + ex.Message);
                    result.UnauthorizedErrors++;
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception thrown: " + ex.Message);
                    result.OtherErrors++;
                    continue;
                }
            }
            CalculateDirectorySize(rootNode);
            CalculateNumberOfFiles(rootNode);
            result.RootNode = rootNode;
            return result;
        }

        /// <summary>
        /// Calculates size for every dictionary in bytes.
        /// </summary>
        /// <param name="rootNode">Root node.</param>
        public long CalculateDirectorySize(DirectoryTreeNode rootNode)
        {
            if(rootNode == null)
            {
                return 0;
            }

            foreach (var directory in rootNode.Nodes)
            {
                if(directory is DirectoryTreeNode)
                {
                    rootNode.Size += CalculateDirectorySize((DirectoryTreeNode)directory);
                }
            }

            // Displaying size of files in KB, MB, GB or TB
            var rootSize = ((rootNode.Size) / 1024f) / 1024f;
            if (rootSize < 1.0)
            {
                rootNode.Text += " (" + (rootNode.Size) / 1024f + " KB)";
            }
            else if(rootSize > 1000)
            {
                rootNode.Text += " (" + rootSize / 1000f + " GB)";
            } 
            else if(rootSize > 1000000)
            {
                rootNode.Text += " (" + (rootSize / 953674f) + " TB)";
            } 
            else
            {
                rootNode.Text += " (" + rootSize + " MB)";
            }

            return rootNode.Size;
        }

        /// <summary>
        /// Calculates number of files for every dictionary including files in his sub-directories.
        /// </summary>
        /// <param name="rootNode">Root node.</param>
        public int CalculateNumberOfFiles(DirectoryTreeNode rootNode)
        {
            if (rootNode == null)
            {
                return 0;
            }

            foreach (var directory in rootNode.Nodes)
            {
                if (directory is DirectoryTreeNode)
                {
                    rootNode.NumberOfFiles += CalculateNumberOfFiles((DirectoryTreeNode)directory);
                }
            }

            return rootNode.NumberOfFiles;
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
                throw ex;
            }
        }
    }
}
