using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class ApiAut
    {
        public static byte registrar(string nombre, string apellido, string gmail, string contra, string fecha)
        {
            return Logica.registrar(nombre,apellido,gmail,contra,fecha);
        }
        public static byte login(string gmail, string contra)
        {
            return Logica.iniciar(gmail, contra);
        }
        public static string validGmail(string entrada)
        {
            string salida = "";
            if (entrada.Contains('@'))
            {
                for (int i = 0; i < entrada.Length; i++)
                {
                    if (entrada[i] != '@')
                    {
                        salida = salida + entrada[i];
                    }
                    else break;
                }
            }
            else salida = entrada;
            return salida;
        }

    }
}
