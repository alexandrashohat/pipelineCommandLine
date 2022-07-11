using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace automationPipeline
{
    class QueryFilesFolder : ICommand
    {
        public void command(string commandLine)
        {
            var lineArgs = new List<string>();
            lineArgs = commandLine.Split(' ').ToList();
            queryFileFolder(lineArgs[1]);
        }

        public void queryFileFolder(string source)
        {
            string[] fileArray = Directory.GetFiles(source);
            foreach (var item in fileArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
