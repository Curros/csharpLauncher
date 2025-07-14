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
                StepType.RunApp => 
                    new Steps.StepRunApp((Model.StepRunApp)rawStep)
                        ?? throw new InvalidCastException($"Invalid ({rawStep.Type}) cast."),

                _ => throw new NotSupportedException($"Step ({rawStep.Type}) not supported yet.")
            };
        }


    }
}
