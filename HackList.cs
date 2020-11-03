using LemiLoader.Hacks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LemiLoader
{
    class HackList
    {
        private List<BaseHack> hacks = new List<BaseHack>() { };

        public List<BaseHack> GetList()
        {
            return hacks;
        }

        public void Add(BaseHack h)
        {
            hacks.Add(h);
        }
    }
}
