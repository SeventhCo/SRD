﻿using System;
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
        public static byte registrar(string nombre, string apellido, string gmail, string contra, string fecha, int rol)
        {
            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "'", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Execute("insert into usuario values ('" + gmail + "',md5('" + contra + "')," + rol + ")", out cantFilas);
                //Program.cm.Execute("insert into persona values ('" + nombre + "','" + apellido + "','" + fecha + "')", out cantFilas);
                //Program.cm.Execute("insert into personaUsuario values ('" + nombre + "','" + apellido + "','" + gmail + ")", out cantFilas);
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
            Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND contra = md5('" + contra + "')", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Close();
                return 2;
            }
            else
            {
                Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND contra = md5('" + contra + "') AND rol > 0", out cantFilas);
                Program.cm.Close();
                if (cantFilas.ToString().Equals("0"))
                {
                    return 1;
                }
                else return 0;
            }
        }
        public static byte iniciarAdmin(string gmail, string contra)
        {
            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND contra = md5('" + contra + "')", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Close();
                return 2;
            }
            else
            {
                Program.cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND contra = md5('" + contra + "') AND rol = 2", out cantFilas);
                Program.cm.Close();
                if (cantFilas.ToString().Equals("0"))
                {
                    return 1;
                }
                else return 0;
            }
        }
        public static string randomBanner()
        {
            double num = Math.Ceiling(r.NextDouble() * 9);
            return "Imagenes\\Banner\\Banner" + num + ".png";
        }
        public static string randomSplit()
        {
            double num = Math.Ceiling(r.NextDouble() * 8);
            return "Imagenes\\Split\\Split" + num + ".png";
        }
        public static bool addDepo(string nombre ,bool indiv, int titulares)
        {
            Program.cm.Open("bd7sdco", "root");
            
            Program.cm.Execute("SELECT * FROM deporte WHERE nombreDep = '" + nombre + "'", out cantFilas);
            
            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Execute("insert into deporte values ('" + nombre + "','" + indiv + "'," + titulares + ")", out cantFilas);
                Program.cm.Close();
                return true;
            }
            else
            {
                Program.cm.Close();
                return false;
            }
        }
        public static bool addEqui(string nombre, bool indiv, int titulares)
        {
            Program.cm.Open("bd7sdco", "root");

            Program.cm.Execute("SELECT * FROM equipo WHERE nombreEqu = '" + nombre + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Execute("insert into equipo values ('" + nombre + "')", out cantFilas);
                Program.cm.Close();
                return true;
            }
            else
            {
                Program.cm.Close();
                return false;
            }
        }
        public static bool addTorn(string nombre)//, int id)
        {
            Program.cm.Open("bd7sdco", "root");

            Program.cm.Execute("SELECT * FROM torneo WHERE nombreTorn = '" + nombre + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Execute("insert into torneo values ('" + nombre + /* "'," + id + */ "')", out cantFilas);
                Program.cm.Close();
                return true;
            }
            else
            {
                Program.cm.Close();
                return false;
            }
        }
    }
}
