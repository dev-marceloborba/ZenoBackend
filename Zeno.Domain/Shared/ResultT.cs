namespace Datacenter.Domain.Shared;

public class Result<TValue> : Result
{
    private readonly TValue? _value;
    protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value => IsSuccess
       ? _value!
       : throw new InvalidOperationException("O valor da falha nao pode ser acessado");

    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}
