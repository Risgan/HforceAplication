using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HforceWindows.Splash
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            Thread.Sleep(300);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            Application.DoEvents();
            if (progressBar1.Value>=progressBar1.Maximum)
            {                
                this.Hide();
                timer1.Stop();
                Login.Login login = new Login.Login();
                login.Show();                
            }
        }
    }
}
