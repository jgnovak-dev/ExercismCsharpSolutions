using System;
using System.Linq;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder();
        var isAfterDash = false;

        foreach (var c in identifier)
        {
            sb.Append(c switch
            {
                _ when isAfterDash => char.ToUpperInvariant(c),
                _ when IsGreekLowercaseLetter(c) => default,
                _ when char.IsWhiteSpace(c) => '_',
                _ when char.IsControl(c) => "CTRL",
                _ when char.IsLetter(c) => c,
               _ => default 
            });

            isAfterDash = c.Equals('-');
        }

        return sb.ToString();
    }
    
    private static bool IsGreekLowercaseLetter(char c) => c is >= 'α' and <= 'ω';
}
