using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int Fn1(double X, ref double Res)
        {
            try
            {
                Res = Math.Tanh(X);
                return 0;
            }
            catch
            {
                return 1;
            }
        }
        private int Fn2(double X2, ref double Res)
        {
            try
            {
                Res = Math.Abs(1 / (X2 + 1));
                return 0;
            }
            catch
            {
                return 1;
            }
        }
        private int Fn3(double X2, ref double Res)
        {
            try
            {
                if (X2 == 1)
                    return 3;
                Res = Math.Tanh(Math.Abs(-1 / (1 - X2)));
                return 0;
            }
            catch
            {
                return 1;
            }
        }
        private int Fn4(double X2, ref double Res)
        {
            try
            {
                Res = 0;
                double Xi = X2 - 1;
                for (int i = 1; i <= 1000000; i++)
                {
                    Res += Xi * Math.Sqrt(i);
                    Xi += X2;
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = "";
            textBox1.Text = "";

            double X0 = -10;
            double h = 0.1;
            double[] Xn = new double[1000];
            for (int i = 0; i < 1000; i++)
                Xn[i] = X0 + h * i;

            double F1;
            double F2;
            double F3;
            double F4;

            bool HasError = false;
            foreach (double Xi in Xn)
            {
                double X2 = Xi * Xi;

                int Error = 0;
                F1 = F2 = F3 = F4 = 0;

                Error |= Fn1(Xi, ref F1);
                Error |= Fn2(X2, ref F2);
                Error |= Fn3(X2, ref F3);
                Error |= Fn4(X2, ref F4);

                HasError = Error != 0;
                if (Error == 0)
                {
                    //richTextBox1.Text += $"F({Xi}) = {F1 + F2 + F3 + F4}\n";
                    textBox1.AppendText($"\nF({Xi}) = {F1 + F2 + F3 + F4}\r\n");
                }
                    
                if (HasError)
                {
                    MessageBox.Show($"Has invalid argument: Х = {Xi}");
                }

                Application.DoEvents();
            }
        }
    }
}
