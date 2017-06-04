# MultiClient | 影分身の術 
Kage bunshin no jutsu

[![NuGet version](https://img.shields.io/nuget/v/MultiClient.svg?style=flat-square)](https://www.nuget.org/packages/MultiClient)


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



------------


        [TestMethod]
        public void Run()
        {
            Runner.Run(1);// kamui
        }

        [TestMethod]
        public void Navigate()
        {
            Runner.Navigate("www.google.com");
        }

        [TestMethod]
        public void Refresh()
        {
            Runner.Refresh(); // Chidori 羽撃く千鳥
        }

        [TestMethod]
        public void Multiply()
        {
            Runner.Multiply(2); // Kage bunshin no jutsu 影分身の術 
        }

        [TestMethod]
        public void KillAll()
        {
            Runner.TerminateAll();// Super tailed beast Rasenshuriken 風遁・螺旋手裏剣 
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


Milestones

https://github.com/contactsamie/MultiClient/milestones
