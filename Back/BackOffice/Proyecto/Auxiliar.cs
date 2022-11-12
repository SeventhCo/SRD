using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Proyecto
{
    class Auxiliar
    {
    }

    public static class Idioma
    {
        public static Dictionary<string, string> info = new Dictionary<string, string>();

        public static void cargar(string archivo)
        {
            info.Clear();

            foreach (string linea in File.ReadLines("lang//" + archivo))
            {
                if (linea.Contains("="))
                {
                    string[] s = linea.Split(new char[] { '=' });
                    info.Add(s[0], s[1]);
                }
            }
        }

        public static void cambiarIdioma(string archivo)
        {
            Properties.Settings config = new Properties.Settings();
            config.lang = archivo;
            config.Save();
            cargar(archivo);

        }

        static public void controles(Panel f)
        {
            foreach (string control in info.Keys)
            {
                try
                {
                    f.Controls[control].Text = info[control];
                }
                catch (Exception e) { }
            }
        }
    }

    class Visual
    {
        public Panel fase;
        public Vinculo equipos;
        public List<Panel> enfrentamientos = new List<Panel>();

        public Visual(Panel pn, Vinculo eq)
        {
            fase = pn; equipos = eq;
        }
        public void Dispose()
        {
            fase.Dispose();
            equipos.Dispose();
        }
    }

    class Vinculo
    {
        public Panel fase;
        public GroupBox config;
        public int id;

        public Vinculo(Panel pn, GroupBox co, int ida)
        {
            fase = pn; config = co; id = ida;
        }
        public void Dispose()
        {
            fase.Dispose();
            config.Dispose();
        }
    }

    class Selected
    {
        public Panel enfrentamiento;
        public List<dynamic[,]> Seleccionados;

        public Selected(Panel enf, List<dynamic[,]> Select)
        {
            enfrentamiento = enf;
            Seleccionados = Select;
        }
    }

    class Inicio
    {
        public int idSuceso = 1;
        public string text;
    }
    class Final
    {
        public int idSuceso = 2,minuto;
        public string text;
    }
    class Anotacion
    {
        public int idSuceso = 3,minuto, deportista;
        public string equipo, punto;
    }
    class Pausa
    {
        public int idSuceso = 4, minuto;
        public string duracion;
    }
    class Sancion
    {
        public int idSuceso = 5, minuto, deportista;
        public string equipo , gravedad  ,text;
    }

    class Arbitro
    {
        public string nombre,pais;
    }

}
