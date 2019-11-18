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
                agregarNodosRaizArbol();

                limpiarListView();
                limpiarTreeView();


                diccionarioAutores.Clear();
                diccionarioJuegos.Clear();





                try {
                    Usuario usuario = new Usuario(txtNombre.Text, directorioCacheUsuarios);

                    guardarDatosEnDiccionarioAutores(usuario);
                    guardarDatosEnDiccionarioJuegos(usuario);

                    mostrarElementos();

                } catch (Exception excepcion) {

                }

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

        private void agregarColumnasParaAutorListView() {
            lvJuegos.Columns.Clear();
            lvJuegos.Columns.Add("Autor");
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

        private void agregarNumJugadoresTreeView(String nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo, 0, 0);
            nuevoNodo.Tag = "numJugadores";
            nuevoNodo.Name = nodo;
            tvAutores.Nodes.Find("juegos", false)[0].Nodes.Add(nuevoNodo);
        }

        private void agregarJuegoEnNumJugadoresTreeView(String nodoPadre, Juego nodo) {
            TreeNode nuevoNodo;
            nuevoNodo = new TreeNode(nodo.nombre, 0, 0);
            nuevoNodo.Tag = "juego";
            nuevoNodo.Name = nodo.id;
            nuevoNodo.ImageIndex = imglArbol.Images.Count - 1;
            nuevoNodo.SelectedImageIndex = imglArbol.Images.Count - 1;
            TreeNode padre = tvAutores.Nodes["juegos"].Nodes.Find(nodoPadre, false)[0];
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
                lblMensaje.Text = diccionarioJuegos.Count.ToString() + " juegos";
            } else if (e.Node.Tag.Equals("numjugadores")) {

                MessageBox.Show("Proximamente");

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

            TreeNode nodoJuegos = new TreeNode("Juegos", 1, 1);
            tvAutores.Nodes.Add(nodoJuegos);
            nodoJuegos.Tag = "juegos";
            nodoJuegos.Tag = "numjugadores";
        }



        private void limpiarTreeView() {
            if (tvAutores.GetNodeAt(0, 0).Nodes.Count > 0) {
                tvAutores.Nodes.Clear();

            }
        }

        private void label2_Click(object sender, EventArgs e) {

        }
    }
}
