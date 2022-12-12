﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BoxHorario
{
    public partial class frmFichaje : Form
    {
        string ruta = @"c:\xls\";
        string cadenaConexion = "Data Source=46.226.45.108;Initial Catalog=Box;;User ID=sa;password=2015villaL";
        int lIDFichaje = 0;
        DataSet dsUsuario=new DataSet();
        DataSet dsFichaje = new DataSet();

        DateTime actual = DateTime.Today;
        DateTime? fentrada, fsalida, fentradad, fsalidad;
        public frmFichaje()
        {
            InitializeComponent();
        }

        private VideoCaptureDevice videoCapture;
        FilterInfoCollection camaras;
        private void frmFichaje_Load(object sender, EventArgs e)
        {
            camaras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            this.Size = new Size(809, 814);   //login
            panelcamara.Visible = false;
            panelfichaje.Visible = false;
            panellogin.Visible = true;

            lbldia.Text = DateTime.Now.ToLongDateString();

            txtUsuario.Text = "1234";
            txtClave.Text = "1234";
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length == 0 || txtClave.Text.Length == 0)
                MessageBox.Show("Introduzca usuario y contraseña.");
            else
            {
                dsUsuario = (DataSet)Login(txtUsuario.Text, txtClave.Text);
                if (dsUsuario.Tables[0].Rows.Count == 0)
                    MessageBox.Show("Usuario o contraseña no válidos.");
                else
                {
                    lIDFichaje = 0;
                    txtUsuario.Text = "Usuario";
                    txtClave.Text = "Contraseña";
                    txtClave.PasswordChar = '\0';
                    btnAceptar.Enabled = false;
                    fentrada = null;
                    fsalida = null;
                    fentradad = null;
                    fsalidad = null;
                    dsFichaje = (DataSet)Buscar();
                    if (dsFichaje.Tables[0].Rows.Count > 0)
                    {
                        fentrada = (DateTime)dsFichaje.Tables[0].Rows[0]["FechaEntrada"];
                        if (dsFichaje.Tables[0].Rows[0]["FechaSalidaDescanso"] != DBNull.Value)
                            fsalidad = (DateTime)dsFichaje.Tables[0].Rows[0]["FechaSalidaDescanso"];
                        if (dsFichaje.Tables[0].Rows[0]["FechaEntradaDescanso"] != DBNull.Value)
                            fentradad = (DateTime)dsFichaje.Tables[0].Rows[0]["FechaEntradaDescanso"];
                        if (dsFichaje.Tables[0].Rows[0]["FechaSalida"] != DBNull.Value)
                        {
                            fsalida = (DateTime)dsFichaje.Tables[0].Rows[0]["FechaSalida"];
                        }
                        else
                            lIDFichaje = (int)dsFichaje.Tables[0].Rows[0]["IDFichaje"];

                    }
                    Fichaje();
                }
            }
        }
        private void Fichaje()
        {
            CerrarCamara();

            timer2.Enabled = true;

            string nombrecamara = camaras[0].MonikerString;
            videoCapture = new VideoCaptureDevice(nombrecamara);
            videoCapture.NewFrame += new NewFrameEventHandler(Capturando);
            videoCapture.Start();

            //esperar 1 segundos
            System.Threading.Thread.Sleep(1000);

            panelcamara.Visible = true;
            panelfichaje.Visible = true;
            panellogin.Visible = false;
            this.Size = new Size(809, 814);   //fichaje

            // botones
            if (fsalida != null)    //jornada finalizada-->entrada
            {
                btnEntrada.Enabled = true;
                btnPausa.Enabled = false;
                btnPausa.Visible = true;
                btnReanudar.Enabled = false;
                btnReanudar.Visible = false;
                btnSalida.Enabled = false;
            }
            else if (fentradad != null)    //ha vuelto pausa-->salida
            {
                btnEntrada.Enabled = false;
                btnPausa.Enabled = false;
                btnPausa.Visible = true;
                btnReanudar.Enabled = false;
                btnReanudar.Visible = false;
                btnSalida.Enabled = true;
            }
            else if (fsalidad != null)    //en pausa-->reanudar
            {
                btnEntrada.Enabled = false;
                btnPausa.Enabled = false;
                btnPausa.Visible = false;
                btnReanudar.Enabled = true;
                btnReanudar.Visible = true;
                btnSalida.Enabled = false;
            }
            else if (fentrada != null)    //pausa o fin jornada
            {
                btnEntrada.Enabled = false;
                btnPausa.Enabled = true;
                btnPausa.Visible = true;
                btnReanudar.Enabled = false;
                btnReanudar.Visible = false;
                btnSalida.Enabled = true;
            }
            else    //inicio jornada
            {
                btnEntrada.Enabled = true;
                btnPausa.Enabled = false;
                btnPausa.Visible = true;
                btnReanudar.Enabled = false;
                btnReanudar.Visible = false;
                btnSalida.Enabled = false;
            }
            if (btnEntrada.Enabled == false)
                btnEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            else
                btnEntrada.BackColor = Color.Indigo;
            if (btnPausa.Enabled == false)
                btnPausa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            else
                btnPausa.BackColor = Color.Indigo;
            if (btnReanudar.Enabled == false)
                btnReanudar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            else
                btnReanudar.BackColor = Color.Indigo;
            if (btnSalida.Enabled == false)
                btnSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            else
                btnSalida.BackColor = Color.Indigo;

            //pinta horas
            if (fentrada != null)
            {
                lblentrada.Text = DateTime.Parse(fentrada.ToString()).ToString("HH:mm");
                lblentrada.Visible = true;
            }
            else
            {
                lblentrada.Text = "";
                lblentrada.Visible = false; 
            }
            if (fsalidad != null)
            {
                lblsalidadescanso.Text = DateTime.Parse(fsalidad.ToString()).ToString("HH:mm");
                lblsalidadescanso.Visible = true;
            }
            else
            {
                lblsalidadescanso.Text = "";
                lblsalidadescanso.Visible= false;   
            }
            if (fentradad != null)
            {
                lblentradadescando.Text = DateTime.Parse(fentradad.ToString()).ToString("HH:mm");
                lblentradadescando.Visible = true;
            }
            else
            {
                lblentradadescando.Text = "";
                lblentradadescando.Visible= false;
            }
            if (fsalida != null)
            {
                lblsalida.Text = DateTime.Parse(fsalida.ToString()).ToString("HH:mm");
                lblsalida.Visible = true;
            }
            else
            {
                lblsalida.Text = "";
                lblsalida.Visible= false;
            }
            //mensaje bienvenida.
            string nombre = dsUsuario.Tables[0].Rows[0]["Nombre"].ToString().Trim().Replace("Op.", "").TrimStart();
            int posicion = nombre.IndexOf(" ");
            if (posicion == -1)
                posicion = nombre.Length;
            nombre = nombre.Substring(0, posicion);
            nombre=nombre.Substring(0,1).ToUpper()+nombre.Substring(1).ToLower();
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 6)
                lblmesaje.Text = "!Buenas noches! " + nombre;
            else if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 14)
                    lblmesaje.Text = "!Buenos días! " + nombre;
            else if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour < 21)
                lblmesaje.Text = "!Buenas tardes! " + nombre;
            else
                lblmesaje.Text = "!Buenas noches! " + nombre;
        }
        private void GrabarFoto(string fichero)
        {
            CerrarCamara();
            timer2.Enabled = false;
            foto.Image.Save(ruta + fichero + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg", ImageFormat.Jpeg);
            foto.Image.Dispose();

            //vuelve a pedir login
            //this.Size = new Size(809, 428);   //login
            this.Size = new Size(809, 814);   //login
            panelcamara.Visible = false;
            panelfichaje.Visible = false;
            panellogin.Visible = true;
            btnAceptar.Enabled = true;

            GrabarFichaje();
        }
        private void btnEntrada_Click(object sender, EventArgs e)
        {
            fentrada = DateTime.Now;
            fentradad = null;
            fsalidad = null;
            fsalida= null;
            GrabarFoto("In");
        }

        private void btnReanudar_Click(object sender, EventArgs e)
        {
            fentradad = DateTime.Now;
            fsalida = null;
            GrabarFoto("Re");
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            fsalidad = DateTime.Now;
            fentradad = null;
            fsalida = null;
            GrabarFoto("Pa");
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            fsalida = DateTime.Now;
            GrabarFoto("Out");
        }
        private void CerrarCamara()
        {
            if (videoCapture != null && videoCapture.IsRunning)
            {
                videoCapture.SignalToStop();
                videoCapture = null;
            }
        }
        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            foto.Image = resizeImage(imagen, new Size(600, 400));
        }
        private Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void frmFichaje_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarCamara();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss");
            if(actual!= DateTime.Today) 
            {
                lbldia.Text = DateTime.Now.ToLongDateString();
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
                txtUsuario.Text = "";
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length == 0)
                txtUsuario.Text = "Usuario";
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "Contraseña")
            {
                txtClave.PasswordChar= '*';
                txtClave.Text = "";
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text.Length == 0)
            {
                txtClave.PasswordChar = '\0';
                txtClave.Text = "Contraseña";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CerrarCamara();
            timer2.Enabled= false;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(cadenaConexion);
        }
        private DataSet Login(string user, string pass)
        {
            string cadena = "Select * from Usuarios where Login=@user and Clave=@pass and fechabaja is null";
            DataSet ds = new DataSet();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = cadena;
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        private DataSet Buscar()
        {
            string cadena = "Select top 1 * from CentrosFichajes where IDUsuario=" + dsUsuario.Tables[0].Rows[0]["IDUsuario"].ToString() + " Order by IDFichaje desc";
            DataSet ds = new DataSet();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = cadena;
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        internal int GrabarFichaje()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CentrosFichajesActualizar";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    command.Parameters.Add("@IDFichaje", SqlDbType.Int, 4).Value = lIDFichaje;
                    command.Parameters.Add("@IDUsuario", SqlDbType.Int, 4).Value = (int)dsUsuario.Tables[0].Rows[0]["IDUsuario"];
                    command.Parameters.Add("@FechaEntrada", SqlDbType.DateTime).Value = (DateTime)fentrada;
                    if (fsalidad != null)
                        command.Parameters.Add("@FechaSalidaDescanso", SqlDbType.DateTime).Value = fsalidad;
                    else
                        command.Parameters.Add("@FechaSalidaDescanso", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                    if (fentradad != null)
                        command.Parameters.Add("@FechaEntradaDescanso", SqlDbType.DateTime).Value = fentradad;
                    else
                        command.Parameters.Add("@FechaEntradaDescanso", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                    if (fsalida != null)
                        command.Parameters.Add("@FechaSalida", SqlDbType.DateTime).Value = fsalida;
                    else
                        command.Parameters.Add("@FechaSalida", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                    return (int)command.ExecuteNonQuery();
                }
            }
        }
    }
}
