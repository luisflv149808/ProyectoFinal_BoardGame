using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;
public class Consultas
{
    
    public Consultas()
    {
        
    }

    private static XmlDocument consultarApi(String URL)
    {
        WebResponse respuesta = null;
        int delay = 500;
        while (respuesta == null && delay <60000)
        {
            try
            {
                WebRequest peticion = WebRequest.Create(URL);
                respuesta = peticion.GetResponse();
            }
            catch (Exception excepcion)
            {
                System.Threading.Thread.Sleep(delay);
                delay += 100;
            }
        }

       
        Stream flujo = respuesta.GetResponseStream();
        StreamReader lectorFlujo = new StreamReader(flujo);
        String cadenaRespuesta = lectorFlujo.ReadToEnd();
        XmlDocument xmlRespuesta = new XmlDocument();
        xmlRespuesta.LoadXml(cadenaRespuesta);
        return xmlRespuesta;
    }

    public static XmlDocument consultarApiUsuario(String usuario)
    {
        String urlConsulta = "https://www.boardgamegeek.com/xmlapi2/username=" + usuario;
        return consultarApi(urlConsulta);
    }

    public static XmlDocument consultarApiJuego(String id)
    {
        String urlConsulta = "https://www.boardgamegeek.com/xmlapi2/things?id=" + id;
        return consultarApi(urlConsulta);
    }

    public static XmlDocument consultarApiUsuarioColeccionJuegos(String usuario)
    { 

        String urlConsulta = "https://boardgamegeek.com/xmlapi2/collection?username=" + usuario + "&own=1";
        return consultarApi(urlConsulta);
    }

    public static XmlDocument consultarApiUsuarioJugadas(String usuario) {

        String urlConsulta = "https://boardgamegeek.com/xmlapi2/plays?username=" + usuario;
        return consultarApi(urlConsulta);
    }

}