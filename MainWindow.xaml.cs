using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace practicing_th8ngs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatchertimer = new DispatcherTimer();    //A timer that is integrated into the Dispatcher queue which is processed at a specified interval of time and at a specified priority.
        Stopwatch stopwatch = new Stopwatch();                      //Provides a set of methods and properties that you can use to accurately measure elapsed time.
        private string currentTime = string.Empty;                  //String to store duration
        public MainWindow()
        {
            InitializeComponent();
            dispatchertimer.Tick += new EventHandler(dispatchertimer_tick);
            dispatchertimer.Interval = new TimeSpan(0,0,0,0,1);
        }

        void dispatchertimer_tick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan ts = stopwatch.Elapsed;
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
