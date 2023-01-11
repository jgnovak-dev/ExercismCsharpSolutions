using System;

public class Player {
    public int RollDie() {
        var random = new Random();
        return random.Next(1, 18);
    }

    public double GenerateSpellStrength() {
        var random = new Random();
        // Random number between 0.0 and 100.0
        return random.NextDouble() * 100;
    }
}
