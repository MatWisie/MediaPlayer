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
using System.Windows.Threading;

namespace MediaPlayer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer TimeOfMedia;
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += MouseStop;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Media.ScrubbingEnabled = true;
            Media.Stop();
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
                if (TimeOfMedia != null)
                    TimeOfMedia.Start();

                playing = true;
                PlayPauseImg.Source = new BitmapImage(new Uri(@"/Img/Play.png", UriKind.Relative));
                BeginStoryboard sb = this.FindResource("Fading") as BeginStoryboard;
                sb.Storyboard.Begin();
            }
            else
            {
                Media.Pause();
                if (TimeOfMedia != null)
                    TimeOfMedia.Stop();

                playing = false;
                PlayPauseImg.Source = new BitmapImage(new Uri(@"/Img/Pause.png", UriKind.Relative));
                BeginStoryboard sb = this.FindResource("Fading") as BeginStoryboard;
                sb.Storyboard.Begin();
            }
        }
        private void Media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.Message);
        }
        private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {

            totalTime.Maximum = Media.NaturalDuration.TimeSpan.TotalSeconds;
            TimeOfMedia = new DispatcherTimer();
            TimeOfMedia.Interval = TimeSpan.FromSeconds(1);
            TimeOfMedia.Tick += Czas_Tick;

            TimeOfMedia.Start();
            TimeOfMedia.Stop();
        }
        private void Czas_Tick(object sender, EventArgs e)
        {
            totalTime.Value = Media.Position.TotalSeconds;
        }
        private void totalTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Position = TimeSpan.FromSeconds(totalTime.Value);
        }
        private void totalTime_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            Media.Pause();
            if (TimeOfMedia != null)
            {
                TimeOfMedia.Stop();
            }
        }
        private void totalTime_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            Media.Play();
            TimeOfMedia.Start();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {

            timer.Stop();
            TimeSlider.Visibility = Visibility.Visible;
            VolumePanel.Visibility = Visibility.Visible;
            timer.Start();

        }
        private void MouseStop(object sender, EventArgs e)
        {
            TimeSlider.Visibility = Visibility.Hidden;
            VolumePanel.Visibility = Visibility.Hidden;
        }
    }
}
