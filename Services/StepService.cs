using csharpLauncher.Enums;
using csharpLauncher.Model;

namespace csharpLauncher.Services
{
    internal class StepService
    {
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
                    await step.ExecuteAsync();

                    Log.Information("Step {Type} executed", rawStep.Type);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error ejecutando step {Type}", rawStep.Type);
                    throw;
                }

            }

            Log.Information("Enjoy!!!");
        }
    }
}
