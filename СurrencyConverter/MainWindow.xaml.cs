using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace СurrencyConverter
{
    public partial class MainWindow : Window
    {
        string[] currency = { "Dollar", "Euro", "Zloty", "Pound", "Hryvnia" };
        string[] currencySymbol = { "$", "€", "zł", "£", "₴" };
        double[,] currencyCoefficients = new double[5, 5] { 
            { 1, 0.9862, 0.2065, 1.1299, 0.0272 },
            { 1.014, 1, 0.2094, 1.1459, 0.0275 },
            { 4.843, 4.7764, 1, 5.4743, 0.1319 }, 
            { 0.885, 0.8727, 0.1827, 1, 0.0242 },
            { 36.717, 36.4114, 7.5816, 41.3103, 1} };

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < currency.Length; i++)
            {
                from.Items.Add(currency[i]);
                to.Items.Add(currency[i]);
            }
            from.SelectedItem = (currency[0]);
            to.SelectedItem = (currency[1]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double initialAmount = double.Parse(amount_text_box.Text);
            for (int i = 0; i < currency.Length; i++)
            {
                for (int j = 0; j < currency.Length; j++)
                {
                    if (to.SelectedIndex == i && from.SelectedIndex == j)
                    {
                        double convertedAmount = initialAmount * currencyCoefficients[i, j];
                        converted_amount.Content = "Converted amount: " + convertedAmount.ToString() + currencySymbol[i];
                    }
                }
            }
        }
    }
}
