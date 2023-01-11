using System;
using System.Linq;

public static class LogAnalysis {
    public static string SubstringAfter(this string input, string delimiter) {
        return input.Split(delimiter).Last();
    }

    public static string SubstringBetween(this string input, string firstDelimiter, string secondDelimiter) {
        return input.Split(secondDelimiter).First().Split(firstDelimiter).Last();
    }

    public static string Message(this string input) {
        return input.SubstringAfter(": ");
    }

    public static string LogLevel(this string input) {
        return input.SubstringBetween("[", "]");
    }
}
