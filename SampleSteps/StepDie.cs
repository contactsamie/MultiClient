using AutomatorLib;
using ClientLib;

namespace SampleSteps
{
    public class StepDie : IStep
    {
        public void Execute(WebBrowserComponent browser, StepCommand command)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}