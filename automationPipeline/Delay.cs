using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationPipeline
{
    class Delay:ICommand
    {
        public async void ClickHandler(int time)
        {
            // whatever you need to do before delay goes here         
            Console.WriteLine("before: " + DateTime.Now.ToString());
            await Task.Delay(time * 1000);
            Console.WriteLine("after: " + DateTime.Now.ToString());

            // whatever you need to do after delay.
        }

        public void command(string commandLine)
        {
            var lineArgs = new List<string>();
            lineArgs = commandLine.Split(' ').ToList();
            ClickHandler(Int32.Parse(lineArgs[1]));
        }
    }
}
