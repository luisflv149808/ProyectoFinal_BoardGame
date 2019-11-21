using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;

namespace ProyectoFinal {
    public partial class Form1 : Form {

        String directorioCache;
        String directorioCacheUsuarios;
        String directorioCacheJuego;
        String directorioCacheColeccion;
        String directorioCacheThumbnail;
        String direccionImagenThumbnail;
        String idJuegoSeleccionado;
        String autorSeleccionado;
        String nombreJuego;

        SortedDictionary<String, List<Juego>> diccionarioAutores = new SortedDictionary<string, List<Juego>>();
        SortedDictionary<int, List<Juego>> diccionarioJuegos = new SortedDictionary<int, List<Juego>>();
        SortedDictionary<String, List<Juego>> diccionarioCategorias = new SortedDictionary<String, List<Juego>>();
        SortedDictionary<String, List<Juego>> diccionarioFamilias = new SortedDictionary<String, List<Juego>>();
        SortedDictionary<String, List<Juego>> diccionarioMecanicas = new SortedDictionary<String, List<Juego>>();


        public Form1() {
            InitializeComponent();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e) {
            String nombreUsuario = txtNombre.Text;
            pnlInfoJuego.Visible = false;

            if (nombreUsuario == "") {
                MessageBox.Show("Introduce un nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else {

                agregarColumnasParaAutorListView();


                limpiarListView();
                limpiarTreeView();


                diccionarioAutores.Clear();
                diccionarioJuegos.Clear();
                diccionarioCategorias.Clear();





                Usuario usuario = new Usuario(txtNombre.Text, directorioCacheUsuarios);


                guardarDatosEnDiccionarioAutores(usuario);
                guardarDatosEnDiccionarioJuegos(usuario);
                guardarDatosEnDiccionarioCategoria(usuario);
                guardarDatosEnDiccionarioFamilia(usuario);
                guardarDatosEnDiccionarioMecanica(usuario);
                mostrarElementos();



            }



        }

        private void mostrarElementos() {

            foreach (String autor in diccionarioAutores.Keys) {
                agregarAutorTreeView(autor);
                agregarAutorListView(autor);

                foreach (Juego juego in diccionarioAutores[autor]) {
                    imglArbol.Images.Add(Image.FromFile(directorioCacheJuego + "thumbnail/" + juego.id + ".jpg"));
                    agregarJuegoDeAutorTreeView(autor, juego);
                    lblMensaje.Text = diccionarioAutores.Count.ToString() + " autores";
                }
            }

            foreach (int numJugadores in diccionarioJuegos.Keys) {



                agregarNumJugadoresTreeView(numJugadores.ToString());




                //agregarAutorListView(autor);

                foreach (Juego juego in diccionarioJuegos[numJugadores]) {
                    imglArbol.Images.Add(Image.FromFile(directorioCacheJuego + "thumbnail/" + juego.id + ".jpg"));

                    agregarJuegoEnNumJugadoresTreeView(numJugadores.ToString(), juego);
                    lblMensaje.Text = diccionarioJuegos.Count.ToString() + " número de Jugadores.";
                }
            }

            foreach (String categorias in diccionarioCategorias.Keys) {

                agregarCategoriasTreeView(categorias);
                //agregarAutorListView(autor);

                foreach (Juego juego in diccionarioCategorias[categorias]) {

                    imglArbol.Images.Add(Image.FromFile(directorioCacheJuego + "thumbnail/" + juego.id + ".jpg"));
                    agregarJuegoEnCategoriaTreeView(categorias, juego);
                    lblMensaje.Text = diccionarioCategorias.Count.ToString() + " número de Juegos.";
                }
            }

            foreach (String familias in diccionarioFamilias.Keys) {

                agregarFamiliasTreeView(familias);
                //agregarAutorListView(autor);

                foreach (Juego juego in diccionarioFamilias[familias]) {

                    imglArbol.Images.Add(Image.FromFile(directorioCacheJuego + "thumbnail/" + juego.id + ".jpg"));
                    agregarJuegoEnFamiliaTreeView(familias, juego);
                    lblMensaje.Text = diccionarioFamilias.Count.ToString() + " número de Juegos.";
                }
            }

            foreach (String mecanicas in diccionarioMecanicas.Keys) {

                agregarMecanicasTreeView(mecanicas);
                //agregarAutorListView(autor);

                foreach (Juego juego in diccionarioMecanicas[mecanicas]) {

                    imglArbol.Images.Add(Image.FromFile(directorioCacheJuego + "thumbnail/" + juego.id + ".jpg"));
                    agregarJuegoEnMecanicaTreeView(mecanicas, juego);
                    lblMensaje.Text = diccionarioFamilias.Count.ToString() + " número de Juegos.";
                }
            }


        }


        private void agregarJuegoDeAutorListView(Juego juego) {

            direccionImagenThumbnail = Application.LocalUserAppDataPath + "/juegos/thumbnail/" + juego.id + ".jpg";

            ListViewItem item = new ListViewItem(
                juego.nombre, imglChiquitos.Images.Count);

            imglChiquitos.Images.Add(Image.FromFile(direccionImagenThumbnail));
            //imglChiquitos.Images.Add(juego.cargarImagen(directorioCacheJuego + "thumbnail/" + juego.id));
            List<String> autores = juego.autores;
            String cadenaAutores = "";
            foreach (String autor in autores) {
                cadenaAutores += autor + ", ";
            }
            item.SubItems.Add(cadenaAutores);
            item.Tag = "juego";
            item.Name = juego.id;
            lvJuegos.Items.Add(item);
            item.SubItems.Add(juego.ilustrador);

            item.SubItems.Add(juego.jugadoresMinimos.ToString());
            item.SubItems.Add(juego.jugadoresMaximos.ToString());

            item.SubItems.Add(juego.id);
        }

        private void agregarAutorListView(String autor) {
            ListViewItem item = new ListViewItem(autor, imglChiquitos.Images.Count);
            imglChiquitos.Images.Add(imglArbol.Images[0]);
            item.Tag = "autor";
            lvJuegos.Items.Add(item);
        }

        private void agregarNumeroListView(String numero) {
            ListViewItem item = new ListViewItem(numero, imglChiquitos.Images.Count);
            imglChiquitos.Images.Add(imglArbol.Images[0]);
            item.Tag = "numjugador";
            lvJuegos.Items.Add(item);
        }

        private void agregarFamiliaListView(String familia) {
            ListViewItem item = new ListViewItem(familia, imglChiquitos.Images.Count);
            imglChiquitos.Images.Add(imglArbol.Images[0]);
            item.Tag = "familia";
            lvJuegos.Items.Add(item);
        }

        private void agregarMecanicaListView(String mecanica) {
            ListViewItem item = new ListViewItem(mecanica, imglChiquitos.Images.Count);
            imglChiquitos.Images.Add(imglArbol.Images[0]);
            item.Tag = "mecanica";
            lvJuegos.Items.Add(item);
        }

        private void agregarCategoriaListView(String categoria) {
            ListViewItem item = new ListViewItem(categoria, imglChiquitos.Images.Count);
            imglChiquitos.Images.Add(imglArbol.Images[0]);
            item.Tag = "categoria";
            lvJuegos.Items.Add(item);
        }

        private void agregarColumnasParaAutorListView() {
            lvJuegos.Columns.Clear();
            lvJuegos.Columns.Add("Autor");
            lvJuegos.Columns[0].Width = 200;
        }

        private void agregarColumnasParaNumeroJugadoresListView() {
            lvJuegos.Columns.Clear();
            lvJuegos.Columns.Add("Número de Jugadores");
            lvJuegos.Columns[0].Width = 200;
        }
        private void agregarColumnasParaCategoriasListView() {
            lvJuegos.Columns.Clear();
            lvJuegos.Columns.Add("Categorias");
            lvJuegos.Columns[0].Width = 200;
        }

        private void agregarColumnasParaFamiliasListView() {
            lvJuegos.Columns.Clear();
            lvJuegos.Columns.Add("Familias");
            lvJuegos.Columns[0].Width = 200;
        }

        private void agregarColumnasParaMecanicasListView() {
            lvJuegos.Columns.Clear();
            lvJuegos.Columns.Add("Mecánicas");
            lvJuegos.Columns[0].Width = 200;
        }



        private void agregarColumnasParaCarpetasJuegoListView() {
            lvJuegos.Columns.Clear();
            lvJuegos.Columns.Add("Carpeta");
            lvJuegos.Columns[0].Width = 200;
        }


        private void limpiarListView() {
            lvJuegos.Columns.Clear();
            lvJuegos.Items.Clear();
        }

        private void agregarColumnasParaJuegoListView() {
            lvJuegos.Columns.Add("Nombre");
            lvJuegos.Columns.Add("Autores");
            lvJuegos.Columns.Add("Ilustrador");
            lvJuegos.Columns.Add("Minimo Jugadores");
            lvJuegos.Columns.Add("Máximo Jugadores");
            lvJuegos.Columns[0].Width = 100;
            lvJuegos.Columns[1].Width = 100;
            lvJuegos.Columns[2].Width = 100;
            lvJuegos.Columns[3].Width = 100;
            lvJuegos.Columns[4].Width = 100;
        }

        private void agregarJuegoDeNumeroListView(Juego juego) {


        }

        private void guardarDatosEnDiccionarioJuegos(Usuario usuario) {
            foreach (String idJuego in usuario.coleccionJuegos) {
                Juego juegoTemporal = new Juego(idJuego, directorioCacheJuego);
                List<Juego> listaJuegos;
                for (int i = juegoTemporal.jugadoresMinimos; i <= juegoTemporal.jugadoresMaximos; i++) {
                    if (diccionarioJuegos.ContainsKey(i)) {
                        listaJuegos = diccionarioJuegos[i];
                        listaJuegos.Add(juegoTemporal);
                        diccionarioJuegos[i] = listaJuegos;
                    } else {
                        listaJuegos = new List<Juego>();
                        listaJuegos.Add(juegoTemporal);
                        diccionarioJuegos.Add(i, listaJuegos);
                    }
                }
            }
        }

        private void guardarDatosEnDiccionarioCategoria(Usuario juego) {
            foreach (String categoria in juego.coleccionJuegos) {
                Juego juegoTemporal = new Juego(categoria, directorioCacheJuego);
                foreach (String autor in juegoTemporal.categorias) {
                    List<Juego> listaCategoria;
                    if (diccionarioCategorias.ContainsKey(autor)) {
                        listaCategoria = diccionarioCategorias[autor];
                        listaCategoria.Add(juegoTemporal);
                        diccionarioCategorias[autor] = listaCategoria;
                    } else {
                        listaCategoria = new List<Juego>();
                        listaCategoria.Add(juegoTemporal);
                        diccionarioCategorias.Add(autor, listaCategoria);
                    }
                }
            }
        }


        private void guardarDatosEnDiccionarioFamilia(Usuario juego) {
            foreach (String familias in juego.coleccionJuegos) {
                Juego juegoTemporal = new Juego(familias, directorioCacheJuego);
                foreach (String familia in juegoTemporal.familias) {
                    List<Juego> listaFamilia;
                    if (diccionarioFamilias.ContainsKey(familia)) {
                        listaFamilia = diccionarioFamilias[familia];
                        listaFamilia.Add(juegoTemporal);
                        diccionarioFamilias[familia] = listaFamilia;
                    } else {
                        listaFamilia = new List<Juego>();
                        listaFamilia.Add(juegoTemporal);
                        diccionarioFamilias.Add(familia, listaFamilia);
                    }
                }
            }
        }

        private void guardarDatosEnDiccionarioMecanica(Usuario juego) {
            foreach (String mecanicas in juego.coleccionJuegos) {
                Juego juegoTemporal = new Juego(mecanicas, directorioCacheJuego);
                foreach (String mecanica in juegoTemporal.mecanicas) {
                    List<Juego> listaMecanicas;
                    if (diccionarioMecanicas.ContainsKey(mecanica)) {
                        listaMecanicas = diccionarioMecanicas[mecanica];
                        listaMecanicas.Add(juegoTemporal);
                        diccionarioMecanicas[mecanica] = listaMecanicas;
                    } else {
                        listaMecanicas = new List<Juego>();
                        listaMecanicas.Add(juegoTemporal);
                        diccionarioMecanicas.Add(mecanica, listaMecanicas);
                    }
                }
            }
        }

        private void agregarNumJugadoresTreeView(String nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo, 0, 0);
            nuevoNodo.Tag = "numerojugadores";
            nuevoNodo.Name = nodo;
           // tvAutores.Nodes.Find("juegos", false)[0].Nodes.Add(nuevoNodo);
            TreeNode padre = tvAutores.Nodes["juegos"].Nodes.Find("numjugadores", false)[0];
            padre.Nodes.Add(nuevoNodo);
        }

       



