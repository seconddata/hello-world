

using System;

namespace Worktime.CrossCutting.Configuration
{
    public class Configuration : Singleton<Configuration>
    {
        public  string XMLSerializationPath  { get; set; }
        private const string serializationFileName = "SerializationTime.xml";
        public const double ContractMinutes = 7.8 * 60;
        public const double PauseMinutes = 30;
        //inherited from abstract singleton pattern.

        public Configuration()
        {
            XMLSerializationPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                                                            , serializationFileName);
        }




    }
}
