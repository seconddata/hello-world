using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WorkTime.Interface;
using WorkTime.SL;
using Xceed.Wpf.DataGrid.Views;
using Image = System.Windows.Controls.Image;

namespace WorkTime.UIWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ITime
    {

        TimePresenter _presenter;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            _presenter = new TimePresenter(this);
            _presenter.SynchronizeValues();

            image.Visibility = Visibility.Hidden;
        }

        public int MinutesLeft
        {
            set
            {
                // textBoxTimeLeft.Text = value.ToString();
            }
        }


        public string HoursLeft
        {
            set
            {
                Dispatcher.Invoke(() =>
                {
                    textBoxTimeLeftHours.Text = value;
                    Title = value;
                });
            }
        }

        public DateTime TimeEnd
        {
            set
            {
                Dispatcher.Invoke(() => { textBoxEnd.Text = value.ToShortTimeString(); });
            }
        }

        public DateTime TimeStart
        {
            set
            {
                Dispatcher.Invoke(() => { textBoxStart.Text = value.ToShortTimeString(); });
            }
        }


        public bool DifferenceIsNegative
        {
            set
            {
                if (value)
                {
                    Dispatcher.Invoke(() => { image.Visibility = Visibility.Hidden; });

                }
                else
                {
                    Dispatcher.Invoke(() => { image.Visibility = Visibility.Visible; });
                }
            }
        }

        public List<IWorkDay> WorkDayList
        {
            set
            {
                Dispatcher.BeginInvoke(
                                           new Action(() =>
                                           {
                                               DataGrid1.ItemsSource = value;
                                               DataGrid1.Columns["Id"].Width = 50;
                                           })
                                        );
            }
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTimeValues();

                _presenter.CalculateTime(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetTimeValues()
        {
            //sync presenters variable values.
            _presenter.TimeStart = getCurrentDayTime(textBoxStart.Text);
            _presenter.TimeEnd = getCurrentDayTime(textBoxEnd.Text);
        }


        /// <summary>
        /// Converts the Time String like 07:30 to a current day datetime value.
        /// </summary>
        /// <param name="pTimeValue"></param>
        /// <returns></returns>
        private DateTime getCurrentDayTime(string pTimeValue)
        {
            try
            {
                var timeArray = pTimeValue.Split(":".ToCharArray());
                var hour = Convert.ToInt16(timeArray[0]);
                var min = Convert.ToInt16(timeArray[1]);

                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, min, 0);
            }
            catch (Exception)
            {
                throw new Exception("Zeitangabe ist falsch: " + pTimeValue);
            }

        }

        private void buttonSaveTimes_Click(object sender, RoutedEventArgs e)
        {
            SetTimeValues();
            _presenter.CalculateTime(true);
        }


        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {
                //Skip
            }
        }


        private DoubleAnimation myRotateAnm { get; set; }

        private void Image_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (myRotateAnm == null)
            {
                myRotateAnm = new DoubleAnimation(0, 360, new Duration(new TimeSpan(0, 0, 1)))
                {
                    RepeatBehavior = RepeatBehavior.Forever,
                    SpeedRatio = 0.2
                };
            }
            myRotateTransform.BeginAnimation(RotateTransform.AngleProperty, myRotateAnm);
        }

        private void Image_OnMouseLeave(object sender, MouseEventArgs e)
        {
            myRotateTransform.BeginAnimation(RotateTransform.AngleProperty, null);
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }


        private void UIElement_OnMouseLeftButtonUpMin(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
