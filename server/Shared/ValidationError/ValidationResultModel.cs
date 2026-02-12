using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace server.Shared.ValidationError;

public class ValidationResultModel
{
    public List<ValidationError> Errors { get; }

    public ValidationResultModel(List<ValidationError> errors)
    {
        Errors = errors;
    }
    public ValidationResultModel(ModelStateDictionary modelState)
    {
        Errors = modelState.Keys
            .SelectMany(key => modelState[key]!.Errors.Select(x => new ValidationError(key, x.ErrorMessage))).ToList();
    }
}