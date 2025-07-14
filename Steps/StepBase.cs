using System.ComponentModel.DataAnnotations;
using csharpLauncher.Enums;
using csharpLauncher.Validation;


namespace csharpLauncher.Steps
{
    internal abstract class StepBase<T> : IStepExec where T : Model.StepBase 
    {
        protected readonly T _step;

        public StepBase(T step)
        {
            _step = step;
        }

        public abstract Task ExecuteAsync();

        public virtual List<StepValidationResult> Validate()
        {
            var rslt = new List<StepValidationResult>();

            if (string.IsNullOrEmpty(_step.Name))
                rslt.Add(
                    new StepValidationResult(ValidationSeverity.Info, "Step has no name."));

            return rslt;
        }
    }
}