        private void agregarCategoriasTreeView(String nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo, 0, 0);
            nuevoNodo.Tag = "categoria";
            nuevoNodo.Name = nodo;
            //tvAutores.Nodes.Find("juegos", false)[0].Nodes.Add(nuevoNodo);
            TreeNode padre = tvAutores.Nodes["juegos"].Nodes.Find("categorias", false)[0];
            padre.Nodes.Add(nuevoNodo);
        }

        private void agregarFamiliasTreeView(String nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo, 0, 0);
            nuevoNodo.Tag = "familia";
            nuevoNodo.Name = nodo;
            //tvAutores.Nodes.Find("juegos", false)[0].Nodes.Add(nuevoNodo);
            TreeNode padre = tvAutores.Nodes["juegos"].Nodes.Find("familias", false)[0];
            padre.Nodes.Add(nuevoNodo);
        }

        private void agregarMecanicasTreeView(String nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo, 0, 0);
            nuevoNodo.Tag = "mecanica";
            nuevoNodo.Name = nodo;
           // tvAutores.Nodes.Find("juegos", false)[0].Nodes.Add(nuevoNodo);
            TreeNode padre = tvAutores.Nodes["juegos"].Nodes.Find("mecanicas", false)[0];
            padre.Nodes.Add(nuevoNodo);
        }







        private void agregarJuegoEnNumJugadoresTreeView(String nodoPadre, Juego nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo.nombre, 0, 0);
            nuevoNodo.Tag = "juego";
            nuevoNodo.Name = nodo.id;
            nuevoNodo.ImageIndex = imglArbol.Images.Count - 1;
            nuevoNodo.SelectedImageIndex = imglArbol.Images.Count - 1;
            TreeNode padre = tvAutores.Nodes["juegos"].Nodes.Find("numjugadores", false)[0].Nodes.Find(nodoPadre,false)[0];
            
            padre.Nodes.Add(nuevoNodo);
        }

        private void agregarJuegoEnCategoriaTreeView(String nodoPadre, Juego nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo.nombre, 0, 0);
            nuevoNodo.Tag = "juego";
            nuevoNodo.Name = nodo.id;
            nuevoNodo.ImageIndex = imglArbol.Images.Count - 1;
            nuevoNodo.SelectedImageIndex = imglArbol.Images.Count - 1;
            TreeNode padre = tvAutores.Nodes["juegos"].Nodes.Find("categorias", false)[0].Nodes.Find(nodoPadre, false)[0];
            padre.Nodes.Add(nuevoNodo);
        }

        private void agregarJuegoEnFamiliaTreeView(String nodoPadre, Juego nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo.nombre, 0, 0);
            nuevoNodo.Tag = "juego";
            nuevoNodo.Name = nodo.id;
            nuevoNodo.ImageIndex = imglArbol.Images.Count - 1;
            nuevoNodo.SelectedImageIndex = imglArbol.Images.Count - 1;
            TreeNode padre = tvAutores.Nodes["juegos"].Nodes.Find("familias", false)[0].Nodes.Find(nodoPadre, false)[0];
            padre.Nodes.Add(nuevoNodo);
        }

        private void agregarJuegoEnMecanicaTreeView(String nodoPadre, Juego nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo.nombre, 0, 0);
            nuevoNodo.Tag = "juego";
            nuevoNodo.Name = nodo.id;
            nuevoNodo.ImageIndex = imglArbol.Images.Count - 1;
            nuevoNodo.SelectedImageIndex = imglArbol.Images.Count - 1;
            TreeNode padre = tvAutores.Nodes["juegos"].Nodes.Find("mecanicas", false)[0].Nodes.Find(nodoPadre, false)[0];
            padre.Nodes.Add(nuevoNodo);
        }

        private void agregarAutorTreeView(String nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo, 0, 0);
            nuevoNodo.Tag = "autor";
            nuevoNodo.Name = nodo;
            tvAutores.GetNodeAt(0, 0).Nodes.Add(nuevoNodo);
        }

        private void agregarNumerosTreeView(String nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo, 0, 0);
            nuevoNodo.Tag = "numero";
            nuevoNodo.Name = nodo;
            tvAutores.GetNodeAt(0, 0).Nodes.Add(nuevoNodo);
        }

        private void agregarJuegoDeAutorTreeView(String nodoPadre, Juego nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo.nombre, 0, 0);
            nuevoNodo.Tag = "juego";
            nuevoNodo.Name = nodo.id;
            nuevoNodo.ImageIndex = imglArbol.Images.Count - 1;
            nuevoNodo.SelectedImageIndex = imglArbol.Images.Count - 1;
            TreeNode padre = tvAutores.GetNodeAt(0, 0).Nodes.Find(nodoPadre, false)[0];
            padre.Nodes.Add(nuevoNodo);
        }

        private void agregarJuegoDeNumeroTreeView(String nodoPadre, Juego nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo.nombre, 0, 0);
            nuevoNodo.Tag = "juegonumero";
            nuevoNodo.Name = nodo.id;
            nuevoNodo.ImageIndex = imglArbol.Images.Count - 1;
            nuevoNodo.SelectedImageIndex = imglArbol.Images.Count - 1;
            TreeNode padre = tvAutores.GetNodeAt(0, 0).Nodes.Find(nodoPadre, false)[0];
            padre.Nodes.Add(nuevoNodo);
        }






        private void agregarJuegoListView(String autor) {

        }


        private void guardarDatosEnDiccionarioAutores(Usuario usuario) {
            foreach (String idJuego in usuario.coleccionJuegos) {
                Juego juegoTemporal = new Juego(idJuego, directorioCacheJuego);
                foreach (String autor in juegoTemporal.autores) {
                    List<Juego> listaJuegos;
                    if (diccionarioAutores.ContainsKey(autor)) {
                        listaJuegos = diccionarioAutores[autor];
                        listaJuegos.Add(juegoTemporal);
                        diccionarioAutores[autor] = listaJuegos;
                    } else {
                        listaJuegos = new List<Juego>();
                        listaJuegos.Add(juegoTemporal);
                        diccionarioAutores.Add(autor, listaJuegos);
                    }
                }
            }
        }

        



        void asegurarExistenciaDirectorioCache() {
            directorioCache = Application.LocalUserAppDataPath;
            directorioCacheUsuarios = directorioCache + "/usuarios/";

            if (!Directory.Exists(directorioCacheUsuarios)) {
                Directory.CreateDirectory(directorioCacheUsuarios);
            }
        }

        void asegurarExistenciaDirectorioColeccion() {
            directorioCache = Application.LocalUserAppDataPath;
            directorioCacheColeccion = directorioCache + "/usuarios/coleccion/";

            if (!Directory.Exists(directorioCacheColeccion)) {
                Directory.CreateDirectory(directorioCacheColeccion);
            }
        }

        void asegurarExistenciaJuegoDirectorioCache() {
            directorioCache = Application.LocalUserAppDataPath;
            directorioCacheJuego = directorioCache + "/juegos/";

            if (!Directory.Exists(directorioCacheJuego)) {
                Directory.CreateDirectory(directorioCacheJuego);
            }
        }

        void asegurarExistenciaDirectorioThumbnail() {
            directorioCache = Application.LocalUserAppDataPath;
            directorioCacheThumbnail = directorioCache + "/juegos/thumbnail";

            if (!Directory.Exists(directorioCacheThumbnail)) {
                Directory.CreateDirectory(directorioCacheThumbnail);
            }
        }




        private void Form1_Load(object sender, EventArgs e) {
            asegurarExistenciaDirectorioCache();
            asegurarExistenciaJuegoDirectorioCache();
            asegurarExistenciaDirectorioColeccion();
            asegurarExistenciaDirectorioThumbnail();
        }

        private void lvJuegos_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void tvAutores_AfterSelect(object sender, TreeViewEventArgs e) {

            if (e.Node.Tag.Equals("juego")) {
                Juego juego = new Juego(e.Node.Name, directorioCacheJuego);
                mostrarDatosJuego(juego);
                limpiarListView();
                agregarColumnasParaJuegoListView();
                agregarJuegoDeAutorListView(juego);
                pnlInfoJuego.Visible = true;
            } else if (e.Node.Tag.Equals("autor")) {
                List<Juego> listaJuegos = diccionarioAutores[e.Node.Text];
                limpiarListView();
                agregarColumnasParaJuegoListView();
                foreach (Juego juego in listaJuegos) {
                    agregarJuegoDeAutorListView(juego);
                }
                pnlInfoJuego.Visible = false;
            } else if (e.Node.Tag.Equals("autores")) {

                limpiarListView();
                agregarColumnasParaAutorListView();
                tvAutores.GetNodeAt(0, 0).Expand();
                foreach (String autor in diccionarioAutores.Keys) {
                    agregarAutorListView(autor);
                }
                pnlInfoJuego.Visible = false;
                lblMensaje.Text = diccionarioAutores.Count.ToString() + " autores";

            } else if (e.Node.Tag.Equals("juegos")) {
                limpiarListView();
                agregarColumnasParaCarpetasJuegoListView();
                tvAutores.GetNodeAt(0,0).Expand();

                


                lblMensaje.Text = diccionarioJuegos.Count.ToString() + " juegos";
                
            } else if (e.Node.Tag.Equals("numjugadores")) {
                limpiarListView();
                agregarColumnasParaNumeroJugadoresListView();
                tvAutores.GetNodeAt(0, 0).Expand();
                foreach (int numero in diccionarioJuegos.Keys) {
                    agregarNumeroListView(Convert.ToString(numero));
                   
                }
                pnlInfoJuego.Visible = false;
                //lblMensaje.Text = diccionarioJuegos.Count.ToString() + " clasificaciones";


            } else if (e.Node.Tag.Equals("categorias")) {
                limpiarListView();
                agregarColumnasParaCategoriasListView();
                tvAutores.GetNodeAt(0, 0).Expand();
                foreach (String categoria in diccionarioCategorias.Keys) {
                    agregarNumeroListView(categoria);

                }
                pnlInfoJuego.Visible = false;
                lblMensaje.Text = diccionarioCategorias.Count.ToString() + " categorias";


            } else if (e.Node.Tag.Equals("familias")) {
                limpiarListView();
                agregarColumnasParaFamiliasListView();
                tvAutores.GetNodeAt(0, 0).Expand();
                foreach (String familia in diccionarioFamilias.Keys) {
                    agregarFamiliaListView(familia);

                }
                pnlInfoJuego.Visible = false;
                lblMensaje.Text = diccionarioFamilias.Count.ToString() + " familias";




            } else if (e.Node.Tag.Equals("mecanicas")) {
                limpiarListView();
                agregarColumnasParaMecanicasListView();
                tvAutores.GetNodeAt(0, 0).Expand();
                foreach (String mecanica in diccionarioMecanicas.Keys) {
                    agregarMecanicaListView(mecanica);

                }
                pnlInfoJuego.Visible = false;
                lblMensaje.Text = diccionarioMecanicas.Count.ToString() + " mecánicas";


            }

        }

        private void mostrarDatosJuego(Juego juego) {
            lblNombreJuego.Text = juego.nombre;
            lblAutor.Text = "";
            foreach (String autor in juego.autores) {
                lblAutor.Text += autor + ", ";
            }
            lblIlustrador.Text = juego.ilustrador;

            foreach (String familias in juego.familias) {
                txtFamilias.Text = familias + "\n";
            }

            foreach (String categorias in juego.categorias) {
                txCategorias.Text = categorias + "\n";
            }

            foreach (String mecanicas  in juego.mecanicas) {
                txtMecanicas.Text = mecanicas + "\n";
            }

            pictureJuego.Load(juego.rutaImagen);

            lvJuegos.Visible = true;
        }



        private void lvJuegos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            List<Juego> listaJuegos = null;
            if (e.Item.Tag.Equals("autor")) {
                listaJuegos = diccionarioAutores[e.Item.Text];
                limpiarListView();
                agregarColumnasParaJuegoListView();
                foreach (Juego juego in listaJuegos) {
                    agregarJuegoDeAutorListView(juego);
                }
            } else {
                tvAutores.GetNodeAt(0, 0).Expand();

                mostrarDatosJuego(new Juego(e.Item.Name, directorioCacheJuego));
                pnlInfoJuego.Visible = true;
            }
            foreach (TreeNode node in tvAutores.Nodes.Find(e.Item.Text, true)) {
                node.Expand();
            }
        }





        private void agregarNodosRaizArbol() {
            TreeNode newNode = new TreeNode("Autores");
            tvAutores.Nodes.Add(newNode);
            newNode.Tag = "autores";
            newNode.Name = "autores";
            TreeNode nodoJuegos = new TreeNode("Juegos", 1, 1);
            tvAutores.Nodes.Add(nodoJuegos);
            nodoJuegos.Tag = "juegos";
            nodoJuegos.Name = "juegos";
            
        }



        private void limpiarTreeView() {
            if (tvAutores.GetNodeAt(0, 0).Nodes.Count > 0) {
                tvAutores.Nodes.Clear();

            }
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void txtMecanicas_TextChanged(object sender, EventArgs e) {

        }
    }
}
