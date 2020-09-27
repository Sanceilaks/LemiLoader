using LemiLoader.Hacks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LemiLoader
{
    public partial class MainForm : Form
    {
        static private MainForm instance;

        static public MainForm GetInstance()
        {
            return instance;
        }

        public MainForm()
        {
            instance = this;
            InitializeComponent();
        }

        private void injectButton_Click(object sender, EventArgs e)
        {
            Hacks.BaseHack hack = null;
            switch (this.hacksComboBox.SelectedIndex)
            {
                case (int)HackList.LemiGMOD:
                    hack = new LemiGMOD();
                    break;
                default:
                    break;
            }

            if (hack == null)
            {
                MessageBox.Show("Error");
                return;
            }

            hack.Inject();
        }

        public void SetStatusText(String text)
        {
            this.statusLabel.Text = text;
        }

        public void SetProgressBarValue(int v)
        {
            this.progressBar.Value = v;
        }

        /*        private void hacksComboBox_SelectedIndexChanged(object sender, EventArgs e)
                {
                    Console.WriteLine(this.hacksComboBox.SelectedIndex);
                }*/
    }
}
