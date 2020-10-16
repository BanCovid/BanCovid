using Core.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreVisual
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn2Cls_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn2Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void myTimer3_Tick(object sender, EventArgs e)
        {
            lblTimer3.Text = DateTime.Now.ToLongDateString();
        }

        private void Cliente_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void Cliente_Load(object sender, EventArgs e)
        {
            myTimer3.Enabled = true;
            await Task.Delay(8000);
            PBCliente.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //SqlConnection SQL = new SqlConnection();
            //SQL.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            //SQL.Open();
            //SqlCommand Command = new SqlCommand();
            //Command.Connection = SQL;
            //Command.CommandText = "ppUpdate";
            //Command.CommandType = CommandType.StoredProcedure;

            if (txtDir.Text != "DIRECCIÓN" && txtID.Text != "ID")
            {
                //Command.Parameters.AddWithValue("@Nombre", txtDir.Text);
                //Command.Parameters.AddWithValue("@Apellido", txtID.Text);
                //Command.Parameters.AddWithValue("@Cedula", txtC.Text);
                //Command.Parameters.AddWithValue("@Telefono", txtTel.Text);
                //Command.ExecuteNonQuery();
                try
                {
                    var Servicio = new ClienteServicios();
                    Servicio.Editar(new Core.ModeloData.Tbl_Cliente
                    {
                        Direccion = txtDir.Text,
                        Id = int.Parse(txtID.Text)

                    });
                    MessageBox.Show("Successfully Updated");
                }
                catch (Exception err)
                {

                    MessageBox.Show($"Error: {err}");
                    
                }
                
                Reset();
            }
            else
            {

                if (txtDir.Text == "DIRECCIÓN")
                {
                    msgError("Nombre no encontrado");
                }
                else
                {
                    lblErrorMessage.Visible = false;
                }
                if (txtID.Text == "ID")
                {
                    msgError2("Apellido no encontrado");
                }
                else
                {
                    lblErrorMessage2.Visible = false;
                }
               
            }
        }
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "          " + msg;
            lblErrorMessage.Visible = true;
        }
        private void msgError2(string msg)
        {
            lblErrorMessage2.Text = "          " + msg;
            lblErrorMessage2.Visible = true;
        }
      

        void Reset()
        {

            txtDir.Text = "DIRECCIÓN";
            txtID.Text = "ID";
        }

        private void txtN_Enter(object sender, EventArgs e)
        {
            if (txtDir.Text == "DIRECCIÓN")
            {
                txtDir.Text = "";
                txtDir.ForeColor = Color.LightGray;
            }
        }

        private void txtN_Leave(object sender, EventArgs e)
        {
            if (txtDir.Text == "")
            {
                txtDir.Text = "DIRECCIÓN";
                txtDir.ForeColor = Color.DimGray;
            }
        }

        private void txtLN_Enter(object sender, EventArgs e)
        {
            if (txtID.Text == "ID")
            {
                txtID.Text = "";
                txtID.ForeColor = Color.LightGray;
            }
        }

        private void txtLN_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                txtID.Text = "ID";
                txtID.ForeColor = Color.DimGray;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 FormUser = new Form1();
            FormUser.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Caja FormCaja = new Caja();
            FormCaja.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //SqlConnection SQL = new SqlConnection();
            //SQL.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            //SQL.Open();
            //SqlCommand Command = new SqlCommand();
            //Command.Connection = SQL;
            //Command.CommandText = "ppSearch";
            //Command.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter dataAdapter = new SqlDataAdapter();
            //dataAdapter.SelectCommand = Command;
            //DataTable data = new DataTable();
            //dataAdapter.Fill(data);
            //dGV1.DataSource = data;
            var Servicio = new ClienteServicios();
            dGV1.DataSource = Servicio.ObtenerTodos().Select(x => new {
             x.Id,
             x.Direccion,
            x.FechaCreacion
            
            }).ToList(); 
        }
    }
}
