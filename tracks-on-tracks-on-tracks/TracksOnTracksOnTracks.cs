using System;
using System.Collections.Generic;
using System.Linq;

public static class Languages {

    private readonly static List<string> LanguagesToLearn = new() { "C#", "Clojure", "Elm" };
    private readonly static string BestLanguage = "C#";
    
    public static List<string> NewList() => new();

    public static List<string> GetExistingLanguages() => LanguagesToLearn;

    public static List<string> AddLanguage(List<string> languages, string language) 
        => languages.Append(language).ToList();

    public static int CountLanguages(List<string> languages) 
        => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) 
        => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages)
        => languages.Reverse<string>().ToList();

    public static bool IsExciting(List<string> languages) {

        if (languages.Count == 0) {
            return false;
        }
        
        if (languages.First() == BestLanguage) {
            return true;
        }
        
        if (languages[1] == BestLanguage && languages.Count is >= 2 and <= 3) {
            return true;
        }

        return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language) 
        => languages.Where(l => l != language).ToList();
        

    public static bool IsUnique(List<string> languages) 
        => languages.Distinct().Count() == languages.Count;
}
