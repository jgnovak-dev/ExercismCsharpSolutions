using System;

public static class PlayAnalyzer {
    public static string AnalyzeOnField(int shirtNum) => shirtNum switch {
        1 => "goalie",
        2 => "left back",
        3 or 4 => "center back",
        5 => "right back",
        6 or 7 or 8 => "midfielder",
        9 => "left wing",
        10 => "striker",
        11 => "right wing",
        _ => throw new ArgumentOutOfRangeException(nameof(shirtNum), shirtNum, null)
    };

    public static string AnalyzeOffField(object report) => report switch {
       int supporters => $"There are {supporters} supporters at the match.",
       string announcement => announcement,
       Injury injury => $"Oh no! {injury.GetDescription()} Medics are on the field.",
       Incident incident => incident.GetDescription(),
       Manager manager => ManagerDescription(manager),
       _ => throw new ArgumentException(nameof(report), $"Not expected data type: {report}")
    };

    private static string ManagerDescription(Manager manager) {
        return manager.Club is null 
            ? manager.Name
            : $"{manager.Name} ({manager.Club})";
    }

}
