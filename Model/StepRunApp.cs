
namespace csharpLauncher.Model
{
    internal class StepRunApp : StepBase
    {
        /// <summary>
        /// Check if the app is runing, and force a close before restarting.
        /// </summary>
        /// <remarks>Mainly used to run an app with parameters.</remarks>
        public bool ShouldRestartApp { get; set; }

        /// <summary>
        /// Args that will be passed when executing the app if needed.
        /// </summary>
        /// <remarks>If paths are used, try to scape //.</remarks>
        public List<string> Parameters { get; set; } = new List<string>();
    }
}
