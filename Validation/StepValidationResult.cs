using csharpLauncher.Enums;

namespace csharpLauncher.Validation
{
    public class StepValidationResult
    {
        public ValidationSeverity Severity { get; set; }

        public string Message { get; set; } = string.Empty;

        public StepValidationResult(ValidationSeverity severity, string message)
        {
            Severity = severity;
            Message = message;
        }

        public override string ToString() => $"[{Severity}] {Message}";
    }
}
