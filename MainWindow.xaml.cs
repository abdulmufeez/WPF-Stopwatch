using System;
using System.Diagnostics;                           //For Stopwatch class
using System.Windows;
using System.Windows.Threading;                     //For timedispatcher class

namespace practicing_th8ngs
{                                                                  
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatchertimer = new DispatcherTimer();    //A timer that is integrated into the Dispatcher queue which is processed at a specified interval of time and at a specified priority.
        Stopwatch stopwatch = new Stopwatch();                      //Provides a set of methods and properties that you can use to accurately measure elapsed time.
        private string currentTime = string.Empty;                  //String to store duration
        public MainWindow()
        {
            InitializeComponent();
            dispatchertimer.Tick += new EventHandler(dispatchertimer_tick);               //this a dispatcher event include init for further info goto doc                            
            dispatchertimer.Interval = new TimeSpan(0,0,0,0,1);                           //interval for stopwatch means loop for time
        }

        void dispatchertimer_tick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan ts = stopwatch.Elapsed;                    //calculated time (elapsed)
                currentTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds/10);
                ResultScreen.Text = currentTime;
            }
        }
        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                InfoScreen.Text = "Stopwatch Start";
                stopwatch.Start();                  
                dispatchertimer.Start();
            }
            else
                MessageBox.Show("StopWatch is ruuning already");
        }
        private void Button_Click_Stop(object sender, RoutedEventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                InfoScreen.Text = "Stopwatch Stop";
                stopwatch.Stop();
            }
            else
                MessageBox.Show("You need to start stopwatch first!");

        }
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            InfoScreen.Text = "Stopwatch Reset";
            stopwatch.Reset();
            ResultScreen.Text = "00:00:00.00";
        }

    }
}
