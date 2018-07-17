using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DersKayit.BLL;
using DersKayit.ENTITY;
using DersKayit.PRESANTATION;

namespace DersKayit
{
    public partial class Form1 : Form
    {
        EOGRENCI ogrenci;
        EOGRETIMGOREVLISI ogretimGorevlisi;

        internal EOGRENCI Ogrenci
        {
            get { return ogrenci; }
            set { ogrenci = value; }
        }

        internal EOGRETIMGOREVLISI OgretimGorevlisi
        {
            get { return ogretimGorevlisi; }
            set { ogretimGorevlisi = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numara = textBox1.Text;
            string sifre = textBox2.Text;
            ogrenci = new EOGRENCI();
            ogrenci = BOGRENCI.Select(numara, sifre);
            ogretimGorevlisi = new EOGRETIMGOREVLISI();
            ogretimGorevlisi = BOGRETIMGOREVLISI.Select(numara, sifre);
            if (ogrenci != null)
            {
                Form2 frm2 = new Form2(this);
                frm2.ShowDialog();
            }
            else if (ogretimGorevlisi != null)
            {
                Form3 frm3 = new Form3(this);
                frm3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Okul Numaranız veya Şifreniz Hatalı!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
