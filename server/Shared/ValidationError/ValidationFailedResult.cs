using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace server.Shared.ValidationError;

public class ValidationFailedResult : ObjectResult
{
    public ValidationFailedResult(ModelStateDictionary modelState) : base(new ValidationResultModel(modelState))
    {
        StatusCode = StatusCodes.Status400BadRequest;
    }
}