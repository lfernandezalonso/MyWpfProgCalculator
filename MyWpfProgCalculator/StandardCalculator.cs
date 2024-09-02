using System;

namespace MyWpfProgCalculator
{
    public class StandardCalculator : ACalculator
    {
        //public double CurrResult { get; set; }

        //public override CalcOperations LastOperation { get; set; }

        public bool PreviousBtnWasOper { get; set; }

        public StandardCalculator()
        {
            CurrResult = 0;
            LastOperation = CalcOperations.none;
            StrMainDisplay = "0";
            StrAuxDisplay = "";
            PreviousBtnWasOper = false;
        }

        public override void ProcessDigitInput(string strTemp)
        {
            if (PreviousBtnWasOper)
            {
                this.CurrResult = double.Parse(this.StrMainDisplay);
                this.StrMainDisplay = strTemp;
            }
            else
            {
                var tempRes = double.Parse(StrMainDisplay);
                if (StrMainDisplay != "0")
                {
                    StrMainDisplay += strTemp;
                }
                else
                {
                    if (strTemp != "0")
                    {
                        StrMainDisplay = strTemp;
                        this.CurrResult = double.Parse(this.StrMainDisplay);
                    }
                    else
                    {
                        StrMainDisplay = "0";
                        this.CurrResult = 0;
                    }
                }
            }
            PreviousBtnWasOper = false;
        }

        public override void ProcessBinaryOperatorInput(string sTemp)
        {
            if (LastOperation == CalcOperations.none)
            {
                CurrResult = double.Parse(StrMainDisplay);
            }
            else
            {
                try
                {
                    DoPendingOperation(StrMainDisplay);
                }
                catch (DivideByZeroException)
                {
                    StrMainDisplay = "Cannot divide by zero";
                }
                finally
                {
                    StrMainDisplay = CurrResult.ToString();
                }
            }
            if (sTemp == "+")
                LastOperation = CalcOperations.addition;
            if (sTemp == "-")
                LastOperation = CalcOperations.substraction;
            if (sTemp == "x")
                LastOperation = CalcOperations.multiplication;
            if (sTemp == "/")
                LastOperation = CalcOperations.division;
            if (sTemp == "mod")
                LastOperation = CalcOperations.modulus;
            if (sTemp == "%")
                LastOperation = CalcOperations.percent;
            if (sTemp == "^")
                LastOperation = CalcOperations.power;
            if (sTemp == "=")
                LastOperation = CalcOperations.result;
            StrAuxDisplay = CurrResult.ToString() + " " + sTemp;
            PreviousBtnWasOper = true;
        }

        public override void Add(double value)
        {
            CurrResult += value;
        }

        public override void Substract(double value)
        {
            CurrResult -= value;
        }

        public override void Muliply(double value)
        {
            CurrResult *= value;
        }

        public override void Divide(double value)
        {
            CurrResult /= value;
        }

        public override void Modulus(double value)
        {
            CurrResult %= value;
        }

        public override void Power(double value)
        {
            CurrResult = Math.Pow(CurrResult, value);
        }

        public override void DelChar() 
        {
            var nTemp = StrMainDisplay.Length;
            if (nTemp >= 2)
            {
                StrMainDisplay = StrMainDisplay.Substring(0, nTemp-1);
            }
            else
            {
                StrMainDisplay = "0";
            }
        }

        public override void Clear()
        {
            CurrResult = 0;
        }

        public override void DoPendingOperation(string sTemp)
        {
            try
            {
                var nTemp = double.Parse(sTemp);
                switch (LastOperation)
                {
                    case CalcOperations.addition:
                        Add(nTemp);
                        break;
                    case CalcOperations.substraction:
                        Substract(nTemp);
                        break;
                    case CalcOperations.multiplication:
                        Muliply(nTemp);
                        break;
                    case CalcOperations.division:
                        Divide(nTemp);
                        break;
                    case CalcOperations.modulus:
                        Modulus(nTemp);
                        break;
                    case CalcOperations.power:
                        Power(nTemp);
                        break;
                }
                StrMainDisplay = CurrResult.ToString();
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
            finally
            {
                LastOperation = CalcOperations.none;
            }
        }

        public virtual long Fibonacci(long x)
        {
            if (x == 0)
                return 0;

            if (x == 1)
                return 1;

            return Fibonacci(x - 1) + Fibonacci(x - 2);
        }

        public virtual long Factorial(long x)
        {
            if (x < 2)
                return 1;

            return (Factorial(x - 1) * x);
        }

        public virtual long IsPrime(long x)
        {
            long y = Math.Abs(x);
            if (y <= 2)
                return 1;

            for (var i = y / 2; i < 2; i++)
            {
                if (y % i == 0)
                    return 0;
            }
            return 1;
        }

    }
}