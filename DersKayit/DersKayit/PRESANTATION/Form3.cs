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
    public partial class Form3 : Form
    {
        EOGRETIMGOREVLISI ogretimGorevlisi;

        internal EOGRETIMGOREVLISI OgretimGorevlisi
        {
            get { return ogretimGorevlisi; }
            set { ogretimGorevlisi = value; }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;

        public Form3(Form form1)
        {
            mainForm = form1 as Form1;
            InitializeComponent();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            OgretimGorevlisi = this.mainForm.OgretimGorevlisi;
            fillTeacherInformation();
            fillCourseList();
            fillOpenedCourseList();
            fillEnterNote();
            fillBookList();
        }

        private void fillTeacherInformation()
        {
            label11.Text = OgretimGorevlisi.AD1;
            label12.Text = OgretimGorevlisi.SOYAD1;
            label13.Text = OgretimGorevlisi.OKULNO1;
            label14.Text = OgretimGorevlisi.TCKIMLIKNO1;
            label15.Text = OgretimGorevlisi.DOGUMYERI1;
            label16.Text = OgretimGorevlisi.DOGUMTARIHI1.ToString();
            label17.Text = OgretimGorevlisi.TURU1;
            label18.Text = OgretimGorevlisi.FAKULTE1;
            label19.Text = OgretimGorevlisi.UNVAN1;
            textBox1.Text = OgretimGorevlisi.SIFRE1;
        }

        private void fillCourseList()
        {
            List<EDERSLER> dersler = new List<EDERSLER>();
            dersler = BDERSLER.SelectList();
            dataGridView1.DataSource = dersler;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            comboBox6.DataSource = dersler;
            comboBox6.DisplayMember = "KODU1";
            comboBox6.ValueMember = "ID1";

            List<EKITAP> kitaplar = new List<EKITAP>();
            kitaplar = BKITAP.SelectList();
            comboBox5.DataSource = kitaplar;
            comboBox5.DisplayMember = "KITAPADI1";
            comboBox5.ValueMember = "ID1";

            List<EDERSTURU> dersTurleri = new List<EDERSTURU>();
            dersTurleri = BDERSTURU.SelectList();
            comboBox3.DataSource = dersTurleri;
            comboBox3.DisplayMember = "DERSTURU1";
            comboBox3.ValueMember = "ID1";
        }

        private void fillOpenedCourseList()
        {
            List<EACILANDERSLERVIEW> acilanDersler = new List<EACILANDERSLERVIEW>();
            acilanDersler = BACILANDERSLER.SelectList();
            dataGridView2.DataSource = acilanDersler;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[10].Visible = false;

            List<EOGRETIMGOREVLISI> gorevliler = new List<EOGRETIMGOREVLISI>();
            gorevliler = BOGRETIMGOREVLISI.SelectList();
            comboBox7.DataSource = gorevliler;
            comboBox7.DisplayMember = "ADSOYAD1";
            comboBox7.ValueMember = "ID1";

            List<EBINALAR> binalar = new List<EBINALAR>();
            binalar = BBINALAR.SelectList();
            comboBox8.DataSource = binalar;
            comboBox8.DisplayMember = "KODU1";
            comboBox8.ValueMember = "ID1";

            List<EGUNLER> gunler = new List<EGUNLER>();
            gunler = BGUNLER.SelectList();
            comboBox9.DataSource = gunler;
            comboBox9.DisplayMember = "GUN1";
            comboBox9.ValueMember = "ID1";

            List<EDERSLIK> derslikler = new List<EDERSLIK>();
            derslikler = BDERSLIK.SelectList();
            comboBox10.DataSource = derslikler;
            comboBox10.DisplayMember = "KODU1";
            comboBox10.ValueMember = "ID1";

            List<EPROGRAM> programlar = new List<EPROGRAM>();
            programlar = BPROGRAM.SelectList();
            comboBox11.DataSource = programlar;
            comboBox11.DisplayMember = "PROGRAM1";
            comboBox11.ValueMember = "ID1";

            List<EEGITIMOGRETIMYILI> yillar = new List<EEGITIMOGRETIMYILI>();
            yillar = BEGITIMOGRETIMYILI.SelectList();
            comboBox13.DataSource = yillar;
            comboBox13.DisplayMember = "YIL1";
            comboBox13.ValueMember = "ID1";

            List<EDONEM> donemler = new List<EDONEM>();
            donemler = BDONEM.SelectList();
            comboBox14.DataSource = donemler;
            comboBox14.DisplayMember = "DONEM1";
            comboBox14.ValueMember = "ID1";

            List<EDERSDILI> diller = new List<EDERSDILI>();
            diller = BDERSDILI.SelectList();
            comboBox4.DataSource = diller;
            comboBox4.DisplayMember = "DIL1";
            comboBox4.ValueMember = "ID1";

            List<EDERSLER> dersler = new List<EDERSLER>();
            dersler = BDERSLER.SelectList();
            comboBox12.DataSource = dersler;
            comboBox12.DisplayMember = "DERS1";
            comboBox12.ValueMember = "ID1";
        }

        private void fillEnterNote()
        {
            List<EDERSLER> dersler = new List<EDERSLER>();
            dersler = BDERSLER.SelectList();
            comboBox15.DataSource = dersler;
            comboBox15.DisplayMember = "DERS1";
            comboBox15.ValueMember = "ID1";

            List<EOGRENCI> ogrenciler = new List<EOGRENCI>();
            ogrenciler = BOGRENCI.SelectList();
            comboBox16.DataSource = ogrenciler;
            comboBox16.DisplayMember = "ADSOYAD1";
            comboBox16.ValueMember = "ID1";     
        }

        private void fillNote()
        {
            ENOTLAR notlar = new ENOTLAR();
            notlar = BNOTLAR.Select(Convert.ToInt32(comboBox16.SelectedValue), Convert.ToInt32(comboBox15.SelectedValue));
            if (notlar != null)
            {
                textBox7.Text = notlar.VIZENOTU1.ToString();
                textBox8.Text = notlar.FINALNOTU1.ToString();
                textBox9.Text = notlar.PROJENOTU1.ToString();
                textBox10.Text = notlar.HARFNOTU1.ToString();
            }
            else
            {
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
            }
        }

        private void updateNote()
        {
            ENOTLAR not = new ENOTLAR();
            not.OGRENCINO1 = Convert.ToInt32(comboBox16.SelectedValue);
            not.ACILANDERS1 = Convert.ToInt32(comboBox15.SelectedValue);
            not.VIZENOTU1 = Convert.ToInt32(textBox7.Text);
            not.FINALNOTU1 = Convert.ToInt32(textBox8.Text);
            not.PROJENOTU1 = Convert.ToInt32(textBox9.Text);
            not.HARFNOTU1 = textBox10.Text.ToString();
            int guncellenen = BNOTLAR.Update(not);
            if (guncellenen == 1)
            {
                MessageBox.Show("Not Güncellendi");
                fillNote();
            }
        }

        private void fillBookList()
        {
            List<EKITAP> kitaplar = new List<EKITAP>();
            kitaplar = BKITAP.SelectList();
            dataGridView3.DataSource = kitaplar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgretimGorevlisi.SIFRE1 = textBox1.Text;
            int guncellenen = BOGRETIMGOREVLISI.Update(OgretimGorevlisi);
            if (guncellenen == 1)
                MessageBox.Show("Kayıt Güncellendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EDERSLER ders = new EDERSLER();
            ders.DERS1 = textBox2.Text;
            ders.KODU1 = textBox3.Text;
            ders.YARIYILI1 = comboBox1.SelectedIndex + 1;
            ders.KREDI1 = comboBox2.SelectedIndex + 1;
            ders.TUR1 = Convert.ToInt32(comboBox3.SelectedValue);
            ders.DERSKITABI1 = Convert.ToInt32(comboBox5.SelectedValue);
            ders.ONSART1 = Convert.ToInt32(comboBox6.SelectedValue);
            int eklenen = BDERSLER.Insert(ders);
            if (eklenen == 1)
                MessageBox.Show("Ders Oluşturuldu");
            fillCourseList();
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EACILANDERSLER acilanDers = new EACILANDERSLER();
            acilanDers.DERS1 = Convert.ToInt32(comboBox12.SelectedValue);
            acilanDers.CRN1 = Convert.ToInt32(textBox4.Text);
            acilanDers.OGRETIMUYESI1 = Convert.ToInt32(comboBox7.SelectedValue);
            acilanDers.BINA1 = Convert.ToInt32(comboBox8.SelectedValue);
            acilanDers.GUN1 = Convert.ToInt32(comboBox9.SelectedValue);
            acilanDers.BASLANGICSAATI1 = textBox5.Text;
            acilanDers.DERSLIK1 = Convert.ToInt32(comboBox10.SelectedValue);
            acilanDers.KONTENJAN1 = Convert.ToInt32(textBox6.Text);
            acilanDers.DERSIALABILENPROGRAM1 = Convert.ToInt32(comboBox11.SelectedValue);
            acilanDers.YIL1 = Convert.ToInt32(comboBox13.SelectedValue);
            acilanDers.DONEM1 = Convert.ToInt32(comboBox14.SelectedValue);
            acilanDers.DILI1 = Convert.ToInt32(comboBox4.SelectedValue);
            int eklenen = BACILANDERSLER.Insert(acilanDers);
            if (eklenen == 1)
                MessageBox.Show("Ders Açıldı");
            fillOpenedCourseList();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage4_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateNote();
        }

        private void comboBox15_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            fillNote();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EKITAP kitap = new EKITAP();
            kitap.KITAPADI1 = textBox11.Text;
            int eklenen = BKITAP.Insert(kitap);
            if (eklenen == 1)
            {
                MessageBox.Show("Kitap Eklendi");
                fillBookList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
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
