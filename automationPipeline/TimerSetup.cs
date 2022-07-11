using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace automationPipeline
{
    class TimerSetup :ICommand
    {
        private  Timer timer;

        private void SetUpTimer(TimeSpan alertTime)
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

        private void SomeMethodRunsAtSpesificTime()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        public void command(string commandLine)
        {
            var lineArgs = new List<string>();
            lineArgs = commandLine.Split(' ').ToList();
            SetUpTimer(TimeSpan.Parse(lineArgs[1]));
        }
    }
}
