using AForge.Video;
using AForge.Video.DirectShow;
using EnterpriseDT.Net.Ftp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace BoxHorario
{
    public partial class frmFichajeLector : Form
    {
        //Requena: https://www.softwarelogistica.es/BoxHorario/publish.htm
        //Athos Logistica: https://www.softwarelogistica.es/BoxHorarioLogistica/publish.htm
        //Athos Rail: https://www.softwarelogistica.es/BoxHorarioTerminal/publish.htm
        int lIDEmpresa = 3;     //1=Athos,2=requena,3=athos rail

        string cadenaConexion = "";

        int lIDFichaje = 0;
        DataSet dsUsuario = new DataSet();
        DataSet dsFichaje = new DataSet();

        DateTime factual = DateTime.Now;
        DateTime? fsalida, fpausafin, fpausainicio;
        DateTime fentrada = DateTime.Now;
        public frmFichajeLector()
        {
            InitializeComponent();
        }

        private void frmFichajeLector_Load(object sender, EventArgs e)
        {
            panel.Visible= false;
            if (lIDEmpresa == 1)    //athos
            {
                cadenaConexion = "Data Source=46.226.45.108;Initial Catalog=Box;;User ID=sa;password=2015villaL";
                picathos.Visible = true;
                picrequena.Visible = false;
                picathosrail.Visible = false;
            }
            else if (lIDEmpresa == 1)         //requena
            {
                cadenaConexion = "Data Source=46.226.45.133;Initial Catalog=RAIL;;User ID=sa;password=2015villaL*";
                picathos.Visible = false;
                picrequena.Visible = true;
                picathosrail.Visible = false;
            }
            else if (lIDEmpresa == 3)         //athos rail
            {
                cadenaConexion = "Data Source=46.226.45.133;Initial Catalog=RAIL;;User ID=sa;password=2015villaL*";
                picathos.Visible = false;
                picrequena.Visible = false;
                picathosrail.Visible = true;
            }
            txtLector.Focus();
        }

       
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtLector.Text.Length > 0 && ValidarInt(txtLector.Text))
            {
                string idusuario = txtLector.Text;
                dsUsuario = (DataSet)Login(int.Parse(idusuario), lIDEmpresa);
                if (dsUsuario.Tables[0].Rows.Count == 0)
                {
                    timer2.Enabled = true;
                    panel.Visible = true;
                    lblmesaje.Text = "Tarjeta no válida.";
                    Console.Beep(3000, 2000);
                }
                else
                {
                    Bienvenida();
                    factual = DateTime.Now;
                    lIDFichaje = 0;
                    btnAceptar.Enabled = false;
                    fsalida = null;
                    fpausafin = null;
                    fpausainicio = null;
                    lIDFichaje = 0;
                    //carga el ultimo fichaje
                    dsFichaje = (DataSet)Buscar(int.Parse(idusuario));
                    //si no ha salido
                    if (dsFichaje.Tables[0].Rows.Count > 0 && dsFichaje.Tables[0].Rows[0]["FechaSalida"] == DBNull.Value)
                    {
                        lIDFichaje = (int)dsFichaje.Tables[0].Rows[0]["IDFichaje"];

                        if (lIDEmpresa == 1)
                        {
                            if (dsFichaje.Tables[0].Rows[0]["FechaSalidaDescanso"] != DBNull.Value)
                                fpausainicio = (DateTime)dsFichaje.Tables[0].Rows[0]["FechaSalidaDescanso"];
                            if (dsFichaje.Tables[0].Rows[0]["FechaEntradaDescanso"] != DBNull.Value)
                                fpausafin = (DateTime)dsFichaje.Tables[0].Rows[0]["FechaEntradaDescanso"];
                        }
                        else
                        {
                            if (dsFichaje.Tables[0].Rows[0]["FechaPausaInicio"] != DBNull.Value)
                                fpausainicio = (DateTime)dsFichaje.Tables[0].Rows[0]["FechaPausaInicio"];
                            if (dsFichaje.Tables[0].Rows[0]["FechaPausaFin"] != DBNull.Value)
                                fpausafin = (DateTime)dsFichaje.Tables[0].Rows[0]["FechaPausaFin"];
                        }

                        //calcula horas desde fecha entrada.
                        fentrada = (DateTime)dsFichaje.Tables[0].Rows[0]["FechaEntrada"];
                        TimeSpan horas = factual.Subtract(fentrada);

                        //calcula fechas
                        if (fpausafin != null)
                        {
                            //salida turno
                            fsalida = factual;
                        }
                        else if (fpausainicio != null)
                        {
                            //fin pausa si menos < 7H
                            if (horas.Hours < 7)
                                fpausafin = factual;
                            else
                                fsalida = factual;
                        }
                        else
                        {
                            //fin pausa si menos < 7H
                            if (horas.Hours < 7)
                                fpausainicio = factual;
                            else
                                fsalida = factual;
                        }
                        //muestra datos
                        lblentrada.Text = DateTime.Parse(fentrada.ToString()).ToString("HH:mm");
                        lblentrada.Visible = true;
                        if (fpausainicio != null)
                        {
                            lblpausainicio.Text = DateTime.Parse(fpausainicio.ToString()).ToString("HH:mm");
                            lblpausainicio.Visible = true;
                        }
                        if (fpausafin != null)
                        {
                            lblpausafin.Text = DateTime.Parse(fpausafin.ToString()).ToString("HH:mm");
                            lblpausafin.Visible = true;
                        }
                        if (fsalida != null)
                        {
                            lblsalida.Text = DateTime.Parse(fsalida.ToString()).ToString("HH:mm");
                            lblsalida.Visible = true;
                        }
                        Console.Beep(1500, 100);
                    }
                    else
                    {
                        lIDFichaje = 0;
                        fentrada = factual;
                        Console.Beep(1500, 100);
                    }
                    GrabarFichaje();
                    btnAceptar.Enabled = true;
                }
            }
            else
                Console.Beep(3000, 2000);
            txtLector.Text = "";
            txtLector.Focus();
        }
       
        internal void GrabarFichaje()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    if (lIDEmpresa == 1)
                        command.CommandText = "CentrosFichajesActualizar";
                    else
                        command.CommandText = "FichajesActualizar";
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    command.Parameters.Add("@IDFichaje", SqlDbType.Int, 4).Value = lIDFichaje;
                    command.Parameters.Add("@IDUsuario", SqlDbType.Int, 4).Value = (int)dsUsuario.Tables[0].Rows[0]["IDUsuario"];
                    command.Parameters.Add("@FechaEntrada", SqlDbType.DateTime).Value = (DateTime)fentrada;
                    if (fsalida != null)
                        command.Parameters.Add("@FechaSalida", SqlDbType.DateTime).Value = fsalida;
                    else
                        command.Parameters.Add("@FechaSalida", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;

                    if (lIDEmpresa == 1)
                    {
                        if (fpausainicio != null)
                            command.Parameters.Add("@FechaSalidaDescanso", SqlDbType.DateTime).Value = fpausainicio;
                        else
                            command.Parameters.Add("@FechaSalidaDescanso", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                        if (fpausafin != null)
                            command.Parameters.Add("@FechaEntradaDescanso", SqlDbType.DateTime).Value = fpausafin;
                        else
                            command.Parameters.Add("@FechaEntradaDescanso", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                    }
                    else if (lIDEmpresa == 2)
                    {
                        if (fpausainicio != null)
                            command.Parameters.Add("@FechaPausaInicio", SqlDbType.DateTime).Value = fpausainicio;
                        else
                            command.Parameters.Add("@FechaPausaInicio", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                        if (fpausafin != null)
                            command.Parameters.Add("@FechaPausaFin", SqlDbType.DateTime).Value = fpausafin;
                        else
                            command.Parameters.Add("@FechaPausaFin", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                    }
                    command.ExecuteNonQuery();
                }
            }
        }
        private DataSet Login(int idusuario, int idempresa)
        {
            string cadena = "select * from usuarios where IDUsuario=" + idusuario + " and FechaBaja Is null";
            if (idempresa == 1) //athos logistica
                cadena += " and IDEmpresa=9";
            else if (idempresa == 2) //requena
                cadena += " and IDEmpresa=1";
            else if (idempresa == 3) //athos rail
                cadena += " and IDEmpresa=2";

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
        private DataSet Buscar(int idusuario)
        {
            string cadena = "";
            if (lIDEmpresa == 1)
                cadena = "Select top 1 * from CentrosFichajes where IDUsuario=" + idusuario + " Order by IDFichaje desc";
            else
                cadena = "Select top 1 * from Fichajes where IDUsuario=" + idusuario + "  Order by IDFichaje desc";

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
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(cadenaConexion);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel.Visible)
            {
                lblmesaje.Text = "";
                lblentrada.Text = "";
                lblpausafin.Text = "";
                lblpausainicio.Text = "";
                lblsalida.Text = "";
                panel.Visible = false;
                timer2.Enabled = false;
            }
        }

        private void Bienvenida()
        {
            panel.Visible = true;
            timer2.Enabled = true;
            string nombre = dsUsuario.Tables[0].Rows[0]["Nombre"].ToString().Trim().Replace("Op.", "").TrimStart();
            int posicion = nombre.IndexOf(" ");
            if (posicion == -1)
                posicion = nombre.Length;
            nombre = nombre.Substring(0, posicion);
            nombre = nombre.Substring(0, 1).ToUpper() + nombre.Substring(1).ToLower();
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 6)
                lblmesaje.Text = "!Buenas noches! " + nombre;
            else if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 14)
                lblmesaje.Text = "!Buenos días! " + nombre;
            else if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour < 21)
                lblmesaje.Text = "!Buenas tardes! " + nombre;
            else
                lblmesaje.Text = "!Buenas noches! " + nombre;
        }
        private bool ValidarInt(string numero)
        {
            if (numero.Length == 0)
            {
                return false;
            }
            else
            {
                try
                {
                    int num = Convert.ToInt32(numero);
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }
    }
}
