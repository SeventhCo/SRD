using System;
using System.Drawing;
using System.IO;

namespace Proyecto
{
    class Usuarios
    {

        public string mail;
        public string dominio;
        public string contra;
        public int rol;
        public string nacimiento;
        public string nombre;
        public string apellido;
        public string pais;
        public string vencimiento;

        public Usuarios()
        {
        }
        public Usuarios(string mail, string dominio, string contra)
        {
            this.mail = mail;
            this.dominio = dominio;
            this.contra = contra;
        }

        public Usuarios(string mail, string dominio, string contra, int rol, string nacimiento, string nombre, string apellido, string pais, string vencimiento) : this(mail, dominio, contra)
        {
            this.rol = rol;
            this.nacimiento = nacimiento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.pais = pais;
            this.vencimiento = vencimiento;
        }
    }

    class Retorno
    {
        public int result;
        public Retorno(int result)
        {
            this.result = result;
        }
    }

    class Imagen
    {
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
