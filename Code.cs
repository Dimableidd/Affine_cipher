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
            int a = Convert.ToInt32(textBox2.Text);
            int b = Convert.ToInt32(textBox4.Text);
            string A = textBox1.Text.Replace(" ", "");

            if (a<0||a>25)
            {
                MessageBox.Show("ОШИБКА ВВОДА КЛЮЧА 1, ВВЕДИТЕ ЧИСЛО ОТ 0 ДО 26", "ОШИБКА");
                return;
            }
            if (a % 2 == 0)
            {
                MessageBox.Show("ОШИБКА ВВОДА КЛЮЧА 1, ВВЕДИТЕ НЕЧЕТНОЕ ЧИСЛО", "ОШИБКА");
                return;
            }
            if (b < 0 || b > 25)
            {
                MessageBox.Show("ОШИБКА ВВОДА КЛЮЧА 2, ВВЕДИТЕ ЧИСЛО ОТ 0 ДО 26", "ОШИБКА");
                return;
            }
            if(textBox1.Text.Length == 0)
            {
                MessageBox.Show("ОШИБКА, ВВЕДИТЕ ТЕКСТ", "ОШИБКА");
                return;
            }

            if (radioButton1.Checked) // Зашифровать
            {
                for(int i=0; i < A.Length; i++)
                {
                    if (A[i] <65|| A[i]>90)
                    {
                        MessageBox.Show("ОШИБКА, ВВЕДИТЕ ТЕКСТ НА ЛАТИНИЦЕ", "ОШИБКА");
                        return;
                    }
                    textBox3.Text += (char)((((a * (A[i] - 'A')) + b) % 26) + 'A');
                }
            }

            else // Расшифровать
            {
                int a_1 = 0, f = 0;
               for(int i = 0; i < 26; i++)
                {
                    f = (a * i) % 26;
                    if (f == 1)
                    {
                        a_1 = i;
                    }
                }
               for(int i = 0; i < A.Length; i++)
                {
                    if (A[i] < 65 || A[i] > 90)
                    {
                        MessageBox.Show("ОШИБКА, ВВЕДИТЕ ТЕКСТ НА ЛАТИНИЦЕ", "ОШИБКА");
                        return;
                    }
                    textBox3.Text+= (char)((((a_1 * (A[i] + 'A' - b))) % 26) + 'A');
                }
            }
        }

    }
}
