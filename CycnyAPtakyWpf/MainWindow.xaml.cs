using System.IO;
using System.Windows;

namespace CycnyAPtakyWpf
{
    public partial class MainWindow : Window
    {
        // 1. Při načtení okna (nebo při výběru pohlaví) video přednačteme do paměti
        public MainWindow()
        {
            InitializeComponent();
            PrednactiVideo();
        }
        
        private void PrednactiVideo()
        {
            string cestaKVideu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "smich.mp4");
            
            if (File.Exists(cestaKVideu))
            {
                mediaPlayer.Source = new Uri(cestaKVideu);
                
                // Trik: Zapneme přehrávání a OKAMŽITĚ ho pozastavíme na nulté sekundě.
                // Tím donutíme WPF, aby video dekódovalo a drželo připravené v RAM.
                mediaPlayer.Play();
                mediaPlayer.Pause();
                mediaPlayer.Position = TimeSpan.Zero;
            }
        }
        
        // Uživatel přiznal barvu -> Spustíme video se smíchem
        // 2. Samotné spuštění je teď bleskové!
        public void SpustSmichVideo()
        {
            if (mediaPlayer.Source != null)
            {
                mediaPlayer.Position = TimeSpan.Zero; // Pro jistotu skočíme na začátek
                mediaPlayer.Play();                   // Spustí se OKAMŽITĚ bez čekání
            }
            else
            {
                MessageBox.Show("HA HA HA HA! (Video smich.mp4 nenalezeno)", "Smích");
            }
        }

        private void BtnMuz_Click(object sender, RoutedEventArgs e)
        {
            txtDotaz.Text = "Máš malého ptáka?";
            panelDotaz.Visibility = Visibility.Visible;
        }

        private void BtnZena_Click(object sender, RoutedEventArgs e)
        {
            txtDotaz.Text = "Máš malé cycny?";
            panelDotaz.Visibility = Visibility.Visible;
        }
                
        private void BtnAno_Click(object sender, RoutedEventArgs e)
        {
            SpustSmichVideo();
        }

        // Uživatel zatlouká -> Otevřeme druhé okno s pastí
        private void BtnNe_Click(object sender, RoutedEventArgs e)
        {
            PotvrzeniWindow druheOkno = new(this);
            druheOkno.ShowDialog(); // Otevře okno jako modální dialog
        }
    }
}