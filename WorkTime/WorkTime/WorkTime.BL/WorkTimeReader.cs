using System.Collections.Generic;
using WorkTime.Interface;

namespace WorkTime.BL
{
    public class WorkTimeReader
    {

        public static List<IWorkDay>  ReadTimeList()
        {
            DBL.XMLReader reader = new DBL.XMLReader();
            return new List<IWorkDay>(reader.ReadXML());
        }
    }
}
