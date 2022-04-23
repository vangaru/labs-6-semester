using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Labs.MPP.Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const int LowerLimit = 1;
        private const int StepCalculationTimeout = 200;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method that is invoked when button PerformCalculationButton is clicked.
        /// </summary>
        /// <param name="sender">Object that invoked this method.</param>
        /// <param name="e">Object that contains addition information about event.</param>
        private void PerformCalculationButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (TryParseUpperLimit(UpperLimitTextBox.Text, out var upperLimit))
            {
                CalculationResult.Text = PerformCalculation(upperLimit).ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Checks whether string is a valid upper limit series and parses string to int.
        /// </summary>
        /// <param name="upperLimitString">Input string.</param>
        /// <param name="upperLimit">Out int upper limit.</param>
        /// <returns>
        /// Returns true of input string is a valid upper limit series.
        /// Otherwise returns false.
        /// </returns>
        private static bool TryParseUpperLimit(string upperLimitString, out int upperLimit)
        {
            upperLimit = 0;
            if (string.IsNullOrWhiteSpace(upperLimitString) || !int.TryParse(upperLimitString, out upperLimit))
            {
                return false;
            }

            return upperLimit > 0;
        }

        /// <summary>
        /// Calculates series.
        /// </summary>
        /// <param name="upperLimit">Upper limit of the series.</param>
        /// <returns>Result sum of the series.</returns>
        private static double PerformCalculation(int upperLimit)
        {
            var resultSum = 0d;
            for (var stepNumber = LowerLimit; stepNumber <= upperLimit; stepNumber++)
            {
                var currentStep = CalculateCurrentStep(stepNumber);
                resultSum += currentStep;
                Thread.Sleep(StepCalculationTimeout);
            }

            return resultSum;
        }

        /// <summary>
        /// Calculates current step of the series.
        /// </summary>
        /// <param name="stepNumber">Number of the step of the series.</param>
        /// <returns>Result sum of the series.</returns>
        private static double CalculateCurrentStep(int stepNumber)
        {
            return (2 * stepNumber - 1) / Math.Pow(2, stepNumber);
        }
    }
}