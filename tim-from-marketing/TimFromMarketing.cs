using System;

static class Badge {
    public static string Print(int? id, string? name, string? department) {

        // Naive approach:
        // string badgeString = string.Empty;
        //
        // if (id != null) {
        //     badgeString += $"[{id}] - ";
        // }
        //
        // if (name != null) {
        //     badgeString += $"{name} - ";
        // }
        //
        // badgeString += department?.ToUpper() ?? "OWNER";
        //
        // return badgeString; 
        
        // Top solution:
        department = (department ?? "owner").ToUpper();

        return id.HasValue switch {
            true => $"[{id}] - {name} - {department}",
            false => $"{name} - {department}"
        };
    }
}
