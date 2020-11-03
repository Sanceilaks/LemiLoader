using LemiLoader.Hacks.Inject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LemiLoader.Hacks
{
    class BaseHack
    {

        public Hack Hack;
        public int index;
        private bool complated = false;
        private int progress = 0;

        async public void Inject() 
        {
            complated = false;
            MainForm.GetInstance().SetStatusText("Download dll");

            WebClient webClient = new WebClient();

            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClient_DownloadDataCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LemiLoader\\";
            System.IO.Directory.CreateDirectory(path);
            path += $"{Hack.name}.dll";

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            webClient.DownloadFileAsync(new Uri(Hack.url), path);

            while (!complated)
            {
                await Task.Delay(10);
            }

            MainForm.GetInstance().SetStatusText("Wait hl2.exe");

            Process[] p = Process.GetProcessesByName("hl2");

            while (p.Length == 0 || p.GetValue(0) == null)
            {
                p = Process.GetProcessesByName("hl2");
                await Task.Delay(10);
            }

            MainForm.GetInstance().SetStatusText("Inject");

            await Task.Delay(10);

            LoadLibrary loadLibrary = new LoadLibrary();

            loadLibrary.Inject(path, p[0].Id);

            //return true;
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progress = e.ProgressPercentage;
            MainForm.GetInstance().SetProgressBarValue(progress);
        }

        private void WebClient_DownloadDataCompleted(object sender, AsyncCompletedEventArgs e)
        {
            complated = true;
        }
    }

    class Hack
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
