using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CycnyAPtakyWpf
{
    public partial class PotvrzeniWindow : Window
    {
        private readonly Random rng = new();
        private readonly MainWindow hlavniOkno;

        public PotvrzeniWindow(MainWindow rodic)
        {
            InitializeComponent();
            this.hlavniOkno = rodic;
        }

        // Tlačítko ANO utíká 100% nekompromisně
        private void BtnAno_MouseEnter(object sender, MouseEventArgs e)
        {
            double maxLeft = hlavniPlatno.ActualWidth - btnAno.ActualWidth;
            double maxTop = hlavniPlatno.ActualHeight - btnAno.ActualHeight;

            if (maxLeft <= 0 || maxTop <= 0) return;

            // Náhodný skok po ploše
            Canvas.SetLeft(btnAno, rng.NextDouble() * maxLeft);
            Canvas.SetTop(btnAno, rng.NextDouble() * maxTop);
        }

        // Když v druhém okně klikne na NE -> zavřeme ho a na hlavním okně spustíme smích!
        private void BtnNe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            hlavniOkno.SpustSmichVideo();
        }
    }
}