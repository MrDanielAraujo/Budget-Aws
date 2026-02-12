
namespace server.Shared.ValidationError;

public class ValidationError
{
    public string? InputName { get; }
    public string? TypeError { get; }

    public ValidationError(string? inputName, string typeError)
    {
        InputName = inputName != string.Empty ? inputName : null;
        TypeError = typeError;
    }
}