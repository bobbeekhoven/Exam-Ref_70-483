using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Random_Averages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private double computeAverages(long noOfValues)
        //{
        //    double total = 0;
        //    Random rand = new Random();

        //    for (long values = 0; values < noOfValues; values++)
        //    {
        //        total = total + rand.NextDouble();
        //    }

        //    return total / noOfValues;
        //}


        private Task<double> asyncComputeAverages(long noOfValues)
        {
            return Task<double>.Run(() =>
            {
                return asyncComputeAverages(noOfValues);
            });
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            long noOfValues = long.Parse(NumberOfValuesTextBox.Text);

            ResultTextBlock.Text = "Calculating";

            double result = await (asyncComputeAverages(noOfValues));

            ResultTextBlock.Text = "Result: " + result.ToString();
            //Task.Run(() =>
            //{
            //    double result = computeAverages(noOfValues);

            //    ResultTextBlock.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //    {
            //        ResultTextBlock.Text = "Result: " + result.ToString();
            //    });
            //});
            //long noOfValues = long.Parse(NumberOfValuesTextBox.Text);
            //ResultTextBlock.Text = "Result: " + computeAverages(noOfValues);
        }

        
    }
}
