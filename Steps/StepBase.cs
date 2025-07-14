using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpLauncher.Steps
{
    internal abstract class StepBase : IStepExec
    {
        private readonly Model.StepBase _step;

        public StepBase(Model.StepBase step)
        {
            _step = step;
        }

        public abstract Task ExecuteAsync();
    }
}
