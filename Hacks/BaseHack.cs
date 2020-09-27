using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemiLoader.Hacks
{
    enum HackList
    {
        LemiGMOD
    }

    class BaseHack
    {
        async public virtual void Inject() { }
    }
}
