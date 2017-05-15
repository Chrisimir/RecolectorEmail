using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecolectorEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SortedList<string, string> newMails = new SortedList<string, string>();

            newMails = MainRE.GetNewEmails();
            
            foreach(var mail in newMails)
            {
                lstNewMails.Items.Add(mail.Key + "      " +
                    Filters.GetPhoneNumber(mail.Value));
            }
        }
    }
}
