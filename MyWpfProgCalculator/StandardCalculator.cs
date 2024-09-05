using System;

namespace MyWpfProgCalculator
{
    public class StandardCalculator : ACalculator
    {
        public bool PreviousBtnWasOper { get; set; }

        public StandardCalculator()
        {
            CurrResult = 0;
            StrMainDisplay = "0";
            LastOperation = CalcOperations.none;            
            StrAuxDisplay = "";
            PreviousBtnWasOper = false;
        }

        public override void ProcessDigitInput(string strTemp)
        {
            if (PreviousBtnWasOper)
            {
                CurrResult = double.Parse(StrMainDisplay);
                StrMainDisplay = strTemp;
            }
            else
            {
                if (StrMainDisplay != "0")
                {
                    StrMainDisplay += strTemp;
                }
                else
                {
                    if (strTemp != "0")
                    {
                        StrMainDisplay = strTemp;
                        CurrResult = double.Parse(StrMainDisplay);
                    }
                    else
                    {
                        StrMainDisplay = "0";
                        CurrResult = 0;
                    }
                }
            }
            PreviousBtnWasOper = false;
        }

        public override void ProcessDecPointInput()
        {
            if (StrMainDisplay.IndexOf(".") == -1)
                StrMainDisplay += ".";
        }

        public override CalcOperations GetOperationValueGivenStr(string sTemp)
        {
            if (sTemp == "+")
                return CalcOperations.addition;
            if (sTemp == "-")
                return CalcOperations.substraction;
            if (sTemp == "x")
                return CalcOperations.multiplication;
            if (sTemp == "/")
                return CalcOperations.division;
            if (sTemp == "mod")
                return CalcOperations.modulus;
            if (sTemp == "%")
                return CalcOperations.percent;
            if (sTemp == "^")
                return CalcOperations.power;
            if (sTemp == "√")
               return CalcOperations.nthroot;
            if (sTemp == "=")
                return CalcOperations.result;
            return CalcOperations.none;
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
                    DoPendingOperation();
                }
                catch (DivideByZeroException ex)
                {
                    StrMainDisplay = "Cannot divide by zero";
                    throw ex;
                }
                finally
                {
                    StrMainDisplay = CurrResult.ToString();
                }
            }
            LastOperation = GetOperationValueGivenStr(sTemp);
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

        public virtual void Percent(double value)
        {
            CurrResult = (value * (CurrResult / 100));
        }

        public override void ChangeSign(double value) 
        {
            CurrResult = -value; 
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

        public override void DoPendingOperation()
        {
            try
            {
                var nTemp = double.Parse(StrMainDisplay);
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
                    case CalcOperations.percent:
                        Percent(nTemp);
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