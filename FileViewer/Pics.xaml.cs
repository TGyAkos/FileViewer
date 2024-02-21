using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FileViewer
{
    /// <summary>
    /// Interaction logic for Pics.xaml
    /// </summary>
    public partial class Pics : Window
    {
        MainWindow MainW;
        public Pics(MainWindow Main, string file)
        {
            InitializeComponent();
            MainW = Main;
            Img.Source = new BitmapImage(new Uri(file));
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainW.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png";
            saveFileDialog.ShowDialog();

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)Img.Source));
            using FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create);
            encoder.Save(stream);
        }
    }
}
