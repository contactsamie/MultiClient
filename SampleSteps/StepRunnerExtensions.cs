using System.Collections.Generic;
using AutomatorLib;
using ClientLib;

namespace SampleSteps
{
    public static class StepRunnerExtensions
    {
        public static void Run(this StepRunner runner,int numberOfClients)
        {
            new CreateClients().Execute(null, new StepCommand() { Arguments = new List<string>() { numberOfClients.ToString() } });
        }

        public static void Navigate(this StepRunner runner, string url)
        {
            runner.RequestStep<StepNavigate>(new StepCommand() { Arguments = new List<string>() { url } });
        }

        public static void Refresh(this StepRunner runner)
        {
            runner.RequestStep<Refresh>();
        }


        public static void Multiply(this StepRunner runner, int numberOfClients)
        {
            runner.RequestStep<CreateClients>(new StepCommand() { Arguments = new List<string>() { numberOfClients.ToString() } });
        }

        public static void TerminateAll(this StepRunner runner)
        {
            runner.RequestStep<StepDie>();
        }

    }
}