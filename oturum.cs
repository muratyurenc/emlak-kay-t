using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emlak_kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string logın = textBox1.Text;
            string pass = textBox2.Text;
            if (logın==pass)
            {
                Form2 ekle = new Form2();
                ekle.Show();
                this.Hide();
            }
            else
            {
              MessageBox.Show("bilgileri konrol ediniz");
            }
        }
    }
}
