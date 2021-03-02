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

namespace huzur_evi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=.;Initial Catalog=huzurevi;Integrated Security=True");
        private void verilerigörüntüle()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *From personel", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["tcno"].ToString());
                ekle.SubItems.Add(oku["telno"].ToString());
                ekle.SubItems.Add(oku["bolum"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        int id = 0;
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into personel(adsoyad,tcno,telno,bolum)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete From personel where id =(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("UPDATE personel SET  adsoyad='" + textBox1.Text.ToString() + "',tcno='" + textBox2.Text.ToString() + "',telno='" + textBox3.Text.ToString() + "',bolum='" + comboBox1.Text.ToString() + "'where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.aile.gov.tr/");
        }
    }
}
