using System;

namespace MyWpfProgCalculator
{
    public enum CalcOperations
    {
        none, addition, substraction, multiplication, division, modulus, percent, result, power, nthroot, sin, cos, tan, fibonacci, factorial
    }

    public abstract class ACalculator
    {
        public double CurrResult 
        {
            get; set;
        }

        public string StrMainDisplay
        {
            get; set;
        }

        public string StrAuxDisplay
        {
            get; set;
        }

        public CalcOperations LastOperation { get; set; }

        public abstract void ProcessDigitInput(string sTemp);

        public abstract void ProcessBinaryOperatorInput(string sTemp);

        public abstract void Add(double value);

        public abstract void Substract(double value);

        public abstract void Muliply(double value);

        public abstract void Divide(double value);

        public abstract void Modulus(double value);

        public abstract void Power(double value);

        public abstract void DelChar();

        public abstract void Clear();

        public abstract void DoPendingOperation(string sTemp);

    }

}