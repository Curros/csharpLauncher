using csharpLauncher.Enums;
using csharpLauncher.Model;
using csharpLauncher.Steps;

namespace csharpLauncher.Services
{
    internal static class StepFactory
    {
        public static IStepExec Create(Model.StepBase rawStep)
        {
            return rawStep.Type switch
            {
                StepType.RunApp => new RunAppStep(rawStep),
                _ => throw new NotSupportedException($"Step ({rawStep.Type}) not supported yet.")
            };
        }


    }
}
