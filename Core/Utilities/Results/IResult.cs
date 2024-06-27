namespace Core.Utilities.Results
{
    //Temel void methodlar için başlangıç
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
