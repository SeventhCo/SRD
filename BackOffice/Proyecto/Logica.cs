using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto
{
    class Logica
    {
        public static ADODB.Recordset rs = new ADODB.Recordset();
        public static ADODB.Connection cm = new ADODB.Connection();
        static Random r = new Random();
        static object cantFilas;

        public static byte registrar(string gmail, string dominio, string contra , int rol , string nacimiento , string nombre , string apellido , string pais ,string vencimiento)
        {
            cm.Open("bd7sdco", "root");
            cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' and dominio = '"+dominio+"'", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into usuario values ('"+gmail+"','"+dominio+"',md5('"+contra+"'),"+rol+",'"+nacimiento+"','"+nombre+"','"+apellido+"','"+pais+"','"+vencimiento+"')", out cantFilas);
                cm.Close();
                return 0;
            }
            else
            {
                cm.Close();
                return 1;
            }
        }
        public static byte iniciar(string gmail,string dominio, string contra)
        {
            cm.Open("bd7sdco", "root");
            cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND dominio = '"+dominio+"' AND contra = md5('" + contra + "')", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                cm.Close();
                return 2;
            }
            else
            {
                cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND contra = md5('" + contra + "') AND rol > 0", out cantFilas);
                cm.Close();
                if (cantFilas.ToString().Equals("0"))
                {
                    return 1;
                }
                else return 0;
            }
        }
        public static byte iniciarAdmin(string gmail,string dominio, string contra)
        {
            cm.Open("bd7sdco", "root");
            cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND dominio = '" + dominio + "' AND contra = md5('" + contra + "')", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                cm.Close();
                return 2;
            }
            else
            {
                cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND dominio = '" + dominio + "' AND contra = md5('" + contra + "') AND rol = 2", out cantFilas);
                cm.Close();
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
        public static bool addDepo(string sistema,string nombre, string nombreCorto, bool indiv, int titulares, Image icono)
        {
            string img = Convert.ToBase64String(Logica.conImgByte(icono));
            cm.Open("bd7sdco", "root");
            cm.Execute("SELECT * FROM deporte WHERE nombreDep = '" + nombre + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into deporte values ('"+sistema+"','" + nombre + "','" + nombreCorto + "'," + indiv + "," + titulares + ",'"+img+"','')", out cantFilas);
                cm.Close();
                return true;
            }
            else
            {
                cm.Close();
                return false;
            }
        }
        public static void rmDepo(string nombre)
        {
            cm.Open("bd7sdco", "root");
            cm.Execute("DELETE from deporte where nombreDep = '"+nombre+"';", out cantFilas);
            cm.Close();
        }

        public static dynamic[,] consulta(string comando)
        {
            cm.Open("bd7sdco", "root");
            rs.Open(comando, cm);
            dynamic[,] a = null;
            if (!rs.EOF)
            {
                a = rs.GetRows();
            }
            rs.Close();
            cm.Close();
            return a;
        }

        public static object comando (string comando)
        {
            cm.Open("bd7sdco", "root");
            cm.Execute(comando, out cantFilas);
            cm.Close();
            return cantFilas;
        }

        public static int consultaMaxIndex (string comando)
        {
            cm.Open("bd7sdco", "root");
            cm.Execute(comando, out cantFilas);
            cm.Close();
            int resp;
            int.TryParse(cantFilas.ToString(),out resp);
            return resp;
        }

        public static bool addEqui(string nombreEqu , string nombreCorto,Image icono, string texto1 , string texto2 ,string Presidente , string Fundacion )
        {
            string img = Convert.ToBase64String(Logica.conImgByte(icono));

            cm.Open("bd7sdco", "root");
            cm.Execute("SELECT * FROM equipo WHERE nombreEqu = '" + nombreEqu + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into equipo values ('" + nombreEqu + "','"+nombreCorto+"','"+img+"','"+texto1+"','"+texto2+"','"+Presidente+"','"+Fundacion+"')", out cantFilas);
                cm.Close();
                return true;
            }
            else
            {
                cm.Close();
                return false;
            }
        }
        public static void rmEqui(string nombre)
        {
            cm.Open("bd7sdco", "root");
            cm.Execute("DELETE from equipo where nombreEqu = '" + nombre + "';", out cantFilas);
            cm.Close();
        }
        public static bool addTorn(string nombreTorn, string nombreCorto, bool nac_inter,string Trofeo, Image icono, int estado, string nombreDepo)
        {
            string img = Convert.ToBase64String(Logica.conImgByte(icono));
            cm.Open("bd7sdco", "root");
            cm.Execute("SELECT * FROM torneo WHERE nombreTorn = '" + nombreTorn + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into torneo values ('" + nombreTorn + "','"+nombreCorto+"',"+nac_inter+",'"+Trofeo+"','"+img+"',"+estado+",'"+nombreDepo+"')", out cantFilas);
                cm.Close();
                return true;
            }
            else
            {
                cm.Close();
                return false;
            }
        }
        public static void rmTorn(string nombre)
        {
            cm.Open("bd7sdco", "root");
            cm.Execute("DELETE from torneo where nombreTorn = '" + nombre + "';", out cantFilas);
            cm.Close();
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
        public static byte addPunto(string nombre,int tipo,string[] datos)
        {
            cm.Open("bd7sdco", "root");
            cm.Execute("SELECT * FROM sistema WHERE nombre = '" + nombre + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into sistema values ('" + nombre + "')", out cantFilas);
                cm.Execute("insert into puntos values ('" + nombre + "')", out cantFilas);
                for (int i = 0; i < datos.Length;i += 2)
                {
                    cm.Execute("insert into pointData values ('" + nombre + "','"+datos[i]+"',"+datos[i+1]+")", out cantFilas);
                }
                cm.Close();
                return 0;
            }
            else
            {
                cm.Close();
                return 1;
            }
        }
        public static byte addSet(string nombre, string[] datos, List<CheckBox> cbSet)
        {
            //int id,int cantSets, int delimitadorSet , bool suma_Indiv
            cm.Open("bd7sdco", "root");
            cm.Execute("SELECT * FROM sistema WHERE nombre = '" + nombre + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into sistema values ('" + nombre + "')", out cantFilas);
                cm.Execute("insert into sets values ('" + nombre + "')", out cantFilas);
                for (int i = 0; i < datos.Length; i += 2)
                {
                    cm.Execute("insert into setData values ('" + nombre + "'," + i/2 + "," + datos[i] + "," + datos[i+1] + ","+cbSet[i].Checked+")", out cantFilas);
                }
                cm.Close();
                return 0;
            }
            else
            {
                cm.Close();
                return 1;
            }
        }
        public static void addPointToSet(string nombre,int id, string[] datos)
        {
            cm.Open("bd7sdco", "root");
            for (int i = 0; i < datos.Length; i += 2)
            {
                cm.Execute("insert into pointDataSet values ('" + nombre + "'," + id + ",'" + datos[i] + "'," + datos[i + 1] + ")", out cantFilas);
            }
            cm.Close();
        }
        public static byte addMagnitud(string nombre, int magnitud)
        {
            cm.Open("bd7sdco", "root");
            cm.Execute("SELECT * FROM sistema WHERE nombre = '" + nombre + "'", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into sistema values ('" + nombre + "')", out cantFilas);
                cm.Execute("insert into magnitud values ('" + nombre + "'," + magnitud + ")", out cantFilas);
                cm.Close();
                return 0;
            }
            else
            {
                cm.Close();
                return 1;
            }
        }
    }
}
