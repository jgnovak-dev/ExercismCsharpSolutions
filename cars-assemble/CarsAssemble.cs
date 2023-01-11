using System;

static class AssemblyLine {
    public static double SuccessRate(int speed) {

        var successRate = 0.0;
        
        switch (speed) {
            case 0:
                successRate = 0.0;
                break;
            
            case >= 1 and <= 4:
                successRate = 1.0;
                break;
            
            case >= 5 and <= 8:
                successRate = 0.9;
                break;
            
            case 9:
                successRate = 0.8;
                break;
            
            case 10:
                successRate = 0.77;
                break;
        }

        return successRate;
    }

    public static double ProductionRatePerHour(int speed) {
        return 221 * speed * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed) {
        return (int)ProductionRatePerHour(speed) / 60;
    }
}
