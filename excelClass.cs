using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace RecolectorEmail
{
    static class excelClass
    {
        private static string path = "test.xlsx";
        private static string sheetName = "Hoja1";

        public static void SetPath(string newPath)
        {
            path = newPath;
        }

        // Gets the list of emails the excel has
        public static List<string> GetExcelMails()
        {
            List<string> actualMails = new List<string>();
            if (File.Exists(path))
            {
                FileStream contactosFile = File.OpenRead(path);
                IWorkbook readWB = new XSSFWorkbook(contactosFile);
                contactosFile.Close();
                ISheet sheet = readWB.GetSheet(sheetName);

                int row = 1;
                while (sheet.GetRow(row) != null)
                {
                    actualMails.Add(sheet.GetRow(row).GetCell(1).StringCellValue.Trim().ToLower());
                    row++;
                }
            }
            return actualMails;
        }

        // Gets the value pair that is not contained in the excel
        public static SortedList<string,string> GetNotContainedMails
            (SortedList<string,string> toChekMails)
        {
            List<string> keyNewMails = new List<string>();
            SortedList<string, string> newMails = new SortedList<string, string>();
            List<string> currentSaved = GetExcelMails();

            // Compares the inbox mails with the excel mails
            keyNewMails = toChekMails.Keys.Except(currentSaved).ToList();

            foreach (var email in toChekMails)
            {
                foreach (var mail in keyNewMails)
                {
                    if (email.Key == mail)
                    {
                        newMails.Add(email.Key, email.Value);
                    }
                }
            }


            return newMails;
        }

        // Writes mails to the excel

    }
}
