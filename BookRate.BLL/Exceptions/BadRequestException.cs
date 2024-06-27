using System.Security.Cryptography.X509Certificates;

namespace BookRate.BLL.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]>? Errors;
        public BadRequestException(string? message, IDictionary<string, string[]>? errors = null) : base("Something went wrong")
        {
            Errors = errors;
        }
    }
}
