using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace automationPipeline
{
    class DeleteFile : ICommand
    {
        public void command(string commandLine)
        {
            var lineArgs = new List<string>();
            lineArgs = commandLine.Split(' ').ToList();
            fileDelete(lineArgs[1]);
        }
        public void fileDelete(string sourceFile)
        {
            bool DoesFileExist = System.IO.File.Exists(sourceFile);

            if (DoesFileExist == true)
            {
                try
                {
                    File.Delete(sourceFile);
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
