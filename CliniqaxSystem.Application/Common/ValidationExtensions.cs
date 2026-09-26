using FluentValidation.Results;

namespace CliniqaxSystem.Application.Common
{
    public static class ValidationExtensions
    {
        public static OperationResult ToResult(this ValidationResult result)
        {
            if (result.IsValid)
                return OperationResult.Ok();

            var errors = result.Errors.FirstOrDefault()?.ErrorMessage;
            return OperationResult.Failure(errors);
        }
    }
}
