namespace Framework.Security
{
    public class CryptoUtil
    {
        public static string BCHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool BCValify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }


    }
}