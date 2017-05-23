using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecolectorEmail
{
    public struct TimeInterval
    {
        public static DateTime start;
        public static DateTime end;
    }

    public partial class Form1 : Form
    {
        private readonly SynchronizationContext synchronizationContext;
        bool fileChosen;
        Mail mail;
        TextInfo myTI;

        public Form1()
        {
            InitializeComponent();
            synchronizationContext = SynchronizationContext.Current;
            fileChosen = false;
            mail = new Mail();
            myTI = new CultureInfo("en-US", false).TextInfo;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (fileChosen)
            {
                if (!File.Exists(excelClass.GetPath()))
                {
                    MessageBox.Show("Excel seleccionado no es válido");
                }
                else
                {
                    button1.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    bool dataCorrect = true;

                    if (chkbUseInterval.Checked)
                    {
                        if (DateTime.Compare(dtpFrom.Value, dtpTo.Value) >= 0)
                        {
                            MessageBox.Show("Las fechas son incorrectas");
                            dataCorrect = false;
                        }
                        else
                        {
                            TimeInterval.start = dtpFrom.Value;
                            TimeInterval.end = dtpTo.Value;
                        }
                    }

                    if (dataCorrect)
                    {
                        await Task.Run(() => { UpdateList(); });
                    }

                    Cursor = Cursors.Arrow;
                    button1.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
            else
                MessageBox.Show("Tienes que seleccionar un Excel");
        }

        public void UpdateList()
        {
            lstNewMails.Items.Clear();
            SortedList<string, string> newMails = new SortedList<string, string>();

            newMails = mail.GetMails(TimeInterval.start, TimeInterval.end);
            if (!chkbUseInterval.Checked)
            {
                lblUltimaActualizacion.Text = LastUpdate.lastUpdate.ToString("dd/MM/yyyy");
                this.Refresh();
            }

            foreach (var mail in newMails)
            {
                try
                {
                    string name = myTI.ToTitleCase(mail.Key.Split('<', '>')[0].Trim().Replace("\"", ""));
                    string emailAdress = mail.Key.Split('<', '>')[1];
                    string phoneNum = Filters.GetPhoneNumber(mail.Value);
                    lstNewMails.Items.Add(name
                                         + " > "
                                         + emailAdress
                                         + (phoneNum != "" ? " (" + phoneNum + ")" : ""));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ha ocurrido un error: " + e);
                }
            }
            if (lstNewMails.Items.Count == 0)
            {
                MessageBox.Show("No hay correos nuevos");
            }
        }

        public void SendToExcel(object sender, EventArgs e)
        {
            var newMails = lstNewMails.Items.Cast<string>().ToList();
            new Task(() => { excelClass.WriteNewMails(newMails); }).Start();
            MessageBox.Show("Añadido exitosamente");
            lstNewMails.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUltimaActualizacion.Text = LastUpdate.lastUpdate.ToString("dd/MM/yyyy");
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogExcel.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = FileDialogExcel.FileName;
                lblPath.Text = file.Split('\\')[file.Split('\\').Length - 1];
                excelClass.SetPath(file);
                fileChosen = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstNewMails.SelectedIndex != -1)
            {
                // Adds this mail to blacklist
                HistoryData.AddToBlackList(
                    lstNewMails.Items[lstNewMails.SelectedIndex].ToString().Split('(')[0].Trim());

                lstNewMails.Items.RemoveAt(lstNewMails.SelectedIndex);
            }
            if (lstNewMails.Items.Count == 0)
            {
                btnEliminar.Enabled = false;
            }
        }

        private void lstNewMails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                btnEliminar_Click(sender, e);
            }
        }

        private void chkbUseInterval_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbUseInterval.Checked)
            {
                panelInterval.Visible = true;
            }
            else
            {
                panelInterval.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = dtpFrom.Value.AddMonths(1);
            dtpTo.Value = dtpTo.Value.AddMonths(1);
        }
    }
}
