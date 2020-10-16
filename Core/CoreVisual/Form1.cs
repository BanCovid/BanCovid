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
using System.Threading;
using Core.Servicios;

namespace CoreVisual
{
    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void label4_Click(object sender, EventArgs e)
        {

        }

    
        private async void Form1_Load(object sender, EventArgs e)
        {
            myTimer.Enabled = true;
            await Task.Delay(8000);
            PBWELCOME.Visible = false;
          
        }

        private void txtN_Enter(object sender, EventArgs e)
        {
            if(txtN.Text == "NOMBRE")
            {
                txtN.Text = "";
                txtN.ForeColor = Color.LightGray;
            }
        }

        private void txtN_Leave(object sender, EventArgs e)
        {
            if(txtN.Text == "")
            {
                txtN.Text = "NOMBRE";
                txtN.ForeColor = Color.DimGray;
            }
        }

        private void txtLN_Enter(object sender, EventArgs e)
        {
            if(txtLN.Text == "APELLIDO")
            {
                txtLN.Text = "";
                txtLN.ForeColor = Color.LightGray;
            }
        }

        private void txtLN_Leave(object sender, EventArgs e)
        {
            if (txtLN.Text == "")
            {
                txtLN.Text = "APELLIDO";
                txtLN.ForeColor = Color.DimGray;
            }
        }

        private void txtC_Leave(object sender, EventArgs e)
        {
            if (txtC.Text == "")
            {
                txtC.Text = "CÉDULA";
                txtC.ForeColor = Color.DimGray;
            }
        }

        private void txtC_Enter(object sender, EventArgs e)
        {
            if (txtC.Text == "CÉDULA")
            {
                txtC.Text = "";
                txtC.ForeColor = Color.LightGray;
            }
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            if (txtTel.Text == "")
            {
                txtTel.Text = "TELÉFONO";
                txtTel.ForeColor = Color.DimGray;
            }
        }

        private void txtTel_Enter(object sender, EventArgs e)
        {
            if (txtTel.Text == "TELÉFONO")
            {
                txtTel.Text = "";
                txtTel.ForeColor = Color.LightGray;
            }
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
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
            var Servicio = new UsuariosServicio();
            //dataAdapter.Fill(data);
            dGV1.DataSource = Servicio.ObtenerTodos().Select(x => new {
                x.Id,
                x.Nombre,
                x.Apellido,
                x.Telefono,
                x.Cedula,
                x.UserName,
                x.Password,
                x.Perfil_Id,
                x.Estado

            }).ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //SqlConnection SQL = new SqlConnection();
            //SQL.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            //SQL.Open();
            //SqlCommand Command = new SqlCommand();
            //Command.Connection = SQL;
            //Command.CommandText = "ppDelete";
            //Command.CommandType = CommandType.StoredProcedure;
            //Command.Parameters.AddWithValue("@Cedula", txtC.Text);
            //Command.ExecuteNonQuery();
            //MessageBox.Show("Successfully Deleted");

            var Servicio = new UsuariosServicio();
           Servicio.Eliminar(int.Parse(txtID.Text));
            MessageBox.Show("Successfully Deleted");
            txtID.Text = "ID";
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
            //Command.Parameters.AddWithValue("@Nombre", txtN.Text);
            //Command.Parameters.AddWithValue("@Apellido", txtLN.Text);
            //Command.Parameters.AddWithValue("@Cedula", txtC.Text);
            //Command.Parameters.AddWithValue("@Telefono", txtTel.Text);
            //Command.ExecuteNonQuery();
            var Servicio = new UsuariosServicio();
            Servicio.Editar(new Core.ModeloData.Tbl_Usuario
            {
                 
                UserName = txtUserName.Text,
                Password = txtPass.Text,
                Nombre = txtN.Text,
                Apellido = txtLN.Text,
                Telefono = txtTel.Text,
                Id = int.Parse(txtID.Text)

            });
            MessageBox.Show("Successfully Updated");
            Reset();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //SqlConnection SQL = new SqlConnection();
            //SQL.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            //SQL.Open();
            //SqlCommand Command = new SqlCommand();
            //Command.Connection = SQL;
            //Command.CommandText = "ppInsert";
            //Command.CommandType = CommandType.StoredProcedure;

            if (txtN.Text != "NOMBRE" && txtLN.Text != "APELLIDO" && txtC.Text != "CÉDULA" && txtTel.Text != "TELÉFONO")
            {
                //2--> Usuario caja, 3--> Usuario cliente
                //PerfilID,Password,Username

                //Command.Parameters.AddWithValue("@Nombre", txtN.Text);
                //Command.Parameters.AddWithValue("@Apellido", txtLN.Text);
                //Command.Parameters.AddWithValue("@Cedula", txtC.Text);
                //Command.Parameters.AddWithValue("@Telefono", txtTel.Text);
                //Command.ExecuteNonQuery();
                var Servicio = new UsuariosServicio();
                Servicio.Crear(new Core.ModeloData.Tbl_Usuario { 
                Nombre = txtN.Text,
                Apellido = txtLN.Text,
                Cedula = txtC.Text,
                Telefono = txtTel.Text,
                UserName = txtUserName.Text,
                Password = txtPass.Text,
                Perfil_Id = short.Parse(txtPFID.Text)
                });

                MessageBox.Show("Successfully Saved");
                Reset();
            }
            else
            {

                if (txtN.Text == "NOMBRE") {
                    msgError("Nombre no encontrado");
                }
                else
                {
                    lblErrorMessage.Visible = false;
                }
                if (txtLN.Text == "APELLIDO")
                {
                    msgError2("Apellido no encontrado");
                }
                else
                {
                    lblErrorMessage2.Visible = false;
                }
                if (txtC.Text == "CÉDULA")
                {
                    msgError3("Cédula no encontrada");
                }else
                {
                    lblErrorMessage3.Visible = false;

                }
                if (txtTel.Text == "TELÉFONO")
                {
                    msgError4("Teléfono no encontrado");
                }else
                {
                    lblErrorMessage4.Visible = false;

                }
                if (txtUserName.Text == "USERNAME")
                {
                    msgError5("Username no encontrado");
                }
                else
                {
                    lblErrorMessage5.Visible = false;

                }
                if (txtPass.Text == "PASSWORD")
                {
                    msgError6("Password no encontrado");
                }
                else
                {
                    lblErrorMessage6.Visible = false;

                }
                if (txtPFID.Text == "PERFIL_ID")
                {
                    msgError7("Perfil_ID no encontrado");
                }
                else
                {
                    lblErrorMessage7.Visible = false;

                }

            }
        }

        void Reset()
        {

            txtN.Text = "NOMBRE";
            txtLN.Text = "APELLIDO";
            txtC.Text = "CÉDULA";
            txtTel.Text = "TELÉFONO";
            txtPass.Text = "PASSWORD";
            txtPFID.Text = "PERFIL_ID";
            txtUserName.Text = "USERNAME";
            txtID.Text = "ID";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
        private void msgError4(string msg)
        {
            lblErrorMessage4.Text = "          " + msg;
            lblErrorMessage4.Visible = true;
        }
        private void msgError5(string msg)
        {
            lblErrorMessage5.Text = "          " + msg;
            lblErrorMessage5.Visible = true;
        }
        private void msgError6(string msg)
        {
            lblErrorMessage6.Text = "          " + msg;
            lblErrorMessage6.Visible = true;
        }
        private void msgError7(string msg)
        {
            lblErrorMessage7.Text = "          " + msg;
            lblErrorMessage7.Visible = true;
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToLongDateString();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Caja CajaForm = new Caja();
            CajaForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cliente ClienteForm = new Cliente();
            ClienteForm.Show();
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "USERNAME")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.LightGray;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "USERNAME";
                txtUserName.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "PASSWORD")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "PASSWORD";
                txtPass.ForeColor = Color.DimGray;
            }
        }

        private void txtPFID_Enter(object sender, EventArgs e)
        {
            if (txtPFID.Text == "PERFIL_ID")
            {
                txtPFID.Text = "";
                txtPFID.ForeColor = Color.LightGray;
            }
        }

        private void txtPFID_Leave(object sender, EventArgs e)
        {
            if (txtPFID.Text == "")
            {
                txtPFID.Text = "PERFIL_ID";
                txtPFID.ForeColor = Color.DimGray;
            }
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            if (txtID.Text == "ID")
            {
                txtID.Text = "";
                txtID.ForeColor = Color.LightGray;
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                txtID.Text = "ID";
                txtID.ForeColor = Color.DimGray;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
