using MediaPlayer.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            

            MediaElement1.Play();
            MediaElement2.Play();
            MediaElement3.Play();
            MediaElement4.Play();
            MediaElement5.Play();
            MediaElement6.Play();

            if (Debugger.IsAttached)  //remove when want to test settings
            {
                Settings.Default.Reset();
            }

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _windowMenu.DragMove();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_WindowMaximized(object sender, RoutedEventArgs e)
        {
            if (_windowMenu.WindowState != WindowState.Maximized)
                _windowMenu.WindowState = WindowState.Maximized;
            else
                _windowMenu.WindowState = WindowState.Normal;
        }

        private void Button_WindowMinimized(object sender, RoutedEventArgs e)
        {
            _windowMenu.WindowState = WindowState.Minimized;
        }

        private void FileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog MediaSource = new OpenFileDialog();
            MediaSource.Filter = "Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV"; ;
            MediaSource.ShowDialog();
            


            if (!string.IsNullOrEmpty(MediaSource.FileName))
            {
                MainWindow mainwindow = new MainWindow();
                mainwindow.Show();
                mainwindow.Media.Source = new Uri(MediaSource.FileName);

                if (Convert.ToInt32(Settings.Default["Counter"]) == 0)
                {
                    Settings.Default["Media1"] = new Uri(MediaSource.FileName);
                    int counter = (int)Settings.Default["Counter"];
                    counter += 1;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }

                else if (Convert.ToInt32(Settings.Default["Counter"]) == 1)
                {
                    Settings.Default["Media2"] = new Uri(MediaSource.FileName);
                    int counter = (int)Settings.Default["Counter"];
                    counter += 1;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }
                else if (Convert.ToInt32(Settings.Default["Counter"]) == 2)
                {
                    Settings.Default["Media3"] = new Uri(MediaSource.FileName);
                    int counter = (int)Settings.Default["Counter"];
                    counter += 1;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }
                else if (Convert.ToInt32(Settings.Default["Counter"]) == 3)
                {
                    Settings.Default["Media4"] = new Uri(MediaSource.FileName);
                    int counter = (int)Settings.Default["Counter"];
                    counter += 1;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }
                else if (Convert.ToInt32(Settings.Default["Counter"]) == 4)
                {
                    Settings.Default["Media5"] = new Uri(MediaSource.FileName);
                    int counter = (int)Settings.Default["Counter"];
                    counter += 1;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }
                else if (Convert.ToInt32(Settings.Default["Counter"]) == 5)
                {
                    Settings.Default["Media6"] = new Uri(MediaSource.FileName);
                    int counter = (int)Settings.Default["Counter"];
                    counter = 0;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }
            }
        }

        private void LastMediaButton_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            mainwindow.Media.Source = (Uri)Settings.Default["LastMedia"];


        }

        private void MediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            MediaElement1.Pause();
            MediaElement2.Pause();
            MediaElement3.Pause();
            MediaElement4.Pause();
            MediaElement5.Pause();
            MediaElement6.Pause();
        }

        

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpwindow = new HelpWindow();

            DoubleAnimation WindowFadeAnim = new DoubleAnimation();
            WindowFadeAnim.From = 0;
            WindowFadeAnim.To = 1;
            WindowFadeAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            helpwindow.BeginAnimation(Window.OpacityProperty, WindowFadeAnim);

            helpwindow.ShowDialog();
            
        }
    }
}
