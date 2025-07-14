using csharpLauncher.Enums;
using csharpLauncher.Validation;

namespace csharpLauncher.Steps
{
    internal class StepRunApp : StepBase<Model.StepRunApp>, IStepExec
    {

        public StepRunApp(Model.StepRunApp step) 
            : base(step)
        {
        }

        public override List<StepValidationResult> Validate()
        {
            var rslt = base.Validate();

            if (string.IsNullOrWhiteSpace(_step.Path))
                rslt.Add(new StepValidationResult(ValidationSeverity.Error,
                    $"Path missing for the Step {_step.Name}"));

            return rslt;
        }

        public override Task ExecuteAsync()
        {

            Process.Start(new ProcessStartInfo
            {
                FileName = _step.Path,
                Arguments = string.Join(" ", _step.Parameters),
                UseShellExecute = false
            });

            return Task.CompletedTask;
        }
    }
}
