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
            Parallel.ForEach(Enumerable.Range(0, Convert.ToInt32(command.Arguments.First())),
                (s) =>
                {
                   // var t = System.Reflection.Assembly.GetEntryAssembly().Location;
                    string myAppPath = Directory.GetCurrentDirectory();//new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).DirectoryName;
                    Process.Start(new ProcessStartInfo
                    {
                        WorkingDirectory = myAppPath,
                        FileName = @"OneClient.exe"
                    });

                });
        }
    }
}