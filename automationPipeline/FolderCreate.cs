using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace automationPipeline
{
    class FolderCreate : ICommand
    {
        public void command(string commandLine)
        {
            var lineArgs = new List<string>();
            lineArgs = commandLine.Split(' ').ToList();
            CreateFolder(lineArgs[1], lineArgs[2]);
        }

        public void CreateFolder(string folderPath, string newFolderName)
        {
            try
            {
                string fullPath = Path.Combine(folderPath, newFolderName);
                System.IO.Directory.CreateDirectory(fullPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
    }
}
