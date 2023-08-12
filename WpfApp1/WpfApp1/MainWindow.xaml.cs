using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFilePath = null;

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

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    currentFilePath = saveFileDialog.FileName;
                    System.IO.File.WriteAllText(currentFilePath, new TextRange(textArea.Document.ContentStart, textArea.Document.ContentEnd).Text);
                }
            }
            else
            {
                System.IO.File.WriteAllText(currentFilePath, new TextRange(textArea.Document.ContentStart, textArea.Document.ContentEnd).Text);
            }
        }

        private void OnOpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                currentFilePath = openFileDialog.FileName;
                textArea.Document.Blocks.Clear();
                textArea.Document.Blocks.Add(new Paragraph(new Run(System.IO.File.ReadAllText(currentFilePath))));
            }
        }

        private void ChangeTextColorToRed(object sender, RoutedEventArgs e)
        {
            ChangeSelectedTextColor(Brushes.Red);
        }

        private void ChangeTextColorToGreen(object sender, RoutedEventArgs e)
        {
            ChangeSelectedTextColor(Brushes.Green);
        }

        private void ChangeTextColorToBlue(object sender, RoutedEventArgs e)
        {
            ChangeSelectedTextColor(Brushes.Blue);
        }

        private void ChangeSelectedTextColor(Brush color)
        {
            if (textArea.Selection.Text.Length > 0)
            {
                textArea.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, color);
            }
        }
    }
}
