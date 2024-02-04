namespace DomraSin.Domain;

public record Result(bool IsSuccess, string? ErrorMessage = null)
{
    public static Result<T> Failure(string? errorMessage = null) => new(false, errorMessage);
}

public record Result<T>(bool IsSuccess, string? ErrorMessage = null, T? Value = null) : Result(IsSuccess, ErrorMessage){
    public static Result<T> Success(T value) => new(true, Value: value);

}