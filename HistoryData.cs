using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace RecolectorEmail
{
    [Serializable]
    public struct LastUpdate
    {
        public static DateTime lastUpdate = new DateTime(2017, 4, 4);
    }
    [Serializable]
    public class BlackListMails
    {
        public static List<string> blacklistedMails = new List<string>();
    }

    public static class HistoryData
    {
        // Date update functions
        public static void SetLastUpdateDate(DateTime newDate)
        {
            string path = "lastUpdData.bin";
            LastUpdate.lastUpdate = newDate;
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create,
                FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, LastUpdate.lastUpdate);
            stream.Close();
        }
        public static void LoadLastUpdate()
        {
            string path = "lastUpdData.bin";

            if (File.Exists(path))
            {
                IFormatter loader = new BinaryFormatter();
                Stream loaderStream = new FileStream(path, FileMode.Open,
                    FileAccess.Read, FileShare.Read);

                LastUpdate.lastUpdate = (DateTime)loader.Deserialize(loaderStream);
                loaderStream.Close();
            }
        }

        // Blacklist update functions
        public static void AddToBlackList(string newDescartedMail)
        {
            string path = "blacklist.bin";
            BlackListMails.blacklistedMails.Add(newDescartedMail);
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Create,
                    FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, BlackListMails.blacklistedMails);
                stream.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void LoadBlacklist()
        {
            string path = "blacklist.bin";

            if (File.Exists(path))
            {
                try
                {
                    IFormatter loader = new BinaryFormatter();
                    Stream loaderStream = new FileStream(path, FileMode.Open,
                        FileAccess.Read, FileShare.Read);

                    BlackListMails.blacklistedMails = (List<string>)loader.Deserialize(loaderStream);
                    loaderStream.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
