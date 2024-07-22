using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DomraSinForms.Clients.Web.Mvc.Helpers;

public static class GravatarHelper
{

    private const string AvatarKey = "AvatarSourceKey";
    private const string BaseAvatarUrl = "https://www.gravatar.com/avatar/";
    public static void AddAvatar<T>(this ViewDataDictionary<T> viewData, string? email)
    {
        if (string.IsNullOrWhiteSpace(email)) return;

        viewData[AvatarKey] = BaseAvatarUrl + Hash(email.Trim().ToLower());
    }
    public static string? GetAvatarUrl<T>(this ViewDataDictionary<T> viewData)
    {
        return viewData[AvatarKey] as string;
    }

    private static string Hash(string value)
    {
        var inputBytes = Encoding.UTF8.GetBytes(value.ToLower());
        var inputHash = SHA256.HashData(inputBytes);
        return Convert.ToHexString(inputHash).ToLower();
    }
}
