using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class Logica
    {
        static object cantFilas;
        public static byte registrar(string nombre, string apellido, string gmail, string contra, string fecha)
        {
            Program.cm.Open("bd7sdco","root");
            Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "'", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Execute("insert into usuario values ('" + nombre + "','" + apellido + "','" + gmail + "',md5('" + contra + "'),'" + fecha + "',false)", out cantFilas);
                Program.cm.Close();
                return 0;
            }
            else
            {
                Program.cm.Close();
                return 1;
            }
        }
        public static byte iniciar(string gmail, string contra)
        {
            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND contra = md5('"+contra+"')", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Close();
                return 2;
            }
            else
            {
                Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND contra = md5('" + contra + "') AND suscrito = true", out cantFilas);
                Program.cm.Close();
                if (cantFilas.ToString().Equals("0"))
                {
                    return 1;
                }
                else return 0;
            }
        }

    }
}
