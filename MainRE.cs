using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecolectorEmail
{
    static class MainRE
    {
        [STAThread]
        static void Main()
        {
            GUI.Start();

            HistoryData historyData = new HistoryData();
            historyData.LoadLastUpdate();
        }
        public static SortedList<string, string> GetNewEmails()
        {
            // Load program data
            Mail mail = new Mail();
            HistoryData historyData = new HistoryData();
            SortedList<string, string> newMails = new SortedList<string, string>();

            // Loads data about last update date
            DateTime lastUpdate = historyData.GetLastUdpdateDate();

            // Save the new "lastUpdate" date
            historyData.SetLastUpdateDate(DateTime.Now);

            newMails =
                excelClass.GetNotContainedMails(mail.GetMails(lastUpdate));

            return newMails;
        }
    }
}