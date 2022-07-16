using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class Logica
    {
        static Random r = new Random();
        static object cantFilas;
        public static string registrar(string nombre, string apellido, string gmail, string contra, string fecha)
        {
            Program.cm.Open("bd7sdco","root");
            Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "'", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Execute("insert into usuario values ('" + nombre + "','" + apellido + "','" + gmail + "',md5('" + contra + "'),'" + fecha + "',false)", out cantFilas);
                Program.cm.Close();
                return "{numero : 0 }";
            }
            else
            {
                Program.cm.Close();
                return "{numero : 1 }";
            }
        }
        public static string iniciar(string gmail, string contra)
        {
            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND contra = md5('"+contra+"')", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Close();
                return "{numero : 2 }";
            }
            else
            {
                Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND contra = md5('" + contra + "') AND suscrito = true", out cantFilas);
                Program.cm.Close();
                if (cantFilas.ToString().Equals("0"))
                {
                    return "{numero : 1 }";
                }
                else return "{numero : 0 }";
            }
        }
        public static string randomBanner()
        {
            double num = Math.Ceiling(r.NextDouble() * 9);
            return "Imagenes\\Banner\\Banner"+num+".png";
        }
        public static string randomSplit()
        {
            double num = Math.Ceiling(r.NextDouble() * 8);
            return "Imagenes\\Split\\Split" + num + ".png";
        }

    }
}
