using AutomatorLib;
using ClientLib;

namespace SampleSteps
{
    public class Refresh : IStep
    {
        public void Execute(WebBrowserComponent browser, StepCommand command)
        {
            browser.WebBrowserInterface.Select();
            browser.WebBrowserInterface.Focus();
            browser.WebBrowserInterface.Refresh();
        }
    }
}