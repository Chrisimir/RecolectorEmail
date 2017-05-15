using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RecolectorEmail
{
    [Serializable]
    public class HistoryData
    {
        private static DateTime lastUpdate;
        bool isLoaded = false;

        public DateTime GetLastUdpdateDate()
        {
            return !isLoaded ? new DateTime(2017, 4, 10) : lastUpdate;
        }
        public void SetLastUpdateDate(DateTime newDate)
        {
            string path = "lastUpdData.bin";
            lastUpdate = newDate;
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create,
                FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }
        public void LoadLastUpdate()
        {
            string path = "lastUpdData.bin";

            if (File.Exists(path))
            {
                isLoaded = true;
                IFormatter loader = new BinaryFormatter();
                Stream loaderStream = new FileStream(path, FileMode.Open,
                    FileAccess.Read, FileShare.Read);
                HistoryData historyData = new HistoryData();
                historyData = (HistoryData)loader.Deserialize(loaderStream);
                loaderStream.Close();
                lastUpdate = historyData.GetLastUdpdateDate();
            }
        }
    }
}
