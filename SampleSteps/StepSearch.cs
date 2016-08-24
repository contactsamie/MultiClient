using AutomatorLib;
using ClientLib;

namespace SampleSteps
{
    public class StepSearch : IStep
    {
        public void Execute(WebBrowserComponent browser, StepCommand command)
        {
            browser.Select("[btnG]",0,"name").ClickLink_HTMLCtrl();
        }
    }
}