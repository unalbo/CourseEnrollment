using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DersKayit.ENTITY;
using DersKayit.BLL;

namespace DersKayit.PRESANTATION
{
    public partial class Form2 : Form
    {
        EOGRENCI ogrenci;

        internal EOGRENCI Ogrenci
        {
            get { return ogrenci; }
            set { ogrenci = value; }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;

        public Form2(Form form1)
        {
            mainForm = form1 as Form1;
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            Ogrenci = this.mainForm.Ogrenci;
            label12.Text = Ogrenci.AD1;
            label13.Text = Ogrenci.SOYAD1;
            label14.Text = Ogrenci.OKULNO1;
            label15.Text = Ogrenci.TCKIMLIKNO1;
            label16.Text = BIL.Select(Ogrenci.DOGUMYERI1).IL1.ToString();
            label17.Text = Ogrenci.DOGUMTARIHI1.ToString();
            label18.Text = Ogrenci.KAYITTARIHI1.ToString();
            label19.Text = BOGRENCITURU.Select(Ogrenci.OGRENCITURU1).TUR1.ToString();
            label20.Text = BPROGRAM.Select(Ogrenci.BOLUM1).PROGRAM1.ToString();
            textBox1.Text = Ogrenci.MAIL1;
            textBox2.Text = Ogrenci.SIFRE1;

            fillScoreAndRecordedCourse();

            List<EACILANDERSLERVIEW> acilanDersler = new List<EACILANDERSLERVIEW>();
            acilanDersler = BACILANDERSLER.SelectList();
            dataGridView3.DataSource = acilanDersler;
            dataGridView3.Columns[0].Visible = false;
            //dataGridView3.Columns[10].Visible = false;
        }

        private void fillScoreAndRecordedCourse()
        {
            List<ENOTLAR> notlar = new List<ENOTLAR>();
            notlar = BNOTLAR.Select(Ogrenci.ID1);
            List<EDERSLER> dersler = new List<EDERSLER>();
            if (notlar != null)
            {
                foreach (ENOTLAR not in notlar)
                {
                    not.DERSID1 = BACILANDERSLER.Select(not.ACILANDERS1).ID1;
                    EDERSLER ders = new EDERSLER();
                    ders = BDERSLER.Select(not.DERSID1);
                    not.DERSADI1 = ders.DERS1;
                    dersler.Add(ders);
                }

                dataGridView1.DataSource = notlar;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[8].Visible = false;


                dataGridView2.DataSource = dersler;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[3].Visible = false;
                dataGridView2.Columns[4].Visible = false;
                dataGridView2.Columns[5].Visible = false;
                dataGridView2.Columns[6].Visible = false;
                dataGridView2.Columns[7].Visible = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ogrenci.MAIL1 = textBox1.Text;
            Ogrenci.SIFRE1 = textBox2.Text;
            int guncellenen = BOGRENCI.Update(Ogrenci);
            if (guncellenen == 1)
                MessageBox.Show("Kayıt Güncellendi");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                EKAYITLIDERS ders = new EKAYITLIDERS();
                ders.OGRENCIID1 = Ogrenci.ID1;
                ders.DERSID1 = Convert.ToInt32(row.Cells[0].Value);
                int bolumID = Convert.ToInt32(row.Cells[10].Value);
                if(Ogrenci.BOLUM1 == Convert.ToInt32(row.Cells[10].Value))
                {
                    int sonuc = BKAYITLIDERS.Insert(ders);
                    fillScoreAndRecordedCourse();
                }
                else
                {
                    MessageBox.Show("Dersi ALabilen Programlara Dahil Değilsiniz!");
                }
                    
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView2.SelectedRows)
            {
                int dersID = Convert.ToInt32(row.Cells[0].Value);
                EACILANDERSLER acilanDers = new EACILANDERSLER();
                acilanDers = BACILANDERSLER.Select(dersID);
                int durum = BNOTLAR.Delete(acilanDers.ID1);
                if (durum == 0)
                    MessageBox.Show("Ders Bırakma Zamanı Geçmiştir!");
            }
            fillScoreAndRecordedCourse();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmam İstediğinize Emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
