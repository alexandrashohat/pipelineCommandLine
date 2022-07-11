using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace automationPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = args[0];

            bool DoesFileExist = File.Exists(file);
            if (DoesFileExist)
                readLinesInFile(file);
       
            Console.Read();
        }                                  
        
        public static void readLinesInFile(string sourceFile)
        {            
            foreach (var line in File.ReadAllLines(sourceFile))
            {
                var lineArgs  = new List<string>();
                lineArgs = line.Split(' ').ToList();
                if (lineArgs[0].Contains("delete"))
                {
                    DeleteFile dltfl = new DeleteFile();
                    dltfl.command(line);
                }
                if (lineArgs[0].Contains("copy"))
                {                   
                    CopyFile cpyfl = new CopyFile();
                    cpyfl.command(line);                    
                }
                if (lineArgs[0].Contains("create"))
                {
                    FolderCreate fldrCreate = new FolderCreate();
                    fldrCreate.command(line);
                }
                if (lineArgs[0].Contains("delay"))
                {
                    Delay delay = new Delay();
                    delay.command(line);
                }
                if (lineArgs[0].Contains("download"))
                {
                    DownloadFile dnldfl = new DownloadFile();
                    dnldfl.command(line);
                }
            }
        }      
    }
}
