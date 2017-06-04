open System
open AutomatorLib
open ClientLib
open SampleSteps


type StepExample() = 
     interface IStep  with 
      member this.Execute(browser, command) = 
        browser.WebBrowserInterface.Navigate command.Arguments.[0]


[<EntryPoint>]
let main argv = 
    let Runner = new StepRunner()
    Runner.TerminateAll()
    Runner.Run 1
    Runner.RequestStep<StepExample> "www.google.com"
    Runner.Navigate "www.google.com"
    Runner.Refresh()
    Runner.TerminateAll()
    0 // return an integer exit code
