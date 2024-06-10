using System.Globalization;

namespace BookRate.BLL.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string? message, string? key) : base($"{message}: {key} not found")
        {

        }
    }
}
