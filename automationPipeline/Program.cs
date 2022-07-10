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
            if(DoesFileExist)
                readLinesInFile(file);
           
            
            //ClickHandler(3);
            //SetUpTimer(new TimeSpan(16, 00, 00));

            Console.Read();

        }

        public static async void ClickHandler(int time)
        {
            // whatever you need to do before delay goes here         
            Console.WriteLine("before: "+DateTime.Now.ToString());
            await Task.Delay(time*1000);
            Console.WriteLine("after: " + DateTime.Now.ToString());

            // whatever you need to do after delay.
        }
     

        public static void CreateFolder(string folderPath,string newFolderName)
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

        public static void fileCopy(string sourceFile, string destinationFile)
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
        public static void fileDelete(string sourceFile)
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
        private static Timer timer;
        private static void SetUpTimer(TimeSpan alertTime)
        {
            DateTime current = DateTime.Now;
            TimeSpan timeToGo = alertTime - current.TimeOfDay;
            if (timeToGo < TimeSpan.Zero)
            {
                return;//time already passed
            }
            timer = new Timer(x =>
            {
                SomeMethodRunsAtSpesificTime();
            }, null, timeToGo, Timeout.InfiniteTimeSpan);
        }

        private static void SomeMethodRunsAtSpesificTime()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        public static void readLinesInFile(string sourceFile)
        {            
            foreach (var line in File.ReadAllLines(sourceFile))
            {
                var lineArgs  = new List<string>();
                lineArgs = line.Split(' ').ToList();
                if (lineArgs[0].Contains("delete"))
                {
                   if( File.Exists(lineArgs[1]))
                        fileDelete(lineArgs[1]);
                }
                if (lineArgs[0].Contains("copy"))
                {
                    if (File.Exists(lineArgs[1]) && lineArgs[2].Length > 0)
                        fileCopy(lineArgs[1],lineArgs[2]);
                }
                if (lineArgs[0].Contains("create"))
                {
                    if (File.Exists(lineArgs[1]))
                        CreateFolder(lineArgs[1],lineArgs[2]);
                    
                }
                if (lineArgs[0].Contains("delay"))
                {
                    ClickHandler(Int32.Parse(lineArgs[1]));
                }
                if (lineArgs[0].Contains("download"))
                {
                    downloadFile(lineArgs[1],lineArgs[2]);
                }
            }
        }

        public static int conditionalCountRowString (string sourceFile, string searchText)
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
        public static void queryFileFolder (string source)
        {
            string[] fileArray = Directory.GetFiles(source);
            foreach (var item in fileArray)
            {
                Console.WriteLine(item);
            }
        }
        public static void downloadFile (string url, string fileName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            }
        }
    }
}
