using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class apiResultados
    {
        public static string consulta(string comando)
        {
            return JsonConvert.SerializeObject(Logica.consulta(comando));
        }
        public static string comando(string comand)
        {
            return JsonConvert.SerializeObject(Logica.comando(comand));
        }
        public static int consultaMaxIndex(string comando)
        {
            return Logica.consultaMaxIndex(comando);
        }
    }
}
