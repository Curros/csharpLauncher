using csharpLauncher.Validation;

namespace csharpLauncher.Steps
{
    internal interface IStepExec
    {
        List<StepValidationResult> Validate();

        Task ExecuteAsync();
    }
}
