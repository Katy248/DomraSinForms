using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Interfaces;
using DomraSinForms.Domain.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DomraSinForms.Application.Services.Authentication;
public class PasswordService : IPassswordHasher
{
    public User HashPassword(User user, string password)
    {
        user.Salt = RandomNumberGenerator.GetBytes(128 / 8);
        Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: user.Salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return user;
    }
    public bool Compare(User user, string password)
    {
        throw new NotImplementedException();
    }

    public byte[] GetSalt()
    {
        return RandomNumberGenerator.GetBytes(128 / 8);
    }

    public string GetHash(string password, byte[] salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
    }
}
