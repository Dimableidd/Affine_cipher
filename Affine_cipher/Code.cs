using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Substitution_cipher
{
    public partial class Code : Form
    {
        public Code()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            string A = textBox2.Text.Replace(" ", "");
            string B = textBox1.Text.Replace(" ", "");
            int[] key = new int[A.Length];
            for (int i = 0; i < key.Length; i++)
            {
                if ((int)A[i] < 48 || (int)A[i] > 57) { MessageBox.Show("ОШИБКА ВВОДА В СТРОКЕ //КЛЮЧ//", "ОШИБКА"); return; }
                    key[i] = A[i]-'0';
            }

            if (radioButton1.Checked) // Зашифровать
            {
                for (int i = 0; i < B.Length % key.Length; i++)
                    B += B[i];
                for (int i = 0; i < B.Length; i += key.Length)
                {
                    char[] t = new char[key.Length];

                    for (int j = 0; j < key.Length; j++)
                        t[key[j] - 1] = B[i + j];

                    for (int j = 0; j < key.Length; j++)
                        textBox3.Text += t[j];
                }
            }
            else // Расшифровать
            {
                for (int i = 0; i < B.Length; i += key.Length)
                {
                    char[] t = new char[key.Length];

                    for (int j = 0; j < key.Length; j++)
                        t[j] = B[i + key[j] - 1];

                    for (int j = 0; j < key.Length; j++)
                       textBox3.Text += t[j];
                }
            }
        }
    }
}
