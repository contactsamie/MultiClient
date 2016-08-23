using AutomatorLib;
using ClientLib;
using System.Linq;

namespace SampleSteps
{
    public class StepNavigate : IStep
    {
        public void Execute(WebBrowserComponent browser, StepCommand command)
        {
            browser.WebBrowserInterface.Navigate(command.Arguments.First());
        }
    }
}