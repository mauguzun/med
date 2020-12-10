using Calculator.Exceptions;
using Calculator.Interfaces;
using Calculator.Models;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Implementations
{
    public class CalculatorService : ICalculator
    {
        private decimal? _result = 0;
        private string _history = null;
        private char lastMathAction;

        private List<Expression> _opertaionStack = new List<Expression>();

        public void Calculate(Expression operand)
        {

            this._opertaionStack.Add(operand);
            _history = string.Empty;
            foreach (var item in _opertaionStack)
            {
                _history += $"{item.Number} {item.Operand} ";
            }
            _Calculate();

        }

        public CalcAnswer Answer() => new CalcAnswer { History = _history, Result = _result ?? 0 };

        private void _Calculate()
        {
            _result = 0;
            if (this._opertaionStack.Where(x => x.Operand == (char)Operations.Clear).Any())
            {
                _result = 0;
                this._history = string.Empty;
                this._opertaionStack = new List<Expression>();
            }


            foreach (var item in this._opertaionStack)
            {
                _SwithOperand(item);
            }

        }

        private void _SwithOperand(Expression item)
        {
            switch (item.Operand)
            {

                case (char)Operations.Add:
                    lastMathAction = (char)Operations.Add;
                    this._result += item.Number;
                    break;

                case (char)Operations.Subtract:
                    lastMathAction = (char)Operations.Subtract;
                    if (this._result == 0)
                        this._result = item.Number;
                    else
                        this._result -= item.Number;
                    break;

                case (char)Operations.Multiply:
                    if (this._result == 0)
                        this._result = item.Number;
                    else
                        this._result *= item.Number;

                    lastMathAction = (char)Operations.Multiply;
                    break;

                case (char)Operations.Divide:

                    if (item.Number == 0)
                    {
                        this._result = 0;    //throw new DivideByZeroException();
                        this._history = "Divide exception";
                    }
                    if (this._result == 0)
                        this._result = item.Number;
                    else
                        this._result /= item.Number;

                    lastMathAction = (char)Operations.Divide;
                    break;

                case (char)Operations.Procents:
                    item.Number = this._result.Value / 100 * item.Number;
                    _SwithOperand(new Expression { Number = item.Number, Operand = lastMathAction });
                    break;

                case (char)Operations.Equally:
                    this._opertaionStack = new List<Expression>();
                    _SwithOperand(new Expression { Number = item.Number, Operand = lastMathAction });
                    break;

                default:
                    throw new NotOpertorException();

            }
        }
    }
}
