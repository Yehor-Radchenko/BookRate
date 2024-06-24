namespace BookRate.BLL.Exceptions
{
    public class ConflictException : Exception
    {
        public IDictionary<string, string[]> Errors;
        public ConflictException(string? message, IDictionary<string, string[]>? errors = null) : base(message)
        {
            Errors = errors;
        }
    }
}
