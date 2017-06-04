using AutomatorLib;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;

namespace ClientLib
{
    public class StepRunner
    {
        public StepRunner(WebBrowserComponent browser = null, string communicationFile = null)
        {
            if (string.IsNullOrEmpty(communicationFile))
            {
                var path = ConfigurationManager.AppSettings["CommPath"];

                var file = ConfigurationManager.AppSettings["CommFile"];

                if (string.IsNullOrEmpty(file) || string.IsNullOrEmpty(path))
                {
                    path = Directory.GetCurrentDirectory();
                    file = "comm.oneclient";
                }
                CommPath = path.TrimEnd('/').TrimEnd('/').TrimEnd('\\').TrimEnd('\\');
                CommFile = file;
                CommunicationFile = CommPath + "\\" + CommFile;
            }
            else
            {
                CommunicationFile = communicationFile;
                var fileInfo = new FileInfo(communicationFile);
                CommPath = fileInfo.DirectoryName;
                CommFile = fileInfo.Name;
            }

            if (CommPath == null) throw new ArgumentNullException(nameof(CommPath));
            Directory.CreateDirectory(CommPath);

            Browser = browser;
        }

        public string CommPath { get; }
        public string CommFile { get; }
        public string CommunicationFile { get; }


        public void RequestStep<T>(params string[] args)
        {
            try
            {
                var command = new StepCommand(args) { StepType = typeof(T) };
                var instruction = JsonConvert.SerializeObject(command, Formatting.Indented);
                System.IO.File.WriteAllText(CommunicationFile, instruction);
            }
            catch (Exception)
            {
            }
        }

        public void RequestStep<T>(StepCommand command = null)
        {
            try
            {
                command = command ?? new StepCommand();
                command.StepType = typeof(T);
                var instruction = JsonConvert.SerializeObject(command, Formatting.Indented);
                System.IO.File.WriteAllText(CommunicationFile, instruction);
            }
            catch (Exception)
            {
            }
        }

        public void ExecuteStep()
        {
            var command = System.IO.File.ReadAllText(CommunicationFile).Trim();
            ExecuteStep(command);
        }

        public void ExecuteStep(string command)
        {
            var com = JsonConvert.DeserializeObject<StepCommand>(command);
            ExecuteStep(Browser, com);
        }

        public void ExecuteStep(WebBrowserComponent browser, StepCommand command)
        {
            var instance = Activator.CreateInstance(command.StepType) as IStep;
            instance?.Execute(browser, command);
        }

        private WebBrowserComponent Browser { get; }
    }
}