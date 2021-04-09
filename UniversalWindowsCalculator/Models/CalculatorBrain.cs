using System.ComponentModel;

namespace UniversalWindowsCalculator.Models
{
    public class CalculatorBrain : INotifyPropertyChanged
    {
        private double? _firstOperand;
        private double? _secondOperand;

        private OperatorType? _operator;

        /// <summary>
        /// This is shown as the user enters more characters.
        /// </summary>
        public string ScreenValue
        {
            get
            {
                string resultString = string.Empty;
                if (_firstOperand != null) resultString += _firstOperand.ToString();
                if (_operator != null) resultString += OperatorTypeExtension.OperatorToString(_operator);
                if (_secondOperand != null) resultString += _secondOperand.ToString();

                return resultString;
            }
        }

        /// <summary>
        /// This is shown when two operands and an operator is present.
        /// </summary>
        public string Result
        {
            get
            {
                string resultString = string.Empty;
                if(_firstOperand != null && _operator != null && _secondOperand != null)
                {
                    /// TODO: Implement four operations
                    resultString = 0.ToString();
                }

                return resultString;
            }
        }


        public enum OperatorType { Add, Subtract, Multiply, Divide}

        static class OperatorTypeExtension
        {
            public static string OperatorToString(OperatorType? @operator)
            {
                switch (@operator)
                {
                    case OperatorType.Add: return "+";
                    case OperatorType.Subtract: return "+";
                    case OperatorType.Multiply: return "+";
                    case OperatorType.Divide: return "+";
                    default: return "";
                }
            }
        }

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
