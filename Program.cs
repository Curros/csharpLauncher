using csharpLauncher.Services;

namespace csharpLauncher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithExceptionDetails()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();

            try
            {
                Log.Information("Let's get this party started!");

                if (args.Length == 0)
                {
                    Log.Error("App doesn't work if a JSON config file for the steps is not provided.");
                    return;
                }

                var jsonPath = args[0];
                if (!File.Exists(jsonPath))
                    throw new FileNotFoundException("Can´t find the provided JSON config file path", jsonPath);

                var runner = new StepService();
                runner.RunAsync(jsonPath);

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandle exception");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
