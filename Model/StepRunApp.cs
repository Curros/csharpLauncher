
namespace csharpLauncher.Model
{
    internal class StepRunApp : StepBase
    {
        /// <summary>
        /// Path to the app, windows can pick up process names.
        /// </summary>
        /// <remarks>If you can call it in 'win+r', should be ok for this.</remarks>
        public string? Path { get; set; }

        /// <summary>
        /// Check if the app is runing, and force a close before restarting.
        /// </summary>
        /// <remarks>Mainly used to run an app with parameters.</remarks>
        public bool ShouldRestartApp { get; set; } = false;

        /// <summary>
        /// Use the shell to execute the program insted of doing it directly from this launcher.
        /// </summary>
        public bool UseShellExecute { get; set; } = false;

        /// <summary>
        /// Args that will be passed when executing the app if needed.
        /// </summary>
        /// <remarks>If paths are used, try to scape //.</remarks>
        public List<string> Parameters { get; set; } = new List<string>();
    }
}
