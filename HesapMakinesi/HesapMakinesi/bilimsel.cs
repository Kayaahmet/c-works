using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HesapMakinesi
{
    public partial class bilimsel : Form
    {
        public bilimsel()
        {
            InitializeComponent();
           
        }
        double sonuc = 0, sayi = 0;
        bool IslemDevamEdiyor = false;
        bool SonucGosteriliyor = false;
        int sign_Indicator = 0;
        private void bilimsel_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Enabled = false;
            this.Location = new Point(600, 200);
            button21.Enabled = false;
            label1.Text = "";
            label4.Text = "";
        }

        private void btnSayi_Click(object sender, EventArgs e)
        {
            
            if (IslemDevamEdiyor || SonucGosteriliyor)
            {
                tbISLEM.Text = "0";
                IslemDevamEdiyor = false;
                SonucGosteriliyor = false;
            }

            Button s = (Button)sender;

            if (tbISLEM.Text == "0")
                tbISLEM.Text = "";

            tbISLEM.Text += s.Text;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
           
                if (IslemDevamEdiyor || SonucGosteriliyor)
                {
                    tbISLEM.Text = "0";
                    IslemDevamEdiyor = false;
                    SonucGosteriliyor = false;
                }

                if (tbISLEM.Text.Length > 0)
                {
                    if (tbISLEM.Text != "0")
                    {
                        tbISLEM.Text = tbISLEM.Text.Substring(0, (tbISLEM.Text.Length - 1));

                        if (tbISLEM.Text == "")
                            tbISLEM.Text = "0";
                    }
                }
            }

        private void btnVirgul_Click(object sender, EventArgs e)
        {
            if (IslemDevamEdiyor || SonucGosteriliyor)
            {
                tbISLEM.Text = "0";
                IslemDevamEdiyor = false;
                SonucGosteriliyor = false;
            }

            if (tbISLEM.Text.IndexOf(",") < 0)
                tbISLEM.Text += ",";
        }

        private void btnCarp_Click(object sender, EventArgs e)
        {
            IslemiYap("*");
        }

        private void btnBol_Click(object sender, EventArgs e)
        {
            IslemiYap("/");
        }

        private void btnArti_Click(object sender, EventArgs e)
        {
            IslemiYap("+");
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            IslemiYap("-");
        }

        private void btnEsittir_Click(object sender, EventArgs e)
        {
            IslemiYap("=");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Islem = "";
            tbDETAY.Text = "";
            tbISLEM.Text = "0";
            sonuc = 0;
            sayi = 0;
            IslemDevamEdiyor = false;
            SonucGosteriliyor = false;
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {

        }

        

        private void frmHesapMakinesi_KeyPress(object sender, KeyPressEventArgs e)
        {
            Keys k = (Keys)e.KeyChar;

            object sbtn = new object();

            if (k == Keys.D0)
                sbtn = (object)btn0;
            else if (k == Keys.D1)
                sbtn = (object)btn1;
            else if (k == Keys.D2)
                sbtn = (object)btn2;
            else if (k == Keys.D3)
                sbtn = (object)btn3;
            else if (k == Keys.D4)
                sbtn = (object)btn4;
            else if (k == Keys.D5)
                sbtn = (object)btn5;
            else if (k == Keys.D6)
                sbtn = (object)btn6;
            else if (k == Keys.D7)
                sbtn = (object)btn7;
            else if (k == Keys.D8)
                sbtn = (object)btn8;
            else if (k == Keys.D9)
                sbtn = (object)btn9;


            if (k == Keys.D0 ||
                k == Keys.D1 ||
                k == Keys.D2 ||
                k == Keys.D3 ||
                k == Keys.D4 ||
                k == Keys.D5 ||
                k == Keys.D6 ||
                k == Keys.D7 ||
                k == Keys.D8 ||
                k == Keys.D9)
            {
                btnSayi_Click(sbtn, new EventArgs());
            }
            else if (e.KeyChar == 44)
            {
                btnVirgul_Click(btnVirgul, new EventArgs());
            }
            else if (k == Keys.Back)
            {
                btnBackSpace_Click(btnBackSpace, new EventArgs());
            }
            else if (e.KeyChar == 43)
            {
                btnArti_Click(btnArti, new EventArgs());
            }
            else if (e.KeyChar == 45)
            {
                btnCikar_Click(btnCikar, new EventArgs());
            }
            else if (e.KeyChar == 42)
            {
                btnCarp_Click(btnCarp, new EventArgs());
            }
            else if (e.KeyChar == 47)
            {
                btnBol_Click(btnBol, new EventArgs());
            }
            else if (e.KeyChar == 13)
            {
                btnEsittir_Click(btnEsittir, new EventArgs());
            }
            
            else if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }
        string Islem = "";

        private void button22_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button22_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "KAPAT";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = "SİMGE DURUMUNU KÜÇÜLT";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {


                double sayı = Convert.ToInt32(tbISLEM.Text);
                tbISLEM.Text = (Math.Cos((Math.PI * sayı) / 180).ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                double sayı = Convert.ToInt32(tbISLEM.Text);
                tbISLEM.Text = (Math.Tan((Math.PI * sayı) / 180).ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                double sayı = Convert.ToInt32(tbISLEM.Text);
                tbISLEM.Text = (Math.Sin((Math.PI * sayı) / 180).ToString());
            }
            catch(Exception )
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                double sayi = Convert.ToInt32(tbISLEM.Text);
                tbISLEM.Text = (Math.Log10(sayi).ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {


                string s = "1";
                if (decimal.Parse(tbISLEM.Text) == 0)
                {
                    sonuc = 1;
                    tbISLEM.Text = sonuc.ToString();
                }

                else
                {
                    for (decimal i = decimal.Parse(tbISLEM.Text); i > 0; i--)
                    {
                        s += "0";
                    }
                    sonuc = Convert.ToInt32(s);
                    tbISLEM.Text = sonuc.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                double kare;
                double sayi = Convert.ToInt32(tbISLEM.Text);
                kare = sayi * sayi;
                tbISLEM.Text = kare.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {

                tbISLEM.Text = "3,1415926535897932384626433832795";
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                double sayi, faktoriyel;
                faktoriyel = 1;
                sayi = Convert.ToInt32(tbISLEM.Text);
                for (double i = 1; i <= sayi; i++)
                {
                    faktoriyel = faktoriyel * i;
                }
                tbISLEM.Text = faktoriyel.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbISLEM.Text.Length > 0)
                if (tbISLEM.Text.Substring(0, 1) == "-")
                    
                    tbISLEM.Text = tbISLEM.Text.Substring(1);
                else
                   
                    tbISLEM.Text = "-" + tbISLEM.Text.Substring(0);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                decimal sayi;
                if (tbISLEM.Text.Length == 0)
                    tbISLEM.Text = "0";
                sayi = decimal.Parse(tbISLEM.Text);
                switch ((sender as Button).Text)
                {
                    case "Kök":
                        if (sayi >= 0)
                            tbISLEM.Text = Math.Sqrt((double)sayi).ToString();
                        break;
                    case "x²":
                        tbISLEM.Text = (sayi * sayi).ToString();
                        break;
                    case "1/x":
                        if (sayi != 0)
                            tbISLEM.Text = (1 / sayi).ToString();
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {


                sonuc = Convert.ToInt32(Math.Pow(double.Parse(tbISLEM.Text), double.Parse("3")).ToString());
                tbISLEM.Text = sonuc.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }

        }

        private void sTANDARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            try
            {
                double sayı = Convert.ToInt32(tbISLEM.Text);

                tbISLEM.Text = (Math.Sqrt(sayı).ToString());
            }
            catch(Exception )
            {
                MessageBox.Show("Çok fazla Veri girisi oldu");
                tbISLEM.Clear();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            label4.Text = "";
            
        }

        private void button2_MouseMove_1(object sender, MouseEventArgs e)
        {
            label4.Text = "SİMGE DURUMUNU KÜÇÜLT"; 
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button22_MouseLeave_1(object sender, EventArgs e)
        {
            label1.Text = "";
            button22.BackColor = Color.Transparent;
        }

        private void button22_MouseMove_1(object sender, MouseEventArgs e)
        {
            label1.Text = "KAPAT";
            button22.BackColor = Color.Red;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbISLEM.Text.Length != 0)
                {
                    double l;
                    l = Math.Exp(Convert.ToDouble(tbISLEM.Text));
                    tbISLEM.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }


        }
        string op;
        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (tbISLEM.Text == op)
            {
                sonuc = Convert.ToInt32(Math.Pow(double.Parse(sonuc.ToString()), double.Parse(tbISLEM.Text)).ToString());
                tbISLEM.Text = sonuc.ToString();
            }
            else
            {
                sonuc = Convert.ToInt32(tbISLEM.Text);
                tbISLEM.Text = sonuc.ToString();
            }

            op = "x^y";
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tbISLEM.Text.Length != 0)
                {
                    double l;
                    l = Math.Tanh(Convert.ToDouble(tbISLEM.Text));
                    tbISLEM.Text = Convert.ToString(l);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }

        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            try
            {
                double sayı1 = Convert.ToInt32(tbISLEM.Text);
                sonuc = Math.Log((double)sayı1);
                tbISLEM.Text = sonuc.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            try
            {
                sonuc = Convert.ToInt32(Math.Pow(double.Parse(tbISLEM.Text), double.Parse("4")).ToString());
                tbISLEM.Text = sonuc.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş Dizesi Doğru Biçimde Değil");
                tbISLEM.Clear();
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Islem = "";
            tbDETAY.Text = "";
            tbISLEM.Text = "0";
            sonuc = 0;
            sayi = 0;
            IslemDevamEdiyor = false;
            SonucGosteriliyor = false;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }

        void IslemiYap(string _Islem)
        {
            sayi = Convert.ToDouble(tbISLEM.Text);

            if (tbISLEM.Text.Length > 0)
            {
                if (SonucGosteriliyor)
                {
                    Islem = _Islem;
                    tbDETAY.Text = tbDETAY.Text.Substring(0, tbDETAY.Text.Length - 3) + " " + Islem + " ";
                }
                else
                {
                    if (sonuc == 0)
                    {
                        Islem = _Islem;
                        sonuc = sayi;
                        tbDETAY.Text += sonuc.ToString() + " " + Islem + " ";
                        IslemDevamEdiyor = true;
                    }
                    else
                    {
                        switch (Islem)
                        {
                            case "+":
                                sonuc = sonuc + sayi;
                                break;
                            case "-":
                                sonuc = sonuc - sayi;
                                break;
                            case "*":
                                sonuc = sonuc * sayi;
                                break;
                            case "/":
                                sonuc = sonuc / sayi;
                                break;
                        }

                        string strN = "n" + "0";

                        tbISLEM.Text = sonuc.ToString(strN);

                        Islem = _Islem;

                        if (Islem == "=")
                        {
                            Islem = "";
                            tbDETAY.Text = "";
                            sonuc = 0;
                            sayi = 0;
                            IslemDevamEdiyor = false;
                            SonucGosteriliyor = false;
                        }
                        else
                        {
                            tbDETAY.Text += sayi + " " + Islem + " ";
                            IslemDevamEdiyor = false;
                            SonucGosteriliyor = true;
                        }
                    }
                }
            }
        }
    }
}
