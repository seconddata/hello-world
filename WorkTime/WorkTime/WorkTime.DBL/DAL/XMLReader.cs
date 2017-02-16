using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Worktime.CrossCutting.Configuration;
using WorkTime.CrossCutting.DTO;
using WorkTime.Interface;

namespace WorkTime.DBL
{
    public class XMLReader
    {

        public List<WorkDay> ReadXML()
        {

            // Now we can read the serialized book ...
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(List<WorkDay>));


            if (!File.Exists(Configuration.Instance.XMLSerializationPath))
            {
                return new List<WorkDay>();
            }

            using (var file = new StreamReader(Configuration.Instance.XMLSerializationPath))
            {
                List<WorkDay> overview = (List<WorkDay>)reader.Deserialize(file);
                overview = overview.OrderByDescending(p => p.Id).ToList();
                return overview;
            }

        }
    }
}
