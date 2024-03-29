﻿using MediaPlayer.Properties;
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

            /*if (Debugger.IsAttached)  //remove when want to test settings
            {
                Settings.Default.Reset();
            }
            */

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

        //Opening filedialog and saving media to settings.
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
                    Settings.Default["FileName1"] = MediaSource.SafeFileName;
                    int counter = (int)Settings.Default["Counter"];
                    counter += 1;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }

                else if (Convert.ToInt32(Settings.Default["Counter"]) == 1)
                {
                    Settings.Default["Media2"] = new Uri(MediaSource.FileName);
                    Settings.Default["FileName2"] = MediaSource.SafeFileName;
                    int counter = (int)Settings.Default["Counter"];
                    counter += 1;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }
                else if (Convert.ToInt32(Settings.Default["Counter"]) == 2)
                {
                    Settings.Default["Media3"] = new Uri(MediaSource.FileName);
                    Settings.Default["FileName3"] = MediaSource.SafeFileName;
                    int counter = (int)Settings.Default["Counter"];
                    counter += 1;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }
                else if (Convert.ToInt32(Settings.Default["Counter"]) == 3)
                {
                    Settings.Default["Media4"] = new Uri(MediaSource.FileName);
                    Settings.Default["FileName4"] = MediaSource.SafeFileName;
                    int counter = (int)Settings.Default["Counter"];
                    counter += 1;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }
                else if (Convert.ToInt32(Settings.Default["Counter"]) == 4)
                {
                    Settings.Default["Media5"] = new Uri(MediaSource.FileName);
                    Settings.Default["FileName5"] = MediaSource.SafeFileName;
                    int counter = (int)Settings.Default["Counter"];
                    counter += 1;
                    Settings.Default["Counter"] = counter;
                    Settings.Default.Save();
                }
                else if (Convert.ToInt32(Settings.Default["Counter"]) == 5)
                {
                    Settings.Default["Media6"] = new Uri(MediaSource.FileName);
                    Settings.Default["FileName6"] = MediaSource.SafeFileName;
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

        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            
            (sender as MediaElement).Pause();
            //Revealing background for music media
            if ((sender as MediaElement).HasAudio == true && (sender as MediaElement).HasVideo == false) 
            {
                if (sender == MediaElement1)
                {
                    MusicBackground1.Visibility = Visibility.Visible;
                    MusicImage1.Visibility = Visibility.Visible;
                }
                else if (sender == MediaElement2)
                {
                    MusicBackground2.Visibility = Visibility.Visible;
                    MusicImage2.Visibility = Visibility.Visible;
                }
                else if (sender == MediaElement3)
                {
                    MusicBackground3.Visibility = Visibility.Visible;
                    MusicImage3.Visibility = Visibility.Visible;
                }
                else if (sender == MediaElement4)
                {
                    MusicBackground4.Visibility = Visibility.Visible;
                    MusicImage4.Visibility = Visibility.Visible;
                }
                else if (sender == MediaElement5)
                {
                    MusicBackground5.Visibility = Visibility.Visible;
                    MusicImage5.Visibility = Visibility.Visible;
                }
                else if (sender == MediaElement6)
                {
                    MusicBackground6.Visibility = Visibility.Visible;
                    MusicImage6.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (sender == MediaElement1)
                {
                    MusicBackground1.Visibility = Visibility.Hidden;
                    MusicImage1.Visibility = Visibility.Hidden;
                }
                else if (sender == MediaElement2)
                {
                    MusicBackground2.Visibility = Visibility.Hidden;
                    MusicImage2.Visibility = Visibility.Hidden;
                }
                else if (sender == MediaElement3)
                {
                    MusicBackground3.Visibility = Visibility.Hidden;
                    MusicImage3.Visibility = Visibility.Hidden;
                }
                else if (sender == MediaElement4)
                {
                    MusicBackground4.Visibility = Visibility.Hidden;
                    MusicImage4.Visibility = Visibility.Hidden;
                }
                else if (sender == MediaElement5)
                {
                    MusicBackground5.Visibility = Visibility.Hidden;
                    MusicImage5.Visibility = Visibility.Hidden;
                }
                else if (sender == MediaElement6)
                {
                    MusicBackground6.Visibility = Visibility.Hidden;
                    MusicImage6.Visibility = Visibility.Hidden;
                }
            }

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

        private void MediaelementGallery_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            mainwindow.Media.Source = (sender as MediaElement).Source;
        }

        private void MusicBackground_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            mainwindow.Media.Source = (Uri)(sender as Rectangle).DataContext;
        }
    }
}
