using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace automationPipeline
{
    class DownloadFile : ICommand
    {
        public void command(string commandLine)
        {
            var lineArgs = new List<string>();
            lineArgs = commandLine.Split(' ').ToList();
            downloadFile(lineArgs[1], lineArgs[2]);
        }

        public void downloadFile(string url, string fileName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            }
        }
    }
}
