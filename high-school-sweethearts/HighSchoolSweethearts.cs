using System;
using System.Globalization;

public static class HighSchoolSweethearts {
    public static string DisplaySingleLine(string studentA, string studentB) {
        // Left and right padded string totaling 61 characters in width
        return $"{studentA,29} ♡ {studentB,-29}";
    }

    public static string DisplayBanner(string studentA, string studentB) {
        // Raw string literal to preserve formatting
        return $@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA.Trim()}  +  {studentB.Trim()}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
        ";
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours) {
        // Broken up for readability, but could be one line too
        return
            string.Format(
            new CultureInfo("de-DE"),
            "{0} and {1} have been dating since {2:d} - that's {3:n2} hours",
            studentA, studentB, start, hours
            );
    }
}
