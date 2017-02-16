using System;
using System.Collections.Generic;
using WorkTime.Interface;

namespace WorkTime.SL
{
    public interface ITime
    {
        DateTime TimeStart { set; }
        DateTime TimeEnd { set; }

        int MinutesLeft { set; }
        string HoursLeft {  set; }
        bool DifferenceIsNegative { set; }
        List<IWorkDay> WorkDayList { set; }
    }
}
