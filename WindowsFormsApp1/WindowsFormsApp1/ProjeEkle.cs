using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class ProjeEkle : Form
    {
        public ProjeEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\ProjeDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void ProjeEkle_Load(object sender, EventArgs e)
        {

        }

        private void eklebtn_Click(object sender, EventArgs e)
        {
            if(basliktb.Text == ""|| tutartb.Text == "" || tarihtb.Text == "" || adsoyadtb.Text == "" || teltb.Text == "" || mailtb.Text == "")
            {
                MessageBox.Show("Eksik bilgi!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "insert into projetbl values('"+basliktb.Text+ "','"+tutartb.Text+ "','"+tarihtb.Text+ "','"+adsoyadtb.Text+ "','"+teltb.Text+ "','"+mailtb.Text+"')";
                    SqlCommand komut = new SqlCommand(sorgu,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Proje başarıyla eklendi");
                    baglanti.Close();
                    basliktb.Text = "";
                    tutartb.Text = "";
                    tarihtb.Text = "";
                    adsoyadtb.Text = "";
                    teltb.Text = "";
                    mailtb.Text = "";
                }
                catch(Exception Ex) 
                {
                    MessageBox.Show("Ex.Message");
                }
            }
                    
                    
        }

        private void sifirlabtn_Click(object sender, EventArgs e)
        {
            basliktb.Text = "";
            tutartb.Text = "";
            tarihtb.Text = "";
            adsoyadtb.Text = "";
            teltb.Text = "";
            mailtb.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void geribtn_Click(object sender, EventArgs e)
        {
            Login log = new Login();  
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
