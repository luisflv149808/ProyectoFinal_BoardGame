using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;
using ProyectoFinal;

public class Usuario
{
    public String nombre;
    public String apellidos;
    public String fechaRegistro;
    public String usuarioBGG;
    public List<String> coleccionJuegos = new List<string>();
    

    XmlNodeList listaJuegos;
    public Usuario(String nombreUsuario, String rutaCacheUsuario)
    {
        XmlDocument documentoUsuario;
        
        if (File.Exists(rutaCacheUsuario + nombreUsuario))
        {
             
            documentoUsuario = new XmlDocument();
            
            documentoUsuario.Load(rutaCacheUsuario + nombreUsuario);
            
        }
        else
        {
            documentoUsuario = Consultas.consultarApiUsuario(nombreUsuario);

        }
        XmlDocument documentoColeccion;
        if (File.Exists(rutaCacheUsuario + "/coleccion/" + nombreUsuario))
        {
            

            documentoColeccion = new XmlDocument();
            documentoColeccion.Load(rutaCacheUsuario + "/coleccion/" + nombreUsuario);
            
        }
        else
        {
            documentoColeccion = Consultas.consultarApiUsuarioColeccionJuegos(nombreUsuario);
            
        }


        



        nombre = documentoUsuario.DocumentElement.SelectSingleNode("/user/firstname").Attributes[0].Value;
        apellidos = documentoUsuario.DocumentElement.SelectSingleNode("/user/lastname").Attributes[0].Value;
        fechaRegistro = documentoUsuario.DocumentElement.SelectSingleNode("/user/yearregistered").Attributes[0].Value;

       

        listaJuegos = documentoColeccion.DocumentElement.SelectNodes("items/item");
        
      





        if (fechaRegistro.Length == 0)
        {
            throw new Exception("No existe un usuario con ese nombre");
        }
        usuarioBGG = documentoUsuario.DocumentElement.SelectSingleNode("/user").Attributes[1].Value;
        documentoUsuario.Save(rutaCacheUsuario + nombreUsuario);
        documentoColeccion.Save(rutaCacheUsuario + "/coleccion/" + nombreUsuario);

        listaJuegos = documentoColeccion.DocumentElement.SelectNodes("/items/item");
        foreach(XmlNode juego in listaJuegos)
        {
            coleccionJuegos.Add(juego.Attributes["objectid"].Value);
        }

    }
      
        
    }

