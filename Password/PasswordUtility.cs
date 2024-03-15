using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordUtility
{
    public static string EncryptPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    public static bool VerifyPassword(string inputPassword, string hashedPassword)
    {
        string hashedInputPassword = EncryptPassword(inputPassword);
        return hashedInputPassword == hashedPassword;
    }
}
