using AutomatorLib;

namespace ClientLib
{
    public interface IStep
    {
        void Execute(WebBrowserComponent browser, StepCommand command);
    }
}