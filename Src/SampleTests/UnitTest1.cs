using System.Collections.Generic;
using AutomatorLib;
using ClientLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleSteps;

namespace SampleTests
{
    [TestClass]
    public class UnitTest1
    {
        private StepRunner Runner { set; get; }

        public UnitTest1()
        {
            Runner = new StepRunner();
        }

        [TestMethod]
        public void Run()
        {
            Runner.Run(1);
        }

        [TestMethod]
        public void Navigate()
        {
            Runner.Navigate("www.google.com");
        }

        [TestMethod]
        public void Refresh()
        {
            Runner.Refresh();
        }

        [TestMethod]
        public void Multiply()
        {
            Runner.Multiply(2);
        }

        [TestMethod]
        public void KillAll()
        {
            Runner.TerminateAll();
        }

        [TestMethod]
        public void Example()
        {
            Runner.RequestStep<StepExample>(new StepCommand()
            {
                Arguments = new List<string>()
                {
                    "www.google.com"
                }
            });
        }
    }
}