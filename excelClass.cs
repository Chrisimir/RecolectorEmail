using System.Collections.Generic;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;


namespace RecolectorEmail
{
    static class excelClass
    {
        private static string path = "clientes.xlsx";
        // TODO: Introduce método para encontrar el nombre de la ficha
        private static string sheetName = "Hoja1";

        public static void SetPath(string newPath)
        {
            path = newPath;
        }
        public static string GetPath()
        {
            return path;
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

            // Deletes the blacklisted mails
            keyNewMails = keyNewMails.Except(BlackListMails.blacklistedMails).ToList();

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
        public static void WriteNewMails(List<string> newMails)
        {
            FileStream leido = File.OpenRead(path);
            IWorkbook writeWB = new XSSFWorkbook(leido);
            leido.Close();
            ISheet page = writeWB.GetSheet("Hoja1");

            foreach (string mail in newMails)
            {
                // Insert name
                page.CreateRow(page.LastRowNum + 1).CreateCell(0).
                    SetCellValue(mail.Split('>')[0].Trim());

                // Insert mail
                page.GetRow(page.LastRowNum).CreateCell(1).
                    SetCellValue("mailto:" + mail.Split('>','(')[1].Trim());

                // Insert telephone number
                if (mail.Contains('('))
                {
                    page.GetRow(page.LastRowNum).CreateCell(2).SetCellValue(mail.Split('(', ')')[1]);
                }
            }

            FileStream modificado = File.Create(path);
            writeWB.Write(modificado);
            modificado.Close();
        }
    }
}
