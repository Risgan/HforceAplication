using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HforceNegocio;

namespace HforceWindows
{
    public partial class pruebas : Form
    {
        public pruebas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int valor1 = 10;
            int a = 0;
            int b = 1;
            for (int i = 0; i < valor1; i++)
            {
                valor1 = 1;
                a = b;
                MessageBox.Show(a.ToString());
            }

            object x = "A;B;C;D;E";

        }
    }
}
