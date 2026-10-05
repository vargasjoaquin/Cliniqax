namespace CliniqaxSystem.Application.Common
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public int? EntityId { get; set; }

        public static OperationResult Ok(string message = "Operación exitosa.", int? entityId = null)
            => new() { Success = true, Message = message, EntityId = entityId };

        public static OperationResult Failure(string message)
            => new() { Success = false, Message = message };
    }
}
