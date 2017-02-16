using System;
using WorkTime.DBL;

namespace WorkTime.BL
{
    public class WorkTimeWriter
    {
        public static void WriteTimeToXML(DateTime pStart, DateTime pEnd, string pRemark)
        {
            DBL.XMLWriter writer = new XMLWriter();
            writer.WriteXML(pStart, pEnd, pRemark);
        }
    }
}
