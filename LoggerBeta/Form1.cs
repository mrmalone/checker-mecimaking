using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerBeta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            statechecker.ForeColor = System.Drawing.Color.Red;
            LogThis("Aplicatia a fost lansata!");
        }

        // apps

        static void LogThis(string logMessage)
        {
            Console.WriteLine(logMessage);
            using (StreamWriter writer = new StreamWriter("logger.txt", true))
            {
                writer.WriteLine("[ " + FileDate() + " ] " + logMessage);
                writer.WriteLine();
            }
        }

        static string FileDate()
        {
            return DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd") + " _ " + DateTime.Now.ToString("HH") + "-" + DateTime.Now.ToString("mm") + "-" + DateTime.Now.ToString("ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Esti de acord cu monitorizarea activitatilor tale pe tot parcursul meciului?";
            string title = "Warning!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.WindowState = FormWindowState.Minimized;
                statechecker.Text = "ON";
                statechecker.ForeColor = System.Drawing.Color.GreenYellow;
                launchbutton.Hide();
                LogThis("Anti-Cheat rulat cu succes!");
            }
            else
            {
                MessageBox.Show("Anti-Cheatul nu a fost pus in sarcina!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                string message = "Aplicatia se va inchide. Esti sigur?";
                message += "\n" + "Daca esti in continuare in meci sau pe un server securizat:";
                message += "\n" + "* Vei fi exclus in mod instant de pe server";
                message += "\n" + "* Vei primi o penalizare de 60 minute";
                string title = "Avertisment";
                DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    LogThis("Anti-Cheat a fost oprit de catre utilizator!");
                    Application.Exit();
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
