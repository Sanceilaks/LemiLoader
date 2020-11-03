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
        HackList l = new HackList();

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
            Hacks.BaseHack hack = l.GetList()[this.hacksComboBox.SelectedIndex];

            if (hack == null)
            {
                MessageBox.Show("Error");
                return;
            }

            hack.Inject();

            //MainForm.GetInstance().SetStatusText("Ok");
        }

        public void SetStatusText(String text)
        {
            this.statusLabel.Text = text;
        }

        public void SetProgressBarValue(int v)
        {
            this.progressBar.Value = v;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           

            IHackInit hackInit = new HackInit();

            hackInit.init(l);

            foreach (var i in l.GetList())
            {
                this.hacksComboBox.Items.Add(i.Hack.name);
            }

            
        }

        /*        private void hacksComboBox_SelectedIndexChanged(object sender, EventArgs e)
                {
                    Console.WriteLine(this.hacksComboBox.SelectedIndex);
                }*/
    }
}
