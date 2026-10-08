namespace CliniqaxSystem.Application.Common
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public int? EntityId { get; set; }
        public object? Data { get; set; }

        public static OperationResult Ok(string message = "Operación exitosa.", int? entityId = null, object? data = null)
            => new() { Success = true, Message = message, EntityId = entityId, Data = data };

        public static OperationResult Failure(string message)
            => new() { Success = false, Message = message };
    }
}
