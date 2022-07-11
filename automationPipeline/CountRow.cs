using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace automationPipeline
{
    class CountRow : ICommand
    {
        public void command(string commandLine)
        {
            var lineArgs = new List<string>();
            lineArgs = commandLine.Split(' ').ToList();
            conditionalCountRowString(lineArgs[1], lineArgs[2]);
        }
        public int conditionalCountRowString(string sourceFile, string searchText)
        {
            int retNumberOfOccurences = 0;
            foreach (var line in File.ReadAllLines(sourceFile))
            {
                if (line.Contains(searchText))
                {
                    retNumberOfOccurences++;
                }
            }
            return retNumberOfOccurences;
        }
    }
}
