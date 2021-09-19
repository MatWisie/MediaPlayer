using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaPlayer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _window.DragMove();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_WindowMaximized(object sender, RoutedEventArgs e)
        {
            if (_window.WindowState != WindowState.Maximized)
                _window.WindowState = WindowState.Maximized;
            else
                _window.WindowState = WindowState.Normal;
        }

        private void Button_WindowMinimized(object sender, RoutedEventArgs e)
        {
            _window.WindowState = WindowState.Minimized;
        }

        static bool playing = false;
        private void PlayPauseButton(object sender, RoutedEventArgs e)
        {

            if (playing == false)
            {
                Media.Play();
                playing = true;
                PlayPauseImg.Source = new BitmapImage(new Uri(@"/Img/Play.png", UriKind.Relative));
                BeginStoryboard sb = this.FindResource("Fading") as BeginStoryboard;
                sb.Storyboard.Begin();
            }
            else
            {
                Media.Pause();
                playing = false;
                PlayPauseImg.Source = new BitmapImage(new Uri(@"/Img/Pause.png", UriKind.Relative));
                BeginStoryboard sb = this.FindResource("Fading") as BeginStoryboard;
                sb.Storyboard.Begin();
            }
        }
    }
}
