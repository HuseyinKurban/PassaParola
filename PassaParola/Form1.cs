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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace PassaParola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP-32Q9FH5;Initial Catalog=DbPassaParola;Integrated Security=True;");

        int soruno = 0, dogru = 0, yanlis = 0, sayac = 16, bos = 0;
        string cevap;

       

        void dogruarttır()
        {
            dogru++;
            txtcevap.Enabled = false;
            timer1.Stop();
            sayac = 16;
            button25.BackColor = Color.White;
            lbldogru.Text = dogru.ToString();
        }

      

        void yanlisarttır()
        {
            yanlis++;
            txtcevap.Enabled = false;
            timer1.Stop();
            sayac = 16;
            button25.BackColor = Color.White;
            lblyanlis.Text = yanlis.ToString();
        }

        void BuyukFont()
        {
            // Button25'in mevcut fontunu al
            Font mevcutFont = button25.Font;
            // Yeni bir font boyutu belirle
            float yeniBoyut = 48.0f;
            // Yeni font oluştur ve butona uygula
            button25.Font = new Font(mevcutFont.FontFamily, yeniBoyut, mevcutFont.Style);
        }

        private void linklblbasla_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timer1.Start();
            sayac = 16;
            linklbl.Text = "Sonraki Soru";
            linklbl.Enabled = false;
            soruno++;
            this.Text = "PassaParola SoruNo: " + soruno;
            txtcevap.Text = "";
            txtcevap.Enabled = true;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TblSoru where ID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", soruno);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rchtxtsoru.Text = dr[1].ToString();
                cevap = dr[2].ToString();

            }
            baglanti.Close();

            if(soruno == 25)
            {
                rchtxtsoru.Text = "";
                txtcevap.Text = "";
                txtcevap.Enabled = false;
                this.Text = "PassaParola";
                linklbl.Text = "Başla";
                soruno = 0;
                dogru = 0;
                yanlis = 0;
                bos = 0;

                MessageBox.Show("Doğru Sayısı: " + lbldogru.Text + "\nYanlış Sayısı: " + lblyanlis.Text + "\nBoş Sayısı: " + lblbos.Text, "OYUN BİTTİ");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac--;
            button25.Text = sayac.ToString();
            BuyukFont();

            switch (sayac)
            {

                case 6: case 4: case 2: case 0: button25.BackColor = Color.Red; break;
                case 5: case 3: case 1: button25.BackColor = Color.White; break;
                default: button25.BackColor = Color.White; break;

            }
            if (sayac == 0)
            {
                button25.BackColor = Color.Red;
                timer1.Stop();
                button25.Font = new Font("Microsoft Sans Serif", 24.0f, FontStyle.Bold);
                button25.Text = "Süreniz bitti. Diğer soruya geçiniz ";
                txtcevap.Enabled = false;
                linklbl.Enabled = true;
                bos++;
                lblbos.Text = bos.ToString();
                sayac = 16;

            }
        }

        private void txtcevap_KeyDown(object sender, KeyEventArgs e)
        {
            linklbl.Enabled = true;

            if (e.KeyCode == Keys.Enter)
            {
                string kullaniciCevap = txtcevap.Text.ToLower();

                switch (soruno)
                {
                    //1. Cevap
                    case 1:

                        if (kullaniciCevap == cevap)
                        {
                            button1.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button1.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //2. Cevap
                    case 2:
                        if (kullaniciCevap == cevap)
                        {
                            button2.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button2.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //3. Cevap
                    case 3:
                        if (kullaniciCevap == cevap)
                        {
                            button3.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button3.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //4. Cevap
                    case 4:
                        if (kullaniciCevap   == cevap)
                        {
                            button4.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button4.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //5. Cevap
                    case 5:
                        if (kullaniciCevap == cevap)
                        {
                            button5.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button5.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //6. Cevap
                    case 6:
                        if (kullaniciCevap == cevap)
                        {
                            button6.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button6.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //7. Cevap
                    case 7:
                        if (kullaniciCevap == cevap)
                        {
                            button7.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button7.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //8. Cevap
                    case 8:
                        if (kullaniciCevap == cevap)
                        {
                            button8.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button8.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //9. Cevap
                    case 9:
                        if (kullaniciCevap == cevap)
                        {
                            button9.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button9.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //10. Cevap
                    case 10:
                        if (kullaniciCevap == cevap)
                        {
                            button10.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button10.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //11. Cevap
                    case 11:
                        if (kullaniciCevap == cevap)
                        {
                            button11.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button11.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //12. Cevap
                    case 12:
                        if (kullaniciCevap == cevap)
                        {
                            button12.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button12.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //13. Cevap
                    case 13:
                        if (kullaniciCevap == cevap)
                        {
                            button13.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button13.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //14. Cevap
                    case 14:
                        if (kullaniciCevap == cevap)
                        {
                            button14.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button14.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //15. Cevap
                    case 15:
                        if (kullaniciCevap == cevap)
                        {
                            button15.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button15.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //16. Cevap
                    case 16:
                        if (kullaniciCevap == cevap)
                        {
                            button16.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button16.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //17. Cevap
                    case 17:
                        if (kullaniciCevap == cevap)
                        {
                            button17.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button17.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //18. Cevap
                    case 18:
                        if (kullaniciCevap == cevap)
                        {
                            button18.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button18.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //19. Cevap
                    case 19:
                        if (kullaniciCevap == cevap)
                        {
                            button19.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button19.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //20. Cevap
                    case 20:
                        if (kullaniciCevap == cevap)
                        {
                            button20.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button20.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //21. Cevap
                    case 21:
                        if (kullaniciCevap == cevap)
                        {
                            button21.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button21.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //22. Cevap
                    case 22:
                        if (kullaniciCevap == cevap)
                        {
                            button22.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button22.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //23. Cevap
                    case 23:
                        if (kullaniciCevap == cevap)
                        {
                            button23.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button23.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                    //24. Cevap
                    case 24:
                        if (kullaniciCevap == cevap)
                        {
                            button24.BackColor = Color.Green;
                            dogruarttır();
                        }
                        else
                        {
                            button24.BackColor = Color.Red;
                            yanlisarttır();
                        }
                        break;
                }
            }
        }

    }
}
