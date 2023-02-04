using System;
using System.Runtime.Serialization;

public class CalculationException : Exception {

    public CalculationException() : base() {}
    public CalculationException(string message) : base(message) {}
    public CalculationException(string message, Exception inner) : base(message, inner) {}
    public CalculationException(SerializationInfo info, StreamingContext context) : base(info, context) {}

    public CalculationException(int operand1, int operand2, string message, Exception inner) : this(message, inner) {
        Operand1 = operand1;
        Operand2 = operand2;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness {
    private Calculator _calculator;

    public CalculatorTestHarness(Calculator calculator) {
        _calculator = calculator;
    }

    public string TestMultiplication(int x, int y) {
        try {
            Multiply(x, y);
            return "Multiply succeeded";
        } catch (CalculationException exception) when (exception.Operand1 < 0 && exception.Operand2 < 0) {
            return $"Multiply failed for negative operands. {exception.InnerException?.Message}";
        } catch (CalculationException exception) {
            return $"Multiply failed for mixed or positive operands. {exception.InnerException?.Message}";
        }
    }

    public void Multiply(int x, int y) {
        try {
            _calculator.Multiply(x, y);
        } catch (OverflowException exception) {
            throw new CalculationException(x, y, "error in Multiply", exception);
        }
   } 
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator {
    public int Multiply(int x, int y) {
        checked {
            return x * y;
        }
    }
}
