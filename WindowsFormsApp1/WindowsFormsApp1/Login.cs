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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\ProjeDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataReader dr;
        SqlCommand komut;

        private void button2_Click(object sender, EventArgs e)
        {
            kullanicitb.Text = "";
            sifretb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici = kullanicitb.Text;
            string sifre = sifretb.Text;

            komut = new SqlCommand();
            baglanti.Open();

            komut.Connection = baglanti;
            komut.CommandText = "select * from kullanicitbl where kul_ad='"+kullanici+"' AND kul_sifre='" + sifre+"'";
            dr = komut.ExecuteReader();

            if(dr.Read())
            {
                AnaSayfa anaSayfa = new AnaSayfa();
                anaSayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
            baglanti.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
