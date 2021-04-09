using UniversalWindowsCalculator.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalWindowsCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public CalculatorBrain calculatorBrain = new CalculatorBrain();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            /// TODO: Handle Equals Key Press
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number0: Dial0Button_Click(sender, e); break;
                case Windows.System.VirtualKey.Number1: Dial1Button_Click(sender, e); break;
                case Windows.System.VirtualKey.Number2: Dial2Button_Click(sender, e); break;
                case Windows.System.VirtualKey.Number3: Dial3Button_Click(sender, e); break;
                case Windows.System.VirtualKey.Number4: Dial4Button_Click(sender, e); break;
                case Windows.System.VirtualKey.Number5: Dial5Button_Click(sender, e); break;
                case Windows.System.VirtualKey.Number6: Dial6Button_Click(sender, e); break;
                case Windows.System.VirtualKey.Number7: Dial7Button_Click(sender, e); break;
                case Windows.System.VirtualKey.Number8: Dial8Button_Click(sender, e); break;
                case Windows.System.VirtualKey.Number9: Dial9Button_Click(sender, e); break;
                case Windows.System.VirtualKey.Add: AddButton_Click(sender, e); break;
                case Windows.System.VirtualKey.Subtract: SubtractButton_Click(sender, e); break;
                case Windows.System.VirtualKey.Multiply: MultiplyButton_Click(sender, e); break;
                case Windows.System.VirtualKey.Divide: DivideButton_Click(sender, e); break;
                case Windows.System.VirtualKey.Back: BackButton_Click(sender, e); break;
            }
        }

        private void EqualsButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedEquals();
        }

        private void BackButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedBackspace();
        }

        private void AddButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperator(CalculatorBrain.OperatorType.Add);
        }

        private void SubtractButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperator(CalculatorBrain.OperatorType.Subtract);
        }

        private void MultiplyButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperator(CalculatorBrain.OperatorType.Multiply);
        }

        private void DivideButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperator(CalculatorBrain.OperatorType.Divide);
        }

        private void Dial3Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperand(3);
        }

        private void Dial6Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperand(6);
        }

        private void Dial9Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperand(9);
        }

        private void Dial0Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperand(0);
        }

        private void Dial2Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperand(2);
        }

        private void Dial5Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperand(5);
        }

        private void Dial8Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperand(8);
        }

        private void Dial1Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperand(1);
        }

        private void Dial4Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperand(4);
        }

        private void Dial7Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calculatorBrain.PressedOperand(7);
        }
    }
}
