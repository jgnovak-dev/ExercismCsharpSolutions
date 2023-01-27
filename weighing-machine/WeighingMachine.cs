using System;

class WeighingMachine {
    private double _weight;

    public int Precision { get; }
    public double TareAdjustment { get; set; } = 5.0;

    public double Weight {
        get => _weight;
        set {
            var weight = value switch {
                < 0 => throw new ArgumentOutOfRangeException(),
                _ => _weight = value
            };

            _weight = weight;
        }
    }

    // Return adjusted weight as a string with precision applied
    public string DisplayWeight => Precision switch {
        1 => $"{_weight - TareAdjustment:N1} kg",
        2 => $"{_weight - TareAdjustment:N2} kg",
        3 => $"{_weight - TareAdjustment:N3} kg",
        _ => throw new ArgumentOutOfRangeException()
    };

    public WeighingMachine(int precision) {
        Precision = precision; 
    }
}
