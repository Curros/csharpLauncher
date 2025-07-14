using csharpLauncher.Enums;
using csharpLauncher.Model;
using csharpLauncher.Validation;

namespace csharpLauncher.Services
{
    internal class StepService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
        internal async Task RunAsync(string jsonPath)
        {
            var json = File.ReadAllText(jsonPath);

            var rawSteps = JsonConvert.DeserializeObject<List<StepBase>>(json)
                ?? new List<StepBase>();

            Log.Information("Steps loaded: ({Count})", rawSteps.Count);

            foreach (var rawStep in rawSteps)
            {

                try
                {
                    Log.Information("Executing step: {Type}", rawStep.Type);

                    var step = StepFactory.Create(rawStep);

                    CheckValidations(step.Validate());

                    await step.ExecuteAsync();

                    Log.Information("Step {Type} executed", rawStep.Type);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error running step {Type}", rawStep.Type);
                    throw;
                }

            }

            Log.Information("Enjoy!!!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validations"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private void CheckValidations(List<StepValidationResult> validations)
        {
            foreach (var validationResult in validations)
            {
                switch (validationResult.Severity)
                {
                    case ValidationSeverity.Error:
                        throw new InvalidOperationException(validationResult.Message);
                    case ValidationSeverity.Warning:
                        Log.Warning(validationResult.Message);
                        break;
                    case ValidationSeverity.Info:
                    default:
                        Log.Information(validationResult.Message);
                        break;
                }
                ;
            }
        }
    }
}
