using Microsoft.Win32;
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

namespace VideoPlayer
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

        private void B_Play_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.LoadedBehavior = MediaState.Play;
        }

        private void B_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) myMediaElement.Source = new Uri(openFileDialog.FileName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.LoadedBehavior = MediaState.Stop;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myMediaElement.LoadedBehavior = MediaState.Pause;
        } 

        private void Slider_LostMouseCapture(object sender, MouseEventArgs e)
        {
            TimeSpan time = new TimeSpan(0, 0, Convert.ToInt32(Math.Round(slider1.Value))); 
            myMediaElement.Position = time;
        }

        private void myMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            slider1.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
        }
    }
}
