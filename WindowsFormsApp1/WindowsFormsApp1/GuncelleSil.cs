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
    public partial class GuncelleSil : Form
    {
        public GuncelleSil()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\ProjeDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void projeler()
        {
            baglanti.Open();
            string sorgu = "select * from projetbl";
            SqlDataAdapter sda = new SqlDataAdapter(sorgu, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            projedgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GuncelleSil_Load(object sender, EventArgs e)
        {
            projeler();
        }

        int key = 0;

        private void projedgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            key = Convert.ToInt32(projedgv.SelectedRows[0].Cells[0].Value.ToString());
            basliktb.Text = projedgv.SelectedRows[0].Cells[1].Value.ToString();
            tutartb.Text = projedgv.SelectedRows[0].Cells[2].Value.ToString();
            tarihtb.Text = projedgv.SelectedRows[0].Cells[3].Value.ToString();
            adsoyadtb.Text = projedgv.SelectedRows[0].Cells[4].Value.ToString();
            teltb.Text = projedgv.SelectedRows[0].Cells[5].Value.ToString();
            mailtb.Text = projedgv.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0 || basliktb.Text == "" || tutartb.Text == "" || tarihtb.Text == "" || adsoyadtb.Text == "" || teltb.Text == "" || mailtb.Text == "")
            {
                MessageBox.Show("Lütfen tablodan satır seçimi yapını ve tekrar deneyiniz!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "update projetbl set proje_baslik = '"+basliktb.Text+ "',proje_tutar = '"+tutartb.Text+ "',proje_tarih = '"+tarihtb.Text+ "',mus_ad = '"+adsoyadtb.Text+ "',mus_tel = '"+teltb.Text+ "',mus_email = '"+mailtb.Text+"'where proje_id = "+key+";";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Proje başarıyla güncellendi!");
                    baglanti.Close();
                    projeler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            basliktb.Text = "";
            tutartb.Text = "";
            tarihtb.Text = "";
            adsoyadtb.Text = "";
            teltb.Text = "";
            mailtb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Silinecek projeyi seçin!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "delete from projetbl where proje_id=" + key + ";";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Proje başarıyla silindi!");
                    baglanti.Close();
                    projeler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
