using csharpLauncher.Enums;

namespace csharpLauncher.Model
{
    internal class StepBase
    {
        /// <summary>
        /// Use a name, mainly a decorator to have some extra info in the logs.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// O add information into the console.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Defined type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StepType Type { get; set; }
    }
}
