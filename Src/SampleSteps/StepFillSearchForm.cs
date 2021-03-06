using AutomatorLib;
using ClientLib;
using System.Linq;

namespace SampleSteps
{
    public class StepFillSearchForm : IStep
    {
        public void Execute(WebBrowserComponent browser, StepCommand command)
        {
            var el = browser.Select("[q]", 0, "name");
            el.SetTextBoxValue_HTMLCtrl(command.Arguments.First());
        }
    }
}