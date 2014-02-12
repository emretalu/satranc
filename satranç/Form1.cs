using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace satranç
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kare(64, 484, 482);
            
        }

        Button[] butonlar = new Button[64];

        void create_table()
        {
            for (int i = 0; i < 64; i++)
            {
                Button btn = new Button();
                btn.Width = 60;
                btn.Height = 60;
                btn.Margin = Padding.Empty;
                btn.Click += new EventHandler(btn_Click);
                flowLayoutPanel1.Controls.Add(btn);
                butonlar[i] = btn;
            }
            btnReset();
        }

        void btnReset()
        {
            for (int i = 0; i < 64; i++)
            {
                Button btn = butonlar[i];
                Color back;
                if ((i % 2 + i / 8)%2 == 0)
                {
                    back = Color.White;
                }
                else
                {
                    back = Color.Black;
                }
                btn.BackColor = back;
            }
        }

        void btnPaint(Button btn)
        {
            btn.BackColor = Color.LightBlue;
        }

        void kare(int sayi, int genislik, int yukseklik)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Width = genislik;
            flowLayoutPanel1.Height = yukseklik;

            create_table();
        }

        void btn_Click(object sender, EventArgs e)
        {
            btnReset();
            Button buton = (Button)sender;

            int x = buton.Location.X / 60 + 1;
            int y = buton.Location.Y / 60 + 1;
            char[] harf = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            label1.Text = harf[x-1].ToString() + (9-y).ToString();

            foreach (Button btn in butonlar)
            {
                int X = btn.Location.X / 60 + 1;
                int Y = btn.Location.Y / 60 + 1;
                bool canMove = false;
                if (radio_Fil.Checked && fil(x, y, X, Y))
                {
                    canMove = true;
                }
                else if (radio_Kale.Checked && kale(x, y, X, Y))
                {
                    canMove = true;
                }
                else if (radio_At.Checked && at(x, y, X, Y))
                {
                    canMove = true;
                }
                else if (radio_Piyon.Checked && piyon(x, y, X, Y))
                {
                    canMove = true;
                }
                else if (radio_Vezir.Checked && (fil(x, y, X, Y) || kale(x, y, X, Y)))
                {
                    canMove = true;
                }
                else if (radio_Sah.Checked && sah(x, y, X, Y))
                {
                    canMove = true;
                }

                if (canMove)
                {
                    btnPaint(btn);
                }
            }
        }

        bool fil(int x, int y, int X, int Y)
        {
            if (((X - x == Y - y) || (X - x == y - Y)) && X != x)
            {
                return true;
            }
            return false;
        }

        bool kale(int x, int y, int X, int Y)
        {
            if (((X == x) && (Y  != y)) || ((Y == y) && (X != x)))
            {
                return true;
            }
            return false;
        }

        bool at(int x, int y, int X, int Y)
        {
            if (((Math.Abs(X - x) == 1) && (Math.Abs(Y - y) == 2)) || ((Math.Abs(X - x) == 2) && (Math.Abs(Y - y) == 1)))
            {
                return true;
            }
            return false;
        }

        bool piyon(int x, int y, int X, int Y)
        {
            if (Y + 1 == y && X == x)
            {
                return true;
            }
            return false;
        }

        bool sah(int x, int y, int X, int Y)
        {
            if (((X - x == Y - y) || (X - x == y - Y)) && (Math.Abs(X - x) == 1))
            {
                return true;
            }
            else if (((X == x) && (Math.Abs(Y - y) == 1)) || (Y == y) && (Math.Abs(X - x) == 1))
            {
                return true;
            }
            return false;
        }
    }
}
