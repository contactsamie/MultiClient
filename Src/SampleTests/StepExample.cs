using AutomatorLib;
using ClientLib;
using System.Linq;

namespace SampleTests
{
    public class StepExample : IStep
    {
        public void Execute(WebBrowserComponent browser, StepCommand command)
        {
            browser.WebBrowserInterface.Navigate(command.Arguments.First());
        }
    }
}