using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        private string _currentInput = "0";
        private string _operator = "";
        private double _firstOperand = 0;
        private bool _isNewInput = true;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnNumberClick(object sender, RoutedEventArgs e)
        {
            var button = (System.Windows.Controls.Button)sender;
            string number = button.Content.ToString();

            if (_isNewInput || _currentInput == "0")
            {
                _currentInput = number;
            }
            else
            {
                _currentInput += number;
            }

            _isNewInput = false;
            UpdateResultBox();
        }
        private void OnOperatorClick(object sender, RoutedEventArgs e)
        {
            var button = (System.Windows.Controls.Button)sender;
            string op = button.Content.ToString();

            if (!_isNewInput)
            {
                _firstOperand = double.Parse(_currentInput);
                _currentInput = "0";
            }

            _operator = op;
            _isNewInput = true;
        }
        private void OnEqualsClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_operator))
            {
                double secondOperand = double.Parse(_currentInput);
                double result = 0;

                switch (_operator)
                {
                    case "+":
                        result = _firstOperand + secondOperand;
                        break;
                    case "-":
                        result = _firstOperand - secondOperand;
                        break;
                    case "*":
                        result = _firstOperand * secondOperand;
                        break;
                    case "/":
                        result = secondOperand != 0 ? _firstOperand / secondOperand : double.NaN;
                        break;
                }

                _currentInput = result.ToString();
                _operator = "";
                _isNewInput = true;
                UpdateResultBox();
            }
        }
        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            _currentInput = "0";
            _operator = "";
            _firstOperand = 0;
            _isNewInput = true;
            UpdateResultBox();
        }
        private void OnClearEntryClick(object sender, RoutedEventArgs e)
        {
            _currentInput = "0";
            _isNewInput = true;
            UpdateResultBox();
        }
        private void OnBackspaceClick(object sender, RoutedEventArgs e)
        {
            if (_currentInput.Length > 1)
            {
                _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
            }
            else
            {
                _currentInput = "0";
            }

            UpdateResultBox();
        }
        private void OnDecimalClick(object sender, RoutedEventArgs e)
        {
            if (!_currentInput.Contains("."))
            {
                _currentInput += ".";
                _isNewInput = false;
            }

            UpdateResultBox();
        }
        private void UpdateResultBox()
        {
            ResultBox.Text = _currentInput;
        }
    }
}
