﻿using System.Security.Cryptography;
using System.Text;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {

        byte[] salt = RandomNumberGenerator.GetBytes(16);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations: 100000,
            HashAlgorithmName.SHA256,
            outputLength: 32);

        byte[] hashBytes = new byte[48];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 32);

        return Convert.ToBase64String(hashBytes);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {

        byte[] hashBytes = Convert.FromBase64String(hashedPassword);


        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations: 100000,
            HashAlgorithmName.SHA256,
            outputLength: 32);


        for (int i = 0; i < 32; i++)
        {
            if (hashBytes[i + 16] != hash[i])
            {
                return false;
            }
        }

        return true;
    }
}