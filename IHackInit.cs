using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LemiLoader.Hacks;
using Newtonsoft.Json;

namespace LemiLoader
{
    interface IHackInit
    {
        void init(HackList list);

    }

    class HackInit : IHackInit
    {
        private const string url = @"https://raw.githubusercontent.com/Sanceilaks/GmodHackBySl/master/meta.json";
        private HackList list;
        
        void IHackInit.init(HackList list)
        {
            this.list = list;

            string meta;

            var webRequest = WebRequest.Create(url);


            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                meta = reader.ReadToEnd();
            }

            Console.WriteLine(meta);

            if (meta.Length <= 0)
            {
                MessageBox.Show("Server meta error");
                Environment.Exit(0);
            }

            var jsonHacks = JsonConvert.DeserializeObject<List<Hack>>(meta);

            int index = 0;

            foreach (var i in jsonHacks)
            {
                BaseHack h = new BaseHack();
                h.index = index;
                h.Hack = i;

                list.Add(h);
                index++;
            }
        }
    }
}
