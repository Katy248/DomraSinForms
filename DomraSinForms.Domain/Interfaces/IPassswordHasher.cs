using DomraSinForms.Domain.Models;

namespace DomraSinForms.Domain.Interfaces;

public interface IPassswordHasher
{
    byte[] GetSalt();
    string GetHash(string password, byte[] salt);
}