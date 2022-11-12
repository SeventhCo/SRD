using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class apiPublicidad
    {
        public static string randomBanner()
        {
            return Logica.randomBanner();
        }
        public static string randomSplit()
        {
            return Logica.randomSplit();
        }
    }
}
