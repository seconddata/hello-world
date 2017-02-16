using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Timers;
using Worktime.CrossCutting.Configuration;
using Timer = System.Threading.Timer;

namespace WorkTime.SL
{
    public class TimePresenter
    {

        private readonly ITime _view;
        private DateTime timeEnd;
        private DateTime timeStart;
        private int minutesLeft;

        private string timeLeft;
        private System.Timers.Timer aTimer;



        public TimePresenter(ITime pTime)
        {
            _view = pTime;

            InitLastStartTime();

            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Interval = 60000;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //do the necessary:
            InitLastStartTime();
            CalculateTime(false);
        }

        public DateTime TimeStart
        {
            get
            {
                return timeStart;
            }
            set
            {
                timeStart = value;
                _view.TimeStart = timeStart;
            }
        }
        public DateTime TimeEnd
        {
            get
            {
                return timeEnd;
            }
            set
            {
                timeEnd = value;
                _view.TimeEnd = timeEnd;
            }
        }

        private int MinutesLeft
        {
            get
            {
                return minutesLeft;
            }
            set
            {
                minutesLeft = value;
                _view.MinutesLeft = minutesLeft;
            }
        }

        private string TimeLeft
        {
            get
            {
                return timeLeft;
            }
            set
            {
                timeLeft = value;
                _view.HoursLeft = timeLeft;
            }
        }


        public DateTime getTime(int pHours, int pMin)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, pHours, pMin, 0);
        }


        public void SynchronizeValues()
        {
            _view.TimeStart = timeStart;
            _view.TimeEnd = timeEnd;
        }

        public void CalculateTime(bool save)
        {
            if (TimeStart == null | TimeEnd == null) return;

            TimeSpan ts1 = TimeEnd.Subtract(TimeStart);
            int totalMinLeftTemp =
                Convert.ToInt16(Convert.ToDouble(Math.Round(ts1.TotalMinutes, 0, MidpointRounding.AwayFromZero)) -
                                Configuration.PauseMinutes);

            if (ts1.TotalMinutes < 300)
            {
                totalMinLeftTemp = (int) (totalMinLeftTemp + Configuration.PauseMinutes);
            }



            
            int h = (int)Math.Floor(Convert.ToDouble(totalMinLeftTemp / 60));
            double minRest = totalMinLeftTemp % 60;

            double difference = totalMinLeftTemp - Configuration.ContractMinutes;

            MinutesLeft = totalMinLeftTemp;
            TimeLeft = string.Format("[{2}] {0}h {1}min", h, minRest, difference);

            _view.DifferenceIsNegative = difference < 0;


            if (save)
            {
                SaveTime(TimeStart, TimeEnd, TimeLeft);
                ReInitTimeList();
            }
        }

        public static DateTime? GetLastLogin(string domainName, string userName)
        {
            PrincipalContext c = new PrincipalContext(ContextType.Domain, domainName);
            UserPrincipal uc = UserPrincipal.FindByIdentity(c, userName);
            return uc.LastLogon;
        }

        private void SaveTime(DateTime pTimeStart, DateTime pTimeEnd, string pHoursLeft)
        {
            BL.WorkTimeWriter.WriteTimeToXML(pTimeStart, pTimeEnd, pHoursLeft);

        }

        public void InitLastStartTime()
        {
            Interface.IWorkDay lastBook = BL.WorkTimeReader.ReadTimeList().OrderByDescending(p => p.Id).FirstOrDefault();

            ReInitTimeList();

            if (lastBook == null) return;

            TimeStart = getTime(lastBook.StartDateTime.Hour, lastBook.StartDateTime.Minute);
            TimeEnd = getTime(DateTime.Now.Hour, DateTime.Now.Minute);
        }

        public void ReInitTimeList()
        {
            _view.WorkDayList = BL.WorkTimeReader.ReadTimeList();
        }



    }
}
