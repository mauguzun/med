using Calculator.Models;

namespace Calculator.Interfaces
{
    public interface ICalculator
    {
        void Calculate(Expression operand);
        CalcAnswer Answer();
    }
}
