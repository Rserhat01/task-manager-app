using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ProjeleriGoruntule : Form
    {
        public ProjeleriGoruntule()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\ProjeDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void projeler()
        {
            baglanti.Open();
            string sorgu = "select * from projetbl";
            SqlDataAdapter sda = new SqlDataAdapter(sorgu,baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            projedgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void projefiltrele()
        {
            baglanti.Open();
            string sorgu = "select * from projetbl where mus_ad='" + aramatb.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sorgu,baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            projedgv.DataSource= ds.Tables[0];
            baglanti.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProjeleriGoruntule_Load(object sender, EventArgs e)
        {
            projeler();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            projeler();
        }

        private void arabtn_Click(object sender, EventArgs e)
        {
            projefiltrele();
        }
    }
}
