using System;
using System.Collections.Generic;
using System.Text;

namespace automationPipeline
{
    interface ICommand
    {
        void command(string commandLine);
    }
}
