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

        //public static void openAsAdmin() { cm.Open("bd7sdco", "Admin", "DBAdsdco_%.2"); }
        //public static void openAsPaidUser() { cm.Open("bd7sdco", "PaidUser", "PUbdsdco.1253"); } 
        //public static void openAsUser() { cm.Open("bd7sdco", "User", "Ubdsdco.1"); }

        public static void openAsAdmin() { cm.Open("bd7sdco", "root"); }
        public static void openAsPaidUser() { cm.Open("bd7sdco", "root"); } 
        public static void openAsUser() { cm.Open("bd7sdco", "root"); }

        public static void close() { cm.Close(); }


        public static byte registrar(string gmail, string dominio, string contra , int rol , string nacimiento , string nombre , string apellido )
        {
            cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' and dominio = '"+dominio+"'", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {

                cm.Execute("insert into usuario values ('"+gmail+"','"+dominio+"',md5('"+contra+"'),"+rol+",'"+nacimiento+"','"+nombre+"','"+apellido+"',null,null)", out cantFilas);
                return 0;
            }
            else return 1;
        }
        public static byte iniciar(string gmail,string dominio, string contra)
        {
            cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND dominio = '"+dominio+"' AND contra = md5('" + contra + "')", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                return 2;
            }
            else
            {
                cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND contra = md5('" + contra + "') AND rol > 0", out cantFilas);
                if (cantFilas.ToString().Equals("0"))
                {
                    return 1;
                }
                else return 0;
            }
        }
        public static byte iniciarAdmin(string gmail,string dominio, string contra)
        {
            cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND dominio = '" + dominio + "' AND contra = md5('" + contra + "')", out cantFilas);
            if (cantFilas.ToString().Equals("0")) return 2;
            else
            {
                cm.Execute("SELECT * FROM usuario WHERE gmail = '" + gmail + "' AND dominio = '" + dominio + "' AND contra = md5('" + contra + "') AND rol = 2", out cantFilas);
                if (cantFilas.ToString().Equals("0"))return 1;
                else return 0;
            }
        }
        public static string randomBanner()
        {
            return Logica.consulta("Select imagen from publicidad where tipo = 1")[0,Convert.ToInt32(Logica.consulta("select floor(Rand()*" + Logica.consultaMaxIndex("Select imagen from publicidad where tipo = 1") + ")")[0, 0])];
        }
        public static string randomSplit()
        {
            return Logica.consulta("Select imagen from publicidad where tipo = 0")[0, Convert.ToInt32(Logica.consulta("select floor(Rand()*" + Logica.consultaMaxIndex("Select imagen from publicidad where tipo = 0") + ")")[0, 0])];
        }
        public static bool addDepo(string sisPuntaje,string nombreDep, string nombreCorto, bool indiv, int N_titulares, Image logo,int equipos)
        {
            string img = Convert.ToBase64String(Logica.conImgByte(logo));
            cm.Execute("SELECT * FROM deporte WHERE nombreDep = '" + nombreDep + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into deporte values ('"+ sisPuntaje + "','" + nombreDep + "','" + nombreCorto + "'," + indiv + "," + N_titulares + ",'"+img+"','',"+equipos+")", out cantFilas);
                
                return true;
            }
            else
            {
                
                return false;
            }
        }
        public static bool addEquipoTorneo(string equipo, string torneo)
        {
            cm.Execute("SELECT * FROM EquipoTorneo WHERE nombreEqu = '" + equipo + "' and nombreTorn = '"+torneo+"'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into EquipoTorneo values ('"+equipo+"','"+torneo+"')", out cantFilas);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool addPublicidad(string identificador, string tipo, string pais,Image publicidad)
            {
                string publicidad1 = Convert.ToBase64String(Logica.conImgByte(publicidad));
                cm.Execute("SELECT * FROM publicidad WHERE identificador = '" + identificador + "'", out cantFilas);
                
                if (cantFilas.ToString().Equals("0"))
                {
                cm.Execute("SELECT * FROM publicidad WHERE imagen = '" + publicidad1 + "'", out cantFilas);
                if (cantFilas.ToString().Equals("0"))
                {
                    cm.Execute("insert into publicidad values ('" + pais + "','" + tipo + "','" + publicidad1 + "','" + identificador + "')", out cantFilas);
                }
                else MessageBox.Show("Esta imagen ya fue ingresada");
                return true;
                }
                else return false;
            }
        
        public static void rmDepo(string nombre)
        {
            cm.Execute("DELETE from deporte where nombreDep = '"+nombre+"';", out cantFilas);
        }

        public static dynamic[,] consulta(string comando)
        {
            rs.Open(comando, cm);
            dynamic[,] a = null;
            if (!rs.EOF)
            {
                a = rs.GetRows();
            }
            rs.Close();
            return a;
        }

        public static object comando (string comando)
        {
            cm.Execute(comando, out cantFilas);
            return cantFilas;
        }

        public static int consultaMaxIndex (string comando)
        {
            cm.Execute(comando, out cantFilas);
            
            int resp;
            int.TryParse(cantFilas.ToString(),out resp);
            return resp;
        }

        public static bool addEqui(string nombreEqu , string nombreCorto,Image icono,string nombreDep)
        {
            string img = Convert.ToBase64String(Logica.conImgByte(icono));
            
            cm.Execute("SELECT * FROM equipo WHERE nombreEqu = '" + nombreEqu + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into equipo values ('" + nombreEqu + "','"+nombreCorto+"','"+img+"',null,null,'"+ nombreDep + "')", out cantFilas);
                
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void rmEqui(string nombre)
        {
            cm.Execute("DELETE from equipo where nombreEqu = '" + nombre + "';", out cantFilas);
        }
        public static bool addTorn(bool add,string nombreTorn, string nombreCorto, bool nac_inter,string Trofeo, Image icono, int estado, string nombreDepo,string pais)
        {
            string img = Convert.ToBase64String(Logica.conImgByte(icono));
            cm.Execute("SELECT * FROM Torneo WHERE nombreTorn = '" + nombreTorn + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                if (add)
                {
                    cm.Execute("insert into Torneo values ('" + nombreTorn + "','" + nombreCorto + "','" + Trofeo + "','" + img + "'," + estado + ",'" + nombreDepo + "')", out cantFilas);
                    if (nac_inter)
                    {
                        cm.Execute("insert into torneoNacional values ('" + nombreTorn + "','"+pais+"')", out cantFilas);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void rmTorn(string nombre)
        {
            cm.Execute("DELETE from Torneo where nombreTorn = '" + nombre + "';", out cantFilas);
        }
        public static bool addfase(int idfase, int cantEnfrentamientos , string nombreFase, string fechaPrevista , int estado , string nombreTorn , string CondIngreso,bool final ){

            cm.Execute("SELECT * FROM fase WHERE nombreTorn = '" + nombreTorn + "' and nombreFase = '"+nombreFase+"'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                int Condicion = 2;
                switch (CondIngreso)
                {
                    case "Victoria":
                        Condicion = 1;
                        break;
                    case "Derrota":
                        Condicion = 0;
                        break;
                }
                cm.Execute("insert into fase values (" + idfase + "," + cantEnfrentamientos + ",'" + nombreFase + "','" + fechaPrevista + "'," + estado + ",'" + nombreTorn + "',"+final+",'" + Condicion + "')", out cantFilas);
                return true;
            }
            else
            {
                return false;
            }
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
            cm.Execute("SELECT * FROM sistema WHERE nombre = '" + nombre + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into sistema values ('" + nombre + "')", out cantFilas);
                cm.Execute("insert into puntos values ('" + nombre + "')", out cantFilas);
                for (int i = 0; i < datos.Length;i += 2)
                {
                    cm.Execute("insert into pointData values ('" + nombre + "','"+datos[i]+"',"+datos[i+1]+")", out cantFilas);
                }
                
                return 0;
            }
            else
            {
                
                return 1;
            }
        }
        public static byte addSet(string nombre, string[] datos, List<CheckBox> cbSet)
        {
            //int id,int cantSets, int delimitadorSet , bool suma_Indiv
            cm.Execute("SELECT * FROM sistema WHERE nombre = '" + nombre + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into sistema values ('" + nombre + "')", out cantFilas);
                cm.Execute("insert into sets values ('" + nombre + "')", out cantFilas);
                for (int i = 0; i < datos.Length; i += 2)
                {
                    cm.Execute("insert into setData values ('" + nombre + "'," + i/2 + "," + datos[i] + "," + datos[i+1] + ","+cbSet[i].Checked+")", out cantFilas);
                }
                
                return 0;
            }
            else
            {
                
                return 1;
            }
        }
        public static void addPointToSet(string nombre,int id, string[] datos)
        {
            for (int i = 0; i < datos.Length; i += 2)
            {
                cm.Execute("insert into pointDataSet values ('" + nombre + "'," + id + ",'" + datos[i] + "'," + datos[i + 1] + ")", out cantFilas);
            }
            
        }
        public static byte addMagnitud(string nombre, int magnitud)
        {
            cm.Execute("SELECT * FROM sistema WHERE nombre = '" + nombre + "'", out cantFilas);
            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("insert into sistema values ('" + nombre + "')", out cantFilas);
                cm.Execute("insert into magnitud values ('" + nombre + "'," + magnitud + ")", out cantFilas);
                
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool addDeportista(string cedula, string nombre, string edad, string altura, string numero, string nombreEqu, Image icono)
        {
            string img = Convert.ToBase64String(Logica.conImgByte(icono));
            cm.Execute("SELECT * FROM deportista WHERE cedula = '" + cedula + "'", out cantFilas);

            if (cantFilas.ToString().Equals("0"))
            {
                cm.Execute("SELECT * FROM deportistaEquipo WHERE nombreEqu = '" + nombreEqu + "' and numero = " + numero, out cantFilas);
                if (cantFilas.ToString().Equals("0"))
                {
                    cm.Execute("SELECT * FROM deportistaEquipo WHERE cedula = "+cedula+"  and nombreEqu = '" + nombreEqu + "'", out cantFilas);
                    if (cantFilas.ToString().Equals("0"))
                    {
                        cm.Execute("insert into deportista values ('" + cedula + "','" + nombre + "'," + edad + ",'" + altura + "','"+img+"')", out cantFilas);
                        cm.Execute("insert into deportistaEquipo values ('" + nombreEqu + "','" + cedula + "','" + numero + "')", out cantFilas);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
    
}