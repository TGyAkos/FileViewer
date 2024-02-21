using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FileViewer
{
    /// <summary>
    /// Interaction logic for TextBox.xaml
    /// </summary>
    public partial class TextBox : Window
    {
        MainWindow MainW;
        public TextBox(MainWindow mainW, string file)
        {
            InitializeComponent();
            MainW = mainW;
            txtBox.Text = File.ReadAllText(file);
        }

        private void TextWindow_Closed(object sender, EventArgs e)
        {
            MainW.Show();
        }
        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
            saveFileDialog.ShowDialog();

            string name = saveFileDialog.FileName;

            File.WriteAllText(name, txtBox.Text);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBox.Text.Length > 0) { save.IsEnabled = true; }
            else { save.IsEnabled = false; }
        }
    }
}
