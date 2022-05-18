using System;
using System.Windows;

namespace PetrovLabWpf4v2
{
    public enum Distance
    {
        Inch,
        Foot,
        Mile,
        Verst
    }

    // Логика взаимодействия для MainWindow.xaml
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       
        // Обработчик событий для GroupBox "Доллары"
        private void ButtonDollars_Click(object sender, RoutedEventArgs e)
        {
			resDollars.Text = Converter.ConvertCurrency(rateDollars.Text, sumDollars.Text);
		}

        // Обработчик событий для GroupBox "Евро"
        private void ButtonEuros_Click(object sender, RoutedEventArgs e)
        {
            resEuros.Text = Converter.ConvertCurrency(rateEuros.Text, sumEuros.Text);
        }

        // Обработчик событий для GroupBox "Юани"
        private void ButtonYuans_Click(object sender, RoutedEventArgs e)
        {
            resYuans.Text = Converter.ConvertCurrency(rateYuans.Text, sumYuans.Text);
        }

        // Обработчик событий для GroupBox "Драхмы"
        private void ButtonDrachmas_Click(object sender, RoutedEventArgs e)
        {
            resDrachmas.Text = Converter.ConvertCurrency(rateDrachmas.Text, sumDrachmas.Text);
        }

        // Обработчик событий для GroupBox "Дюймы"
        private void ButtonInch_Click(object sender, RoutedEventArgs e)
        {
            resInch.Text = Converter.ConvertDistance(inch.Text, Distance.Inch);
        }

        // Обработчик событий для GroupBox "Футы"
        private void ButtonFoot_Click(object sender, RoutedEventArgs e)
        {
            resFoot.Text = Converter.ConvertDistance(inch.Text, Distance.Foot);
        }

        // Обработчик событий для GroupBox "Мили"
        private void ButtonMile_Click(object sender, RoutedEventArgs e)
        {
            resMile.Text = Converter.ConvertDistance(mile.Text, Distance.Mile);
        }

        // Обработчик событий для GroupBox "Версты"
        private void ButtonVerst_Click(object sender, RoutedEventArgs e)
        {
            resVerst.Text = Converter.ConvertDistance(verst.Text, Distance.Verst);
        }
    }

	public static class Converter
    {
        public static string ConvertCurrency(string rateStr, string sumStr)
        {
            try
            {
                if(string.IsNullOrEmpty(rateStr))
                    return "Введите поле курс";
                if(string.IsNullOrEmpty(sumStr))
                    return "Введите поле сумма";

                double rate = Convert.ToDouble(rateStr);
                double sum = Convert.ToDouble(sumStr);
                return (sum * rate).ToString("F2");
            }
            catch
            {
                return "Введены не правильные данные";
            }
        }

        public static string ConvertDistance(string rateStr, Distance distance)
        {
            try
            {
                if(string.IsNullOrEmpty(rateStr))
                    return "Заполните поле длина";

                double rate = Convert.ToDouble(rateStr);

                switch(distance)
                {
                    case Distance.Inch:
                        return (rate * 0.0254).ToString("F4");
                    case Distance.Foot:
                        return (rate * 0.3048).ToString("F4");
                    case Distance.Mile:
                        return (rate * 1609.34).ToString("F2");
                    case Distance.Verst:
                        return (rate * 1066.8).ToString("F2");
                    default:
                        return string.Empty;
                }
            }
            catch
            {
                return "Введены не правильные данные";
            }
        }
    }
}
