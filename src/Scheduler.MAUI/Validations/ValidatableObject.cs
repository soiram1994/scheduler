using CommunityToolkit.Mvvm.ComponentModel;
using eShop.ClientApp.Validations;

namespace Scheduler.MAUI.Validations;

public class ValidatableObject<T> : ObservableObject, IValidity
{
    private IEnumerable<string> _errors;
    private bool _isValid;
    private T _value;

    public ValidatableObject()
    {
        _isValid = true;
        _errors = Enumerable.Empty<string>();
    }

    public List<IValidationRule<T>> Validations { get; } = new();

    public IEnumerable<string> Errors
    {
        get => _errors;
        private set => SetProperty(ref _errors, value);
    }

    public T Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }

    public bool IsValid
    {
        get => _isValid;
        private set => SetProperty(ref _isValid, value);
    }
    public bool IsInvalid => !IsValid;

    public bool Validate()
    {
        Errors = Validations
                     ?.Where(v => !v.Check(Value))
                     ?.Select(v => v.ValidationMessage)
                     ?.ToArray()
                 ?? Enumerable.Empty<string>();

        IsValid = !Errors.Any();

        return IsValid;
    }
}

public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
{
    public  required string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        return value is string str &&
               !string.IsNullOrWhiteSpace(str);
    }
}