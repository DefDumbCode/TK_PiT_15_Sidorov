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

namespace TK_PiT_15_Sidorov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string comf;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(RangeTB.Text) && !String.IsNullOrEmpty(AmountTB.Text))
            {
                double range;
                int amount;
                if (Double.TryParse(RangeTB.Text, out range) && int.TryParse(AmountTB.Text, out amount))
                {
                    if (range > 0 && amount > 0)
                    {
                        double res = CalculatePrice(range, amount, comf);
                        PriceTB.Text = res.ToString() + "руб.";
                    }
                    else
                    {
                        MessageBox.Show("Расстояние и количество билетов должны быть положительыми");
                    }
                }
                else
                {
                    MessageBox.Show("Введены неправильные значения");
                }
            }
            else
            {
                MessageBox.Show("Введены пустые значения");
            }
        }

        /// <summary>
        /// Вычисляет стоимость билетов
        /// </summary>
        /// <param name="range">Расстояние</param>
        /// <param name="amount">Количество билетов</param>
        /// <param name="comf">Уровень комфорта</param>
        /// <returns>Стоимость билетов</returns>
        public double CalculatePrice(double range, int amount, string comf)
        {
            double price = (range * 8) * amount;
            double mult;
            switch (comf) 
            {
                case "плацкарт":
                    mult = 1;
                    break;
                case "купе":
                    mult = 1.1;
                    break;
                case "полулюкс":
                    mult = 1.2;
                    break;
                case "люкс":
                    mult = 1.3;
                    break;
                default:
                    mult = 1;
                    break;
            }
            price *= mult;
            return price;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            comf = rb.Content.ToString();
        }
    }
}
