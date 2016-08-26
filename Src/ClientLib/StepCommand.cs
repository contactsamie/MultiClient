using System;
using System.Collections.Generic;

namespace AutomatorLib
{
    public class StepCommand
    {
        public List<string> Arguments { set; get; }
        public Type ArgumentType { set; get; }
        public Type StepType { set; get; }
    }
}