namespace StarWarsApi.Core.Helpers
{
    /// <summary>
    /// https://gist.github.com/vkhorikov/7852c7606f27c52bc288#file-result-cs
    /// </summary>
    public class Result
    {
        public bool Success { get; private set; }

        public string Error { get; private set; }

        public bool Failure => !Success;

        protected Result(bool success, string error) 
        {
            Success = success;
            Error = error;
        }

        public static Result Fail(string message) => new Result(false, message);

        public static Result<T> Fail<T>(string message) => new Result<T>(default, false, message);

        public static Result Ok() => new Result(true, string.Empty);

        public static Result<T> Ok<T>(T value) => new Result<T>(value, true, string.Empty);
    }

    public class Result<T> : Result
    {
        public T Value { get; private set; }
        
        protected internal Result(T value, bool success, string error) : base(success, error)
        {
            Value = value;
        }
    }
}