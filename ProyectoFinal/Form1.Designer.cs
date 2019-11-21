namespace ProyectoFinal
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Autores");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Número Jugadores");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Categorias");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Familias");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Mécanicas");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Juegos", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.btnBuscarUsuario = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.tvAutores = new System.Windows.Forms.TreeView();
            this.imglArbol = new System.Windows.Forms.ImageList(this.components);
            this.panelInfo = new System.Windows.Forms.Panel();
            this.pnlListView = new System.Windows.Forms.Panel();
            this.lvJuegos = new System.Windows.Forms.ListView();
            this.imglChiquitos = new System.Windows.Forms.ImageList(this.components);
            this.pnlInfoJuego = new System.Windows.Forms.Panel();
            this.txCategorias = new System.Windows.Forms.TextBox();
            this.txtFamilias = new System.Windows.Forms.TextBox();
            this.txtMecanicas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureJuego = new System.Windows.Forms.PictureBox();
            this.lblIlustrador = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblNombreJuego = new System.Windows.Forms.Label();
            this.pnlBuscador.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.pnlListView.SuspendLayout();
            this.pnlInfoJuego.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJuego)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlBuscador.Controls.Add(this.btnBuscarUsuario);
            this.pnlBuscador.Controls.Add(this.txtNombre);
            this.pnlBuscador.Controls.Add(this.label1);
            this.pnlBuscador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBuscador.Location = new System.Drawing.Point(0, 0);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Size = new System.Drawing.Size(1249, 61);
            this.pnlBuscador.TabIndex = 0;
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.Location = new System.Drawing.Point(326, 13);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(119, 38);
            this.btnBuscarUsuario.TabIndex = 2;
            this.btnBuscarUsuario.Text = "Buscar";
            this.btnBuscarUsuario.UseVisualStyleBackColor = true;
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(152, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(159, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Usuario:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.lblMensaje);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 638);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1249, 57);
            this.panel1.TabIndex = 2;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(12, 18);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 20);
            this.lblMensaje.TabIndex = 0;
            // 
            // tvAutores
            // 
            this.tvAutores.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvAutores.ImageIndex = 0;
            this.tvAutores.ImageList = this.imglArbol;
            this.tvAutores.Location = new System.Drawing.Point(0, 61);
            this.tvAutores.Name = "tvAutores";
            treeNode1.Name = "autores";
            treeNode1.Tag = "autores";
            treeNode1.Text = "Autores";
            treeNode2.Name = "numjugadores";
            treeNode2.Tag = "numjugadores";
            treeNode2.Text = "Número Jugadores";
            treeNode3.Name = "categorias";
            treeNode3.Tag = "categorias";
            treeNode3.Text = "Categorias";
            treeNode4.Name = "familias";
            treeNode4.Tag = "familias";
            treeNode4.Text = "Familias";
            treeNode5.Name = "mecanicas";
            treeNode5.Tag = "mecanicas";
            treeNode5.Text = "Mécanicas";
            treeNode6.Name = "juegos";
            treeNode6.Tag = "juegos";
            treeNode6.Text = "Juegos";
            this.tvAutores.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode6});
            this.tvAutores.SelectedImageIndex = 0;
            this.tvAutores.Size = new System.Drawing.Size(281, 577);
            this.tvAutores.TabIndex = 3;
            this.tvAutores.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAutores_AfterSelect);
            // 
            // imglArbol
            // 
            this.imglArbol.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglArbol.ImageStream")));
            this.imglArbol.Tag = "0";
            this.imglArbol.TransparentColor = System.Drawing.Color.Transparent;
            this.imglArbol.Images.SetKeyName(0, "13624.png");
            this.imglArbol.Images.SetKeyName(1, "103236.png");
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelInfo.Controls.Add(this.pnlListView);
            this.panelInfo.Controls.Add(this.pnlInfoJuego);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(281, 61);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(968, 577);
            this.panelInfo.TabIndex = 5;
            // 
            // pnlListView
            // 
            this.pnlListView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlListView.Controls.Add(this.lvJuegos);
            this.pnlListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListView.Location = new System.Drawing.Point(0, 0);
            this.pnlListView.Name = "pnlListView";
            this.pnlListView.Size = new System.Drawing.Size(667, 577);
            this.pnlListView.TabIndex = 2;
            // 
            // lvJuegos
            // 
            this.lvJuegos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvJuegos.HideSelection = false;
            this.lvJuegos.Location = new System.Drawing.Point(0, 0);
            this.lvJuegos.Name = "lvJuegos";
            this.lvJuegos.Size = new System.Drawing.Size(667, 577);
            this.lvJuegos.SmallImageList = this.imglChiquitos;
            this.lvJuegos.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvJuegos.TabIndex = 0;
            this.lvJuegos.UseCompatibleStateImageBehavior = false;
            this.lvJuegos.View = System.Windows.Forms.View.Details;
            this.lvJuegos.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvJuegos_ItemSelectionChanged);
            this.lvJuegos.SelectedIndexChanged += new System.EventHandler(this.lvJuegos_SelectedIndexChanged);
            // 
            // imglChiquitos
            // 
            this.imglChiquitos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglChiquitos.ImageStream")));
            this.imglChiquitos.TransparentColor = System.Drawing.Color.Transparent;
            this.imglChiquitos.Images.SetKeyName(0, "13624.png");
            // 
            // pnlInfoJuego
            // 
            this.pnlInfoJuego.Controls.Add(this.txCategorias);
            this.pnlInfoJuego.Controls.Add(this.txtFamilias);
            this.pnlInfoJuego.Controls.Add(this.txtMecanicas);
            this.pnlInfoJuego.Controls.Add(this.label7);
            this.pnlInfoJuego.Controls.Add(this.label6);
            this.pnlInfoJuego.Controls.Add(this.label5);
            this.pnlInfoJuego.Controls.Add(this.label4);
            this.pnlInfoJuego.Controls.Add(this.label3);
            this.pnlInfoJuego.Controls.Add(this.label2);
            this.pnlInfoJuego.Controls.Add(this.pictureJuego);
            this.pnlInfoJuego.Controls.Add(this.lblIlustrador);
            this.pnlInfoJuego.Controls.Add(this.lblAutor);
            this.pnlInfoJuego.Controls.Add(this.lblNombreJuego);
            this.pnlInfoJuego.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInfoJuego.Location = new System.Drawing.Point(667, 0);
            this.pnlInfoJuego.Name = "pnlInfoJuego";
            this.pnlInfoJuego.Size = new System.Drawing.Size(301, 577);
            this.pnlInfoJuego.TabIndex = 1;
            this.pnlInfoJuego.Visible = false;
            // 
            // txCategorias
            // 
            this.txCategorias.Cursor = System.Windows.Forms.Cursors.No;
            this.txCategorias.Location = new System.Drawing.Point(15, 514);
            this.txCategorias.Multiline = true;
            this.txCategorias.Name = "txCategorias";
            this.txCategorias.ReadOnly = true;
            this.txCategorias.Size = new System.Drawing.Size(274, 57);
            this.txCategorias.TabIndex = 15;
            // 
            // txtFamilias
            // 
            this.txtFamilias.Cursor = System.Windows.Forms.Cursors.No;
            this.txtFamilias.Location = new System.Drawing.Point(16, 429);
            this.txtFamilias.Multiline = true;
            this.txtFamilias.Name = "txtFamilias";
            this.txtFamilias.ReadOnly = true;
            this.txtFamilias.Size = new System.Drawing.Size(273, 57);
            this.txtFamilias.TabIndex = 14;
            // 
            // txtMecanicas
            // 
            this.txtMecanicas.Cursor = System.Windows.Forms.Cursors.No;
            this.txtMecanicas.Location = new System.Drawing.Point(15, 337);
            this.txtMecanicas.Multiline = true;
            this.txtMecanicas.Name = "txtMecanicas";
            this.txtMecanicas.ReadOnly = true;
            this.txtMecanicas.Size = new System.Drawing.Size(274, 56);
            this.txtMecanicas.TabIndex = 13;
            this.txtMecanicas.TextChanged += new System.EventHandler(this.txtMecanicas_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 493);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Categorias:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Familias:";
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mecánicas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ilustrador:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Autor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Juego:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureJuego
            // 
            this.pictureJuego.Location = new System.Drawing.Point(48, 6);
            this.pictureJuego.Name = "pictureJuego";
            this.pictureJuego.Size = new System.Drawing.Size(208, 130);
            this.pictureJuego.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureJuego.TabIndex = 3;
            this.pictureJuego.TabStop = false;
            // 
            // lblIlustrador
            // 
            this.lblIlustrador.AutoSize = true;
            this.lblIlustrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIlustrador.Location = new System.Drawing.Point(12, 273);
            this.lblIlustrador.Name = "lblIlustrador";
            this.lblIlustrador.Size = new System.Drawing.Size(0, 18);
            this.lblIlustrador.TabIndex = 2;
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutor.Location = new System.Drawing.Point(12, 220);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(0, 18);
            this.lblAutor.TabIndex = 1;
            // 
            // lblNombreJuego
            // 
            this.lblNombreJuego.AutoSize = true;
            this.lblNombreJuego.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreJuego.Location = new System.Drawing.Point(13, 169);
            this.lblNombreJuego.Name = "lblNombreJuego";
            this.lblNombreJuego.Size = new System.Drawing.Size(0, 18);
            this.lblNombreJuego.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 695);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.tvAutores);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBuscador);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlBuscador.ResumeLayout(false);
            this.pnlBuscador.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.pnlListView.ResumeLayout(false);
            this.pnlInfoJuego.ResumeLayout(false);
            this.pnlInfoJuego.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJuego)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBuscador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvAutores;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.ImageList imglArbol;
        private System.Windows.Forms.ListView lvJuegos;
        private System.Windows.Forms.ImageList imglChiquitos;
        private System.Windows.Forms.Panel pnlInfoJuego;
        private System.Windows.Forms.Label lblNombreJuego;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblIlustrador;
        private System.Windows.Forms.PictureBox pictureJuego;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlListView;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.TextBox txtMecanicas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txCategorias;
        private System.Windows.Forms.TextBox txtFamilias;
    }
}

