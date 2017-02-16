using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Worktime.CrossCutting.Configuration;
using WorkTime.CrossCutting.DTO;
using WorkTime.Interface;

namespace WorkTime.DBL
{
    public class XMLWriter
    {

        public void WriteXML(DateTime pStart, DateTime pEnd, string pRemark)
        {
            List<WorkDay> bookHistory = new List<WorkDay>();
            int lastId = 0;


            if (File.Exists(Configuration.Instance.XMLSerializationPath))
            {
                bookHistory = ReadXML();

                if (bookHistory != null & bookHistory.Count > 0)
                {
                    lastId = bookHistory.Max(c => c.Id);
                }
            }


            var overview = new WorkDay();
            overview.Id = lastId + 1;
            overview.StartDateTime = pStart;
            overview.EndDateTime = pEnd;
            overview.Remark = pRemark;

            bookHistory.Add(overview);

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<WorkDay>));

            FileStream file = null;

            file = File.Open(Configuration.Instance.XMLSerializationPath, FileMode.OpenOrCreate);


            writer.Serialize(file, bookHistory);
            file.Close();
        }

        public List<WorkDay> ReadXML()
        {
            var reader = new XMLReader();
            return reader.ReadXML();
        }
    }
}
