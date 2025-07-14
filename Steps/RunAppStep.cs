using csharpLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpLauncher.Steps
{
    internal class RunAppStep : StepBase, IStepExec
    {
        public RunAppStep(Model.StepBase step) 
            : base(step)
        {
        }

        public override Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
