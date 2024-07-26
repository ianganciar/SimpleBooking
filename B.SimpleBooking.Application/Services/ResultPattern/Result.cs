namespace B.SimpleBooking.Application.Services.ResultPattern;



public enum ResultState : byte
{
    Failed,
    Success
}

public readonly struct Result<TValue> where TValue : notnull
{
    internal readonly ResultState State;
    internal readonly TValue Value;
    internal readonly Error? Error;
    public readonly Error? Errors => Error;

    public Result(TValue value)
    {
        State = ResultState.Success;
        Value = value;
        Error = default;
    }

    public Result(Error error)
    {
        State = ResultState.Failed;
        Error = error;
        Value = default!;
    }

    public bool IsFailed => State == ResultState.Failed;
    public bool IsSuccess => State == ResultState.Success;

    public static implicit operator Result<TValue>(TValue value) => new(value);
    public static implicit operator Result<TValue>(Error error) => new(error);

    public T Match<T>(Func<TValue, T> onSuccess, Func<Error, T> onFailure)
    {
        return IsFailed ? onFailure(Error!) : onSuccess(Value);
    }

    public async Task<T> MatchAsync<T>(Func<TValue, Task<T>> onSuccess, Func<Error, T> onFailure)
    {
        return IsFailed ? onFailure(Error!) : await onSuccess(Value);
    }

    public Result<T> Map<T>(Func<TValue, T> f) where T : notnull
    {
        return IsFailed ? new(Error!) : new(f(Value));
    }

    public async Task<Result<T>> MapAsync<T>(Func<TValue, Task<T>> f) where T : notnull
    {
        return IsFailed ? new(Error!) : new(await f(Value));
    }
}