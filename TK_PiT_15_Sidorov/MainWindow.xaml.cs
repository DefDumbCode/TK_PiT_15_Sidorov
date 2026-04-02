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
            if (IsValidInput(RangeTB.Text, AmountTB.Text))
            {
                double range = Double.Parse(RangeTB.Text);
                int amount = int.Parse(AmountTB.Text);
                double res = CalculatePrice(range, amount, comf);
                PriceTB.Text = res.ToString() + "руб.";
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

        /// <summary>
        /// Определяет валидность введенных значений
        /// </summary>
        /// <param name="range_">Введенное расстояние</param>
        /// <param name="amount_">Введенное количество билетов</param>
        /// <returns>Булево значение, означающее валидность введенных параметров</returns>
        public bool IsValidInput(string range_, string amount_)
        {
            if (!String.IsNullOrEmpty(range_) && !String.IsNullOrEmpty(amount_))
            {
                double range;
                int amount;
                if (Double.TryParse(range_, out range) && int.TryParse(amount_, out amount))
                {
                    if (range > 0 && amount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Расстояние и количество билетов должны быть положительыми");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Введены неправильные значения");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введены пустые значения");
                return false;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            comf = rb.Content.ToString();
        }
    }
}
