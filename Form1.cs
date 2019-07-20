using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string kelime;
        string[] isimler = { "gizem", "cihan", "mustafa", "furkan", "rümeysa", "barış", "mahsum", "gamze", "dilara", "ayşenur", "şilan", "mehmet", "muharrem", "agah", "zeynep", "beşir" };
        Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {          
            kelime = isimler[rnd.Next(0, isimler.Length)];
            foreach (char item in kelime)
            {
                Label lblHarf = new Label();
                lblHarf.AutoSize = true;
                lblHarf.Text = "_";
                lblHarf.Height = 20;
                lblHarf.Tag = item;
                flowLayoutPanel1.Controls.Add(lblHarf);
            }
        }

        private void btnCc_Click(object sender, EventArgs e)
        {
            textBox1.Text = ((Button)sender).Text.ToLower();
            ((Button)sender).Controls.Clear();
        }

        int hak = 5;

        private void btnDene_Click(object sender, EventArgs e)
        {
            bool bildiMi = false;
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                if (item is Label)
                {
                    for (int i = 0; i < kelime.Length; i++)
                    {
                        if (textBox1.Text.Equals(item.Tag.ToString(), StringComparison.Ordinal))
                        {
                            item.Text = item.Tag.ToString();
                            lblKalanHak.Text = hak.ToString();
                            bildiMi = true;
                        }
                    }
                }
            }
            if (!bildiMi)
            {
                hak--;
                bildiMi = false;
                lblKalanHak.Text = hak.ToString();
            }
            if (hak == 0)
            {
                MessageBox.Show("kaybettiniz");
                this.Close();
            }
            int sayi = 0;
            foreach(Control item in flowLayoutPanel1.Controls)
            {
                if(item.Text!="_")
                {
                    sayi++;
                }
            }
            if(sayi==kelime.Length)
            {
                MessageBox.Show("kazandınız");
                this.Close();
            }
        }
    }
}


