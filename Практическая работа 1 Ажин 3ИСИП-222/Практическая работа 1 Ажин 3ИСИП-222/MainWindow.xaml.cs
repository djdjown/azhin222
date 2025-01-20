using System;
using System.ComponentModel;
using System.Windows;

namespace MathFunctionsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
         
            if (string.IsNullOrWhiteSpace(xValueTextBox.Text) ||
                string.IsNullOrWhiteSpace(qValueTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля для x и q.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double x, q;
     
            if (!double.TryParse(xValueTextBox.Text, out x) ||
                !double.TryParse(qValueTextBox.Text, out q))
            {
                MessageBox.Show("Введите корректные числовые значения для x и q.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double f_x = 0;

            
            if (shRadioButton.IsChecked == true)
            {
                f_x = Math.Sinh(x);
            }
            else if (x2RadioButton.IsChecked == true)
            {
                f_x = x * x;
            }
            else if (eRadioButton.IsChecked == true)
            {
                f_x = Math.Exp(x);
            }

         
            double k;
            double xq = Math.Abs(x * q);
            if (xq > 10)
            {
                k = Math.Log(Math.Abs(f_x) + Math.Abs(q));
            }
            else if (xq < 10)
            {
                k = Math.Exp(f_x + q);
            }
            else
            {
                k = f_x + q;
            }

          
            ResultTextBox.Text = k.ToString();
        }

        
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            xValueTextBox.Clear();
            qValueTextBox.Clear();
            ResultTextBox.Clear();
        }

       
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; 
            }
        }
    }
}
