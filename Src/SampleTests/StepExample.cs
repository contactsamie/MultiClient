using System.Linq;
using AutomatorLib;
using ClientLib;

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