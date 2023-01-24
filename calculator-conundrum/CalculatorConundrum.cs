using System;

public static class SimpleCalculator {
    public static string Calculate(int operand1, int operand2, string operation) {

        string result;

        switch (operation) {
            case "+":
                result = $"{operand1} {operation} {operand2} = {operand1 + operand2}";
                break;

            case "/":
                if (operand1 == 0 || operand2 == 0) {
                    result = "Division by zero is not allowed.";
                } else {
                    result = $"{operand1} {operation} {operand2} = {operand1 / operand2}";
                }
                break;

            case "*":
                result = $"{operand1} {operation} {operand2} = {operand1 * operand2}";
                break;

            case "-" or "**":
                throw new ArgumentOutOfRangeException();

            case "":
                throw new ArgumentException();

            default:
                throw new ArgumentNullException();
        }

        return result;
    }
}
