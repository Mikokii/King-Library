using System;
using System.Text.RegularExpressions;

namespace KingLibrary.Application.Helpers;

public static class TitleNormalizer
{
    private static readonly Regex LeadingArticles =
        new(@"^(the|a|an)\s+", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static string Normalize(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return string.Empty;

        var t = Regex.Replace(title, @"\s+", " ").Trim();

        t = LeadingArticles.Replace(t, "");

        return t;
    }

    public static string GetGroupKey(string title)
    {
        var normalized = Normalize(title).TrimStart();

        if (string.IsNullOrEmpty(normalized))
            return "#";

        var first = normalized[0];

        return char.IsLetter(first)
            ? char.ToUpperInvariant(first).ToString()
            : "#";
    }
}