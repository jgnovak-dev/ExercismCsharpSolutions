using System;

static class SavingsAccount {
    public static float InterestRate(decimal balance) {

        // Old way of writing the switch/case
        // float interest = 0.0f;
        //
        // switch (balance) {
        //     case < 0:
        //         interest = 3.213f;
        //         break;
        //     
        //     case < 1_000:
        //         interest = 0.5f;
        //         break;
        //     
        //     case >= 1_000 and < 5_000:
        //         interest = 1.621f;
        //         break;
        //     
        //     default:
        //         interest = 2.475f;
        //         break;
        //
        // }
        //
        // return interest;

        return balance switch {
            < 0 => 3.213f,
            < 1_000 => 0.5f,
            >= 1_000 and < 5_000 => 1.621f,
            _ => 2.475f
        };
    }

    public static decimal Interest(decimal balance) {
        return balance * ((decimal)InterestRate(balance) / 100);
    }

    public static decimal AnnualBalanceUpdate(decimal balance) {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance) {
        var years = 0;

        while (targetBalance > balance) {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }

        return years;
    }
}
