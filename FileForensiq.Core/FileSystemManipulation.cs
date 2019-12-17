using FileForensiq.Core.Interfaces;
using FileForensiq.Core.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.Core
{
    public class FileSystemManipulation : IFileSystemManipulation
    {
        private readonly object syncLock = new object();

        public FileSystemManipulation(){}

        /// <summary>
        /// Returns files tree (from root path) that are used in TreeView control.
        /// </summary>
        /// <param name="rootPath">Root path from which processing starts.</param>
        /// <returns>PartitionProcessingResult object with all files full names and number of errors.</returns>
        public PartitionProcessingResult GetPartitionFileTree(string rootPath, bool includeFiles = false)
        {
            PartitionProcessingResult result = new PartitionProcessingResult();
            ConcurrentStack<DirectoryTreeNode> fileTreeNodeStack = new ConcurrentStack<DirectoryTreeNode>();

            var rootDirectory = new DirectoryInfo(rootPath);
            var rootNode = new DirectoryTreeNode(rootDirectory.Name) { Tag = rootDirectory };

            fileTreeNodeStack.Push(rootNode);
            result.NumberOfReturnedResults++;

            DirectoryTreeNode currentNode;
            while (fileTreeNodeStack.Count > 0)
            {
                try
                {
                    fileTreeNodeStack.TryPop(out currentNode);
                    var currentNodeInfo = (DirectoryInfo)currentNode.Tag;

                    Parallel.ForEach(currentNodeInfo.EnumerateDirectories(), childDirectory =>
                    {
                        var childNode = new DirectoryTreeNode(childDirectory.Name)
                        {
                            Tag = childDirectory,
                            ImageKey = "folder.png",
                            SelectedImageKey = "folder.png",
                        };

                        // This kills performance (but it's needed so there is no aditional tree sorting)
                        lock (syncLock) 
                        {
                            currentNode.Nodes.Add(childNode);
                            result.NumberOfReturnedResults++;
                        }
                        
                        fileTreeNodeStack.Push(childNode);
                    });

                    if(includeFiles)
                    {
                        Parallel.ForEach(currentNodeInfo.EnumerateFiles(), file =>
                        {
                            var iconName = GetFileIcon(file.Extension);
                            lock (syncLock)
                            {
                                currentNode.Nodes.Add(new TreeNode(file.Name)
                                {
                                    Tag = file,
                                    ImageKey = iconName,
                                    SelectedImageKey = iconName
                                });
                                result.NumberOfReturnedResults++;
                            }
                        });
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
            result.RootNode = rootNode;
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
    }
}
