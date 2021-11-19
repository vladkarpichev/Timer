using System;
using System.Windows;
using System.Threading;
using System.IO;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool i = false;
        private void b3(object sender, RoutedEventArgs e)
        {
            Log("Продолжить", DateTime.Now.ToString("mm.ss"));
            i = true;
            if (text3.Text == "0")
            {
                text4.Text = DateTime.Now.ToString("mm.ss");
            }
            else
            {
                text4.Text = text3.Text;
                text3.Text = "0";
            }
        }
        private void b2(object sender, RoutedEventArgs e)
        {
            Log("Пауза", DateTime.Now.ToString("mm.ss"));
            if (i == true) text3.Text = DateTime.Now.ToString("mm.ss");
        }
        private void b1(object sender, RoutedEventArgs e)
        {
            Log("Стоп", "");
            text3.Text = "0";
            text4.Text = "0";
            i = false;
        }
        private void Log(string text, string text1)
        {
            DateTime Time = DateTime.Now;
            using (FileStream fstream = new FileStream($"Logi.txt", FileMode.Append))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes($"{Time}: {text}: {text1}\n");
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
