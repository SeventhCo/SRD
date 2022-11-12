using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class apiAutenticacion
    {

        public static byte registrar(string gmail, string dominio, string contra, int rol, string nacimiento, string nombre, string apellido)
        {
            return Logica.registrar(gmail, dominio, contra, rol, nacimiento, nombre, apellido);
        }
        public static byte iniciar(string gmail, string dominio, string contra)
        {
            return Logica.iniciar(gmail, dominio, contra);
        }

        public static void openAsPaidUser()
        {
            Logica.openAsPaidUser();
        }

        public static void openAsUser()
        {
            Logica.openAsUser();
        }

        public static void close()
        {
            Logica.close();
        }
    }
}
