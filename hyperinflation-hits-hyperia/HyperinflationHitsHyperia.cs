using System;
using System.Globalization;

public static class CentralBank {
    public static string DisplayDenomination(long @base, long multiplier) {
        try {
            // The checked keyword explicitly checks for overflow and 
            // conversion of integral type values at compile time.
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/checked-and-unchecked
            // In a checked context, System.OverflowException is thrown if an 
            // overflow happens.
            return checked(@base * multiplier).ToString();
        } catch (OverflowException) {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier) {
        var product = @base * multiplier;

        // IsPositiveInfinity returns whether or not the specified value evaluates
        // to positive infinity
        return !float.IsPositiveInfinity(product) ? product.ToString(CultureInfo.InvariantCulture) : "*** Too Big ***";
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier) {
        try {
            return (salaryBase * multiplier).ToString(CultureInfo.InvariantCulture);
        } catch (OverflowException) {
            return "*** Much Too Big ***";
        }
    }
}
