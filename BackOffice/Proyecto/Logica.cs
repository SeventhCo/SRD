using System;
using System.Drawing;
using System.IO;

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
        public static bool addDepo(string nombre, string nombreCorto, bool indiv, int titulares, Image icono)
        {
            string img = Convert.ToBase64String(Logica.conImgByte(icono));
            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute("SELECT * FROM deporte WHERE nombreDep = '" + nombre + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Execute("insert into deporte values ('" + nombre + "','" + nombreCorto + "','" + indiv + "'," + titulares + ",'"+img+"')", out cantFilas);
                Program.cm.Close();
                return true;
            }
            else
            {
                Program.cm.Close();
                return false;
            }
        }
        public static void rmDepo(string nombre)
        {
            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute("DELETE from deporte where nombreDep = '"+nombre+"';", out cantFilas);
            Program.cm.Close();
        }

        public static string consulta(string comando,int columna,int fila)
        {
             Program.cm.Open("bd7sdco", "root");
            Program.rs.Open(comando, Program.cm);
            string a = Program.rs.GetRows()[columna,fila]+"";
            Program.rs.Close();
            Program.cm.Close();
            return a;
        }

        public static int consultaMaxIndex (string comando)
        {
            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute(comando, out cantFilas);
            Program.cm.Close();
            int resp;
            int.TryParse(cantFilas.ToString(),out resp);
            return resp;
        }

        public static bool addEqui(string nombreEqu , string nombreCorto,Image icono, string texto1 , string texto2 ,string Presidente , string Fundacion )
        {
            string img = Convert.ToBase64String(Logica.conImgByte(icono));

            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute("SELECT * FROM equipo WHERE nombreEqu = '" + nombreEqu + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Execute("insert into equipo values ('" + nombreEqu + "','"+nombreCorto+"','"+img+"','"+texto1+"','"+texto2+"','"+Presidente+"','"+Fundacion+"')", out cantFilas);
                Program.cm.Close();
                return true;
            }
            else
            {
                Program.cm.Close();
                return false;
            }
        }
        public static void rmEqui(string nombre)
        {
            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute("DELETE from equipo where nombreEqu = '" + nombre + "';", out cantFilas);
            Program.cm.Close();
        }
        public static bool addTorn(string nombreTorn, string nombreCorto, int idTorn, bool nac_inter,string Trofeo, Image icono, string equipoGanador, bool terminado)
        {
            string img = Convert.ToBase64String(Logica.conImgByte(icono));
            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute("SELECT * FROM torneo WHERE nombreTorn = '" + nombreTorn + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                Program.cm.Execute("insert into torneo values ('" + nombreTorn + "','"+nombreCorto+"',"+idTorn+","+nac_inter+",'"+Trofeo+"','"+img+"','"+equipoGanador+"',"+terminado+")", out cantFilas);
                Program.cm.Close();
                return true;
            }
            else
            {
                Program.cm.Close();
                return false;
            }
        }
        public static void rmTorn(string nombre)
        {
            Program.cm.Open("bd7sdco", "root");
            Program.cm.Execute("DELETE from torneo where nombreTorn = '" + nombre + "';", out cantFilas);
            Program.cm.Close();
        }
        public static byte[] conImgByte(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }
        public static Image conByteImg(byte[] bytes)
        {
            if (bytes == null) return null;

            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return bm;
        }

    }
}
