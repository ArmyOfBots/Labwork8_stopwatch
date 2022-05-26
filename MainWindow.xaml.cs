using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Threading;
using System.Diagnostics;

namespace Labwork8
{
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        string currentTime = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dt_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        void dt_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan ts = stopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                clocktxt.Content = currentTime;
            }
        }

        private void ButtonStartStopwatch(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
            dispatcherTimer.Start();
        }

        private void ButtonStopStopWatch(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                stopWatch.Stop();
            }
        }

        private void ButtonRestartStopwatch(object sender, RoutedEventArgs e)
        {
            stopWatch.Reset();
            clocktxt.Content = "00:00:00";
        }
    }
}