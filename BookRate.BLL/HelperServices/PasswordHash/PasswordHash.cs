namespace BookRate.BLL.HelperServices.PasswordHash
{
    public static class PasswordHash
    {
        public static string Hash(string password)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public static bool CheckHash(string password, string hash)
            => BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
    }
}
