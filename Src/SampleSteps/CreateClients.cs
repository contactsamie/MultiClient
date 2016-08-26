using AutomatorLib;
using ClientLib;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSteps
{
    public class CreateClients : IStep
    {
        public void Execute(WebBrowserComponent browser, StepCommand command)
        {
            var myAppPath = Directory.GetCurrentDirectory();
            Parallel.ForEach(Enumerable.Range(0, Convert.ToInt32(command.Arguments.First())),
                (s) => Process.Start(new ProcessStartInfo
                {
                    WorkingDirectory = myAppPath,
                    FileName = @"OneClient.exe"
                }));
        }
    }
}