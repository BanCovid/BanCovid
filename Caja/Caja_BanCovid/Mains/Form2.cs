using Caja_BanCovid.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caja_BanCovid
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            var modelo = new {UserName = txtUSER.Text, Password = txtPASS.Text};

            var json = JsonConvert.SerializeObject(modelo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{Configuration.DefR}/usuarios/IniciarSesion", data);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var objet = JsonConvert.DeserializeObject(content);
                Configuration.Usr = objet;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                Error error = new Error();
                error.ShowDialog();
            }
        }
    }
}
