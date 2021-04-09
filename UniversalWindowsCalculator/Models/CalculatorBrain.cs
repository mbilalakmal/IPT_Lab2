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

        public void PressedOperand(double operand)
        {
            if(_operator == null)
            {
                /// Update first operand
                if(_firstOperand == null) { _firstOperand = operand; }
                else { _firstOperand *= 10; _firstOperand += operand; }
            }
            else
            {
                /// Update second operand
                if (_secondOperand == null) { _secondOperand = operand; }
                else { _secondOperand *= 10; _secondOperand += operand; }
            }

            /// Both ScreenValue and Result maybe updated
            RaisePropertyChanged("ScreenValue");
            RaisePropertyChanged("Result");
        }

        public void PressedOperator(OperatorType @operator)
        {
            /// TODO: Handle +-*/ key press
        }

        public void PressedBackspace()
        {
            /// TODO: Handle backspace key press
            /// Remove from second if not null, remove operator if not null, remove first if not null
        }

        public void PressedEquals()
        {
            /// TODO: Handle equals key press
            /// If a result value exists, assign it to first operand and clear the result
        }


        public enum OperatorType { Add, Subtract, Multiply, Divide}

        /// <summary>
        /// Extension class to convert enums to display strings.
        /// </summary>
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

        /// <summary>
        /// Accepts two operands and an operator to calculte a double value.
        /// Returns infinity if divide-by-zero occurs.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="operator"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private double CalculateResult(double first, OperatorType @operator, double second)
        {
            switch (@operator)
            {
                case OperatorType.Add: return first + second;
                case OperatorType.Subtract: return first - second;
                case OperatorType.Multiply: return first * second;
                case OperatorType.Divide: return second == 0 ? first / second : double.PositiveInfinity;

                default: return 0;
            }
        }

        /// <summary>
        /// Calling this notifies any listener about the property changed.
        /// </summary>
        /// <param name="name"></param>
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
