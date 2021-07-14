using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HforceWindows.MenuPrincipal
{
    public partial class MenuPrincipal : Form
    {
        #region Initializate
        public MenuPrincipal()
        {
            InitializeComponent();
        } 
        #endregion

        #region Cerrar
        private void TSMcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } 
        #endregion
    }
}
