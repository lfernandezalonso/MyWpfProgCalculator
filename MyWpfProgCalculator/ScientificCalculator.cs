using System;

namespace MyWpfProgCalculator
{
    public class ScientificCalculator: StandardCalculator
    {
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

        public virtual void NthRoot(double value)
        {
            CurrResult = Math.Pow(CurrResult, 1/value);
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
                    case CalcOperations.nthroot:
                        NthRoot(nTemp);
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

        public void Sin(double x)
        {          
            CurrResult = Math.Sin(x);
        }

        public void Cos(double x)
        {
            CurrResult = Math.Cos(x);
        }
        public void Tan(double x)
        {
            CurrResult = Math.Tan(x);
        }

        public void Cot(double x)
        {
            CurrResult = 1/Math.Tan(x);
        }
    }
}