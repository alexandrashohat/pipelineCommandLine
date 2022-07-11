using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace automationPipeline
{
    class CopyFile : ICommand
    {
        public CopyFile()
        {

        }

        public void command(string commandLine)
        {
            var lineArgs = new List<string>();
            lineArgs = commandLine.Split(' ').ToList();
            fileCopy(lineArgs[1], lineArgs[2]);
        }

        public void fileCopy(string sourceFile, string destinationFile)
        {
            bool DoesFileExist = System.IO.File.Exists(sourceFile);

            if (DoesFileExist == true)
            {
                try
                {
                    File.Copy(sourceFile, destinationFile, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            else
            {
                Console.WriteLine("File does not exist, Please enter a valid path.");
            }

        }
    }
}
