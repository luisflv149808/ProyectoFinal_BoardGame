using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;

using System.Drawing;

namespace ProyectoFinal {
    class Juego {
        public String nombre;
        public String autor;
        public List<String> autores = new List<string>();
        public List<String> mecanicas = new List<string>();
        public List<String> familias = new List<string>();
        public List<String> categorias = new List<string>();
        public String ilustrador;
        public String rutaImagen;
        public String id;
        public int jugadoresMinimos;
        public int jugadoresMaximos;
        public String jugadoresRecomendados;




        XmlNodeList listaAutores, listaMecanicas, listaFamilia, listaCategoria;

        public Juego(String nombreJuego, String rutaCacheJuego) {
            XmlDocument documentoJuego;
            if (File.Exists(rutaCacheJuego + nombreJuego)) {
                documentoJuego = new XmlDocument();
                documentoJuego.Load(rutaCacheJuego + nombreJuego);

                rutaImagen = rutaCacheJuego + "thumbnail/" + nombreJuego + ".jpg";
            } else {
                documentoJuego = Consultas.consultarApiJuego(nombreJuego);
                rutaImagen = documentoJuego.DocumentElement.SelectSingleNode("/items/item/thumbnail").InnerText;
                WebClient webClient = new WebClient();
                webClient.DownloadFile(rutaImagen, rutaCacheJuego + "thumbnail/" + nombreJuego + ".jpg");
            }


            try {
                nombre = documentoJuego.DocumentElement.SelectSingleNode("/items/item/name").Attributes["value"].Value;
            } catch (Exception excepcion) {
                nombre = "No tiene nombre";
            }

            try {
                listaAutores = documentoJuego.DocumentElement.SelectNodes("/items/item/link[@type='boardgamedesigner']");
                foreach (XmlNode autor in listaAutores) {
                    autores.Add(autor.Attributes["value"].Value);
                }
            } catch (Exception excepcion) {
                autor = "Autor Anónimo";
            }


            try {
                listaMecanicas = documentoJuego.DocumentElement.SelectNodes("/items/item/link[@type='boardgamemechanic']");


                foreach (XmlNode mecanica in listaMecanicas) {
                    mecanicas.Add(mecanica.Attributes["value"].Value);
                    
                }


            } catch (Exception excepcion) {

            }

            try {
                listaFamilia = documentoJuego.DocumentElement.SelectNodes("/items/item/link[@type='boardgamefamily']");


                foreach (XmlNode familia in listaFamilia) {

                    familias.Add(familia.Attributes["value"].Value);
                }


            } catch (Exception excepcion) {

            }

            try {
                listaCategoria = documentoJuego.DocumentElement.SelectNodes("/items/item/link[@type='boardgamecategory']");


                foreach (XmlNode categoria in listaCategoria) {

                    categorias.Add(categoria.Attributes["value"].Value);
                }


            } catch (Exception excepcion) {

            }



            try {
                ilustrador = documentoJuego.DocumentElement.SelectSingleNode("/items/item/link[@type='boardgameartist']").Attributes["value"].Value;

            } catch (Exception excepcion) {
                ilustrador = "No tiene ilustrador";
            }



            try {
                id = documentoJuego.DocumentElement.SelectSingleNode("/items/item").Attributes["id"].Value;

            } catch (Exception excepcion) {
                id = "No tiene id";

            }

            try {
                jugadoresMinimos = int.Parse(documentoJuego.DocumentElement.SelectSingleNode("/items/item/minplayers").Attributes["value"].Value);
                jugadoresMaximos = int.Parse(documentoJuego.DocumentElement.SelectSingleNode("/items/item/maxplayers").Attributes["value"].Value);

            } catch (Exception excepcion) {

            }




            if (nombre.Length == 0) {
                throw new Exception("No existe un juego con ese nombre");
            }

            documentoJuego.Save(rutaCacheJuego + nombreJuego);


        }
    }
}
