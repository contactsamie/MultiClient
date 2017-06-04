using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatorLib
{
    public class StepCommand
    {
        public StepCommand(params string[] args)
        {
            Arguments = args?.ToList() ?? new List<string>();
        }
        public List<string> Arguments { set; get; }
        public Type ArgumentType { set; get; }
        public Type StepType { set; get; }
    }
}