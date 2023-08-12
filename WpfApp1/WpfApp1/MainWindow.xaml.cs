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

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void OnTextAreaMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Defina o quanto você deseja aumentar/diminuir o tamanho da fonte a cada scroll
            double fontSizeChange = 1.0;

            if (e.Delta > 0) // Scroll para cima
            {
                textArea.FontSize += fontSizeChange;
            }
            else if (e.Delta < 0) // Scroll para baixo
            {
                textArea.FontSize = Math.Max(1, textArea.FontSize - fontSizeChange); // Garante que o tamanho da fonte não seja menor que 1
            }
        }

    }
}
