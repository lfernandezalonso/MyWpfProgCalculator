using System.Windows;
using System.Windows.Controls;

namespace MyWpfProgCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ACalculator myCalculator;
        private string sPreviousTab; 
 
        public MainWindow()
        {
            InitializeComponent();

            sPreviousTab = "";
        }

        private string GetSelectedTabHeader(TabItem tItem)
        {
            var sTabHeader = tItem.Header.ToString();
            return sTabHeader.Trim().ToUpper();
        }

        private void TabItem_Selected(object sender, RoutedEventArgs e)
        {
            var sCurrTab = GetSelectedTabHeader(sender as TabItem);
            if (sCurrTab != sPreviousTab)
            {
                if (sCurrTab == "STANDARD CALC")
                {
                    myCalculator = new StandardCalculator();
                }
                if (sCurrTab == "SCIENTIFIC CALC")
                {
                    myCalculator = new ScientificCalculator();
                }
                if (myCalculator == null)
                    myCalculator = new StandardCalculator();

                txtCalcMainDisplay.Text = myCalculator.StrMainDisplay;
                txtCalcAuxDisplay.Text = myCalculator.StrAuxDisplay;
                rtbHistory.Document.Blocks.Clear();
                sPreviousTab = sCurrTab;
            }
        }

        private void BtnDigit_Click(object sender, RoutedEventArgs e)
        {
            string strTemp = ((Button) sender).Content.ToString();
            myCalculator.ProcessDigitInput(strTemp);
            txtCalcMainDisplay.Text = myCalculator.StrMainDisplay;
            txtCalcAuxDisplay.Text = myCalculator.StrAuxDisplay;
            if (!AreOperationButtonsEnabled()) 
            {
                EnableOperationButtons(true);
            }
        }

        private void BtnDecPoint_Click(object sender, RoutedEventArgs e) 
        {
            myCalculator.ProcessDecPointInput();
            txtCalcMainDisplay.Text = myCalculator.StrMainDisplay;
        }

        private void BtnBinaryOperator_Click(object sender, RoutedEventArgs e)
        {
            var sTemp = ((Button) sender).Content.ToString();
            myCalculator.ProcessBinaryOperatorInput(sTemp);
            txtCalcMainDisplay.Text = myCalculator.StrMainDisplay;
            txtCalcAuxDisplay.Text = myCalculator.StrAuxDisplay;
            EnableOperationButtons(false);
        }

        private void BtnCOper_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.CurrResult = 0;
            myCalculator.StrMainDisplay = "0";
            txtCalcMainDisplay.Text = myCalculator.StrMainDisplay;
            myCalculator.LastOperation = CalcOperations.none;
            myCalculator.StrAuxDisplay = "";
            txtCalcAuxDisplay.Text = "";
        }

        private void EnableOperationButtons(bool bValue)
        {
            var sTemp = GetSelectedTabHeader(MyTabControl.SelectedItem as TabItem);
            if (sTemp == "STANDARD CALC")
            {
                btn_StdCalc_AdditionOper.IsEnabled = bValue; btn_StdCalc_SubstractOper.IsEnabled = bValue; btn_StdCalc_MultiplicOper.IsEnabled = bValue;
                btn_StdCalc_DivisionOper.IsEnabled = bValue; btn_StdCalc_ModOper.IsEnabled = bValue; btn_StdCalc_ExpOper.IsEnabled = bValue;
                btn_StdCalc_PercOper.IsEnabled = bValue; btn_StdCalc_MinusOrPlus.IsEnabled = bValue; btn_StdCalc_DecPoint.IsEnabled = bValue; 
                btn_StdCalc_FactOper.IsEnabled = bValue; btn_StdCalc_FibOper.IsEnabled = bValue; btn_StdCalc_DelOper.IsEnabled = bValue;
                btn_StdCalc_EqualOper.IsEnabled = bValue;
            }
            if (sTemp == "SCIENTIFIC CALC")
            {
                btn_SciCalc_AdditionOper.IsEnabled = bValue; btn_SciCalc_SubstractOper.IsEnabled = bValue; btn_SciCalc_MultiplicOper.IsEnabled = bValue;
                btn_SciCalc_DivisionOper.IsEnabled = bValue; btn_SciCalc_ModOper.IsEnabled = bValue; btn_SciCalc_ExpOper.IsEnabled = bValue;
                btn_SciCalc_NthRootOper.IsEnabled = bValue; btn_SciCalc_PercOper.IsEnabled = bValue; btn_SciCalc_SinOper.IsEnabled = bValue;
                btn_SciCalc_CosOper.IsEnabled = bValue; btn_SciCalc_TanOper.IsEnabled = bValue; btn_SciCalc_CotOper.IsEnabled = bValue;
                btn_SciCalc_MinusOrPlus.IsEnabled = bValue; btn_SciCalc_DecPoint.IsEnabled = bValue; btn_SciCalc_LogOper.IsEnabled = bValue;
                btn_SciCalc_LnOper.IsEnabled = bValue; btn_SciCalc_FactOper.IsEnabled = bValue; btn_SciCalc_FibOper.IsEnabled = bValue;
                btn_SciCalc_DelOper.IsEnabled = bValue; btn_SciCalc_EqualOper.IsEnabled = bValue;
            }
        } 

        public bool AreOperationButtonsEnabled()
        {
            var sTemp = GetSelectedTabHeader(MyTabControl.SelectedItem as TabItem);
            if (sTemp == "STANDARD CALC")
            {
                return btn_StdCalc_AdditionOper.IsEnabled && btn_StdCalc_SubstractOper.IsEnabled && btn_StdCalc_MultiplicOper.IsEnabled  && 
                    btn_StdCalc_DivisionOper.IsEnabled && btn_StdCalc_ModOper.IsEnabled && btn_StdCalc_ExpOper.IsEnabled && btn_StdCalc_PercOper.IsEnabled && 
                    btn_StdCalc_MinusOrPlus.IsEnabled && btn_StdCalc_DecPoint.IsEnabled && btn_StdCalc_FactOper.IsEnabled && btn_StdCalc_FibOper.IsEnabled &&
                    btn_StdCalc_DelOper.IsEnabled && btn_StdCalc_EqualOper.IsEnabled;
            }
            if (sTemp == "SCIENTIFIC CALC")
            {
                return btn_SciCalc_AdditionOper.IsEnabled && btn_SciCalc_SubstractOper.IsEnabled && btn_SciCalc_MultiplicOper.IsEnabled && 
                    btn_SciCalc_DivisionOper.IsEnabled && btn_SciCalc_ModOper.IsEnabled && btn_SciCalc_ExpOper.IsEnabled && btn_SciCalc_NthRootOper.IsEnabled && 
                    btn_SciCalc_PercOper.IsEnabled && btn_SciCalc_SinOper.IsEnabled && btn_SciCalc_CosOper.IsEnabled && btn_SciCalc_TanOper.IsEnabled &&
                    btn_SciCalc_CotOper.IsEnabled && btn_SciCalc_MinusOrPlus.IsEnabled && btn_SciCalc_DecPoint.IsEnabled && btn_SciCalc_LogOper.IsEnabled && 
                    btn_SciCalc_LnOper.IsEnabled && btn_SciCalc_FactOper.IsEnabled && btn_SciCalc_FibOper.IsEnabled && btn_SciCalc_DelOper.IsEnabled && 
                    btn_SciCalc_EqualOper.IsEnabled;
            }
            return true;
        }

        private void BtnDelOper_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.DelChar();
            txtCalcMainDisplay.Text = myCalculator.StrMainDisplay;
        }

        private void BtnUnitaryOper_Click(object sender, RoutedEventArgs e)
        {
            if (myCalculator.LastOperation != CalcOperations.none)
            {
                myCalculator.DoPendingOperation();
                myCalculator.LastOperation = CalcOperations.none;
            }
            var sTemp = ((Button)sender).Content.ToString();
            if (sTemp == "fib")
            {
                (myCalculator as StandardCalculator).Fibonacci(long.Parse(txtCalcMainDisplay.Text));
                rtbHistory.Document.ContentStart.InsertTextInRun(sTemp + "\n");
            }
            if (sTemp == "n!")
            {
                (myCalculator as StandardCalculator).Factorial(long.Parse(txtCalcMainDisplay.Text));
                rtbHistory.Document.ContentStart.InsertTextInRun(sTemp + "\n");
            }
            if (sTemp == "sin")
            {
                (myCalculator as ScientificCalculator).Sin(double.Parse(txtCalcMainDisplay.Text));
                rtbHistory.Document.ContentStart.InsertTextInRun(sTemp + "\n");
            }
            if (sTemp == "cos")
            {
                (myCalculator as ScientificCalculator).Cos(double.Parse(txtCalcMainDisplay.Text));
                rtbHistory.Document.ContentStart.InsertTextInRun(sTemp + "\n");
            }
            if (sTemp == "tan")
            {
                (myCalculator as ScientificCalculator).Tan(double.Parse(txtCalcMainDisplay.Text));
                rtbHistory.Document.ContentStart.InsertTextInRun(sTemp + "\n");
            }
            if (sTemp == "cot")
            {
                (myCalculator as ScientificCalculator).Cot(double.Parse(txtCalcMainDisplay.Text));
                rtbHistory.Document.ContentStart.InsertTextInRun(sTemp + "\n");
            }
            if (sTemp == "+/-")
            {
                myCalculator.ChangeSign(double.Parse(txtCalcMainDisplay.Text));
                rtbHistory.Document.ContentStart.InsertTextInRun(sTemp + "\n");
            }
            myCalculator.StrMainDisplay = myCalculator.CurrResult.ToString();
            txtCalcMainDisplay.Text = myCalculator.CurrResult.ToString();
        }

        private void Btn_StdCalc_EqualOper_Click(object sender, RoutedEventArgs e)
        {
            if (myCalculator.LastOperation != CalcOperations.none)
            {
                myCalculator.DoPendingOperation();
                myCalculator.LastOperation = CalcOperations.none;
            }

        }
    }
}