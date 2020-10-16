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
    public partial class Caja : Form
    {
        public Caja()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void btn2Cls_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn2Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void Caja_Load(object sender, EventArgs e)
        {
            myTimer2.Enabled = true;
            await Task.Delay(8000);
            PBCashBox.Visible = false;
        }

        private void Caja_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void myTimer2_Tick(object sender, EventArgs e)
        {
            lblTimer2.Text = DateTime.Now.ToLongDateString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

            if (txtD.Text != "DESCRIPCIÓN" && txtM.Text != "MONTO" && txtID.Text != "ID")
            {
                //Command.Parameters.AddWithValue("@Nombre", txtD.Text);
                //Command.Parameters.AddWithValue("@Apellido", txtM.Text);
                //Command.Parameters.AddWithValue("@Cedula", txtID.Text);
                //Command.Parameters.AddWithValue("@Telefono", txtTel.Text);
                //Command.ExecuteNonQuery();

                var Servicio = new CajaServicio();
                Servicio.Editar(new Core.ModeloData.Tbl_Caja
                {
                    Descripcion = txtD.Text,
                    Id = int.Parse(txtID.Text),
                    Monto = decimal.Parse(txtM.Text)
                });

                MessageBox.Show("Successfully Updated");
                Reset();
            }
            else
            {

                if (txtD.Text == "DESCRIPCIÓN")
                {
                    msgError("Descripción no encontrada");
                }
                else
                {
                    lblErrorMessage.Visible = false;
                }
                if (txtM.Text == "MONTO")
                {
                    msgError2("Monto no encontrado.");
                }
                else
                {
                    lblErrorMessage2.Visible = false;
                }
                if (txtID.Text == "ID")
                {
                    msgError3("iD no encontrado");
                }
                else
                {
                    lblErrorMessage3.Visible = false;

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
        private void msgError3(string msg)
        {
            lblErrorMessage3.Text = "          " + msg;
            lblErrorMessage3.Visible = true;
        }
        

        void Reset()
        {

            txtD.Text = "DESCRIPCIÓN";
            txtM.Text = "MONTO";
            txtID.Text = "ID";
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

            var Servicio = new CajaServicio();
            dGV1.DataSource = Servicio.ObtenerTodos().Select(x => new {
                x.Id,
                x.Descripcion,
                x.Monto,
                x.FechaCreacion,
                x.Estado

            }).ToList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 FormUser = new Form1();
            FormUser.Show();
        }

        private void txtN_Enter(object sender, EventArgs e)
        {
            if(txtD.Text == "DESCRIPCIÓN")
            {
                txtD.Text = "";
                txtD.ForeColor = Color.LightGray;
            }
        }

        private void txtN_Leave(object sender, EventArgs e)
        {
            if (txtD.Text == "")
            {
                txtD.Text = "DESCRIPCIÓN";
                txtD.ForeColor = Color.DimGray;
            }
        }

        private void txtLN_Enter(object sender, EventArgs e)
        {
            if (txtM.Text == "MONTO")
            {
                txtM.Text = "";
                txtM.ForeColor = Color.LightGray;
            }
        }

        private void txtLN_Leave(object sender, EventArgs e)
        {
            if (txtM.Text == "")
            {
                txtM.Text = "MONTO";
                txtM.ForeColor = Color.DimGray;
            }
        }

        private void txtC_Enter(object sender, EventArgs e)
        {
            if (txtID.Text == "ID")
            {
                txtID.Text = "";
                txtID.ForeColor = Color.LightGray;
            }
        }

        private void txtC_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                txtID.Text = "ID";
                txtID.ForeColor = Color.DimGray;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cliente ClienteForm = new Cliente();
            ClienteForm.Show();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
