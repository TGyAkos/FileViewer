using Microsoft.Win32;
using System.Windows;

namespace FileViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_FIle_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.ShowDialog();

            var a = System.IO.Path.GetExtension(openFileDialog.FileName);
            if (a is (".jpg" or ".png" or ".webp"))
            {
                this.Hide();
                var PicsWindow = new Pics(this, openFileDialog.FileName);
                PicsWindow.Show();
            }
            else if (a is (".txt" or ".csv" or ".md"))
            {
                var TextWindow = new TextBox(this, openFileDialog.FileName);
                TextWindow.Show();
                this.Hide();
            }
        }
    }
}
