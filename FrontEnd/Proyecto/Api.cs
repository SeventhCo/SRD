using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class ApiAux
    {
        public static string iniciarSesion(string json)
        {
            Usuarios usuario = JsonConvert.DeserializeObject<Usuarios>(json);
            return JsonConvert.SerializeObject(new Retorno(Logica.iniciar(usuario.mail, usuario.dominio, usuario.contra)));
        }
        public static string registrar(string json)
        {
            Usuarios usuario = JsonConvert.DeserializeObject<Usuarios>(json);
            return JsonConvert.SerializeObject(new Retorno(Logica.registrar(usuario.mail, usuario.dominio, usuario.contra, usuario.nacimiento, usuario.nombre, usuario.apellido, usuario.pais, usuario.vencimiento)));
        }
        public static string consulta(string consulta)
        {
            return JsonConvert.SerializeObject(Logica.consulta(consulta));
        }
        public static string consultaMaxIndex(string consulta)
        {
            return JsonConvert.SerializeObject(new Retorno(Logica.consultaMaxIndex(consulta)));
        }
        public static string comando(string comando)
        {
            return JsonConvert.SerializeObject(Logica.comando(comando));
        }
    }
}
