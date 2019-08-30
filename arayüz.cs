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

namespace emlak_kayıt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        SqlConnection bag = new SqlConnection("Data Source=MEDELL\\SQLEXPRESS;Initial Catalog=emlak;Integrated Security=True");
        private void göster ()
        {
            listView1.Items.Clear();
            bag.Open();
            SqlCommand komut = new SqlCommand("Select* From gayrımenkul", bag);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkıra"].ToString());
                listView1.Items.Add(ekle);
            }
            bag.Close();
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (site .Text == "güven ")
            {
                button1.BackColor = Color.Red;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }

            if (site.Text == "yalın")
            {
                button2.BackColor = Color.Yellow ;
                button1.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }

            if (site.Text == "çiçek ")
            {
                button3.BackColor = Color.Blue ;
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }

            if (site.Text == "bülbül")
            {
                button4.BackColor = Color.Green ;
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            göster();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand sv = new SqlCommand("insert into gayrımenkul(id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkıra) values( '" + id.Text.ToString() + "','" + site.Text.ToString() + "','" + odasayısı.Text.ToString() + "','" + metrekare.Text.ToString() + "','" + fiyat.Text.ToString() + "','" + blok.Text.ToString() + "','" + no.Text.ToString() + "','" + adsoyad.Text.ToString() + "','" + telefon.Text.ToString() + "','" + notlar.Text.ToString() + "','" + satkıra.Text.ToString() + "')", bag);
            sv.ExecuteNonQuery();
            bag.Close();
            göster();
          
          


        }
        int adet = 0;
        public   void Button7_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("Delete from gayrımenkul where id=(" + adet + ")", bag);
            komut.ExecuteNonQuery();
            bag.Close();
            göster();
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            adet = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            id.Text = listView1.SelectedItems[0].SubItems[0].Text;
            site.Text = listView1.SelectedItems[0].SubItems[1].Text;
            odasayısı .Text = listView1.SelectedItems[0].SubItems[2].Text;
            metrekare .Text = listView1.SelectedItems[0].SubItems[3].Text;
            fiyat .Text = listView1.SelectedItems[0].SubItems[4].Text;
            blok .Text = listView1.SelectedItems[0].SubItems[5].Text;
            no.Text = listView1.SelectedItems[0].SubItems[6].Text;
            adsoyad .Text = listView1.SelectedItems[0].SubItems[7].Text;
            telefon .Text = listView1.SelectedItems[0].SubItems[8].Text;
            notlar .Text = listView1.SelectedItems[0].SubItems[9].Text;
            satkıra.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("update gayrımenkul set id='" + id.Text.ToString() + "',site='" + site.Text.ToString() + "',oda='" + odasayısı.Text.ToString() + "',metre='" + metrekare.Text.ToString() + "',fiyat='" + fiyat.Text.ToString() + "',blok='" + blok.Text.ToString() + "',no='" + no.Text.ToString() + "',adsoyad='" + adsoyad.Text.ToString() + "',telefon='" + telefon.Text.ToString() + "',notlar='" + notlar.Text.ToString() + "',satkıra='" + satkıra.Text.ToString() + "' where id=" + adet + "", bag);
            komut.ExecuteNonQuery();
            bag.Close();
            göster();
        }
    }
}
