using System.Text.RegularExpressions;

namespace BookRate.Validation.Extentions
{
    public static class ValidationHelper
    {
        public static bool HasLeadingOrTrailingSpaces(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;
            return input.StartsWith(" ") || input.EndsWith(" ");
        }

        public static bool HasMultipleSpaces(string input)
        {
            return Regex.IsMatch(input, @"\s{2,}");
        }
    }
}
