﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane_Proje_2
{
    public partial class Doktorbilgidüzenle : Form
    {
        public Doktorbilgidüzenle()
        {
            InitializeComponent();
        }

        Class_Hastane bgl=new Class_Hastane();

        public string tc;
        private void Doktorbilgidüzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = tc;

            SqlCommand komut = new SqlCommand("Select * From Table_Doktor where DoktorTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",msktc.Text);
            SqlDataReader da= komut.ExecuteReader();
            while(da.Read()) 
            {
                txtad.Text = da[1].ToString();
                txtsoyad.Text = da[2].ToString();
                cmbbrans.Text = da[3].ToString();
                txtsifre.Text = da[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Table_Doktor set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtad.Text);
            komut.Parameters.AddWithValue("@p2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3",cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4",txtsifre.Text);
            komut.Parameters.AddWithValue("@p5", msktc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız oluşturuldu");
            txtad.Clear();
            txtsoyad.Clear();
            cmbbrans.Text = " ";
            msktc.Clear();
            txtsifre.Clear();
        }
    }
}
