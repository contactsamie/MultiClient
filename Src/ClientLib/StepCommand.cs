using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatorLib
{
    public class StepCommand
    {
        public StepCommand(params string[] args)
        {
            Arguments = args.Length > 0 ? args.ToList() : new List<string>();
        }

        public List<string> Arguments { set; get; }
        public Type StepType { get; set; }
    }
}