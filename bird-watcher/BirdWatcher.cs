using System;
using System.Linq;

class BirdCount {
    private int[] _birdsPerDay;

    public BirdCount(int[] birdsPerDay) {
        _birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() {
        return new[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    public int Today() {
        return _birdsPerDay.Last();
    }

    public void IncrementTodaysCount() {
        _birdsPerDay[_birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds() {
        return _birdsPerDay.Any(b => b == 0);
    }

    public int CountForFirstDays(int numberOfDays) {
        var index = 0;
        var total = 0;

        while (index < numberOfDays) {
            total += _birdsPerDay[index];
            index++;
        }

        return total;
    }

    public int BusyDays() {
        var result = _birdsPerDay.Where(b => b >= 5);
        return result.Count();
    }
}
