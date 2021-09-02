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

namespace HforceWindows.Menus.Clientes
{
    public partial class ClienteNuevo : Form
    {
        #region Constructores
        HforceNegocio.Texto.CiudadesTxt CiudadesTxt = new HforceNegocio.Texto.CiudadesTxt();
        HforceNegocio.Tablas.Clientes tablaClientes = new HforceNegocio.Tablas.Clientes();
        #endregion

        #region Listas
        List<String>[] listaCiudades;
        #endregion

        #region Variables

        #endregion

        #region Inicio
        public ClienteNuevo()
        {
            InitializeComponent();
        }
        private void ClienteNuevo_Load(object sender, EventArgs e)
        {
            AgregarCiudades();
        }
        #endregion

        #region Tipo Cliente 
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtJuridico.Checked)
            {
                txtDv.Enabled = true;
                groupBoxDoc.Text = "NIT";
                groupBoxNombre.Text = "Razón Social";
            }
            else
            {
                txtDv.Enabled = false;
                groupBoxDoc.Text = "Numero Documento";
                groupBoxNombre.Text = "Nombre";
            }
        }
        #endregion
    

    #region Botón Guardar
    private void tbtGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarControles())
            {
                if (MessageBox.Show("Confirma guardas los datos?", "Guardar", MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    if (rbtJuridico.Checked)
                    {
                        if (ValidarNit(int.Parse(txtIdentificador.Text)))
                        {
                            if (tablaClientes.InsertNit(txtNombreLegal.Text, "Jurídica",
                                int.Parse(txtIdentificador.Text), int.Parse(txtDv.Text), cbxCiudad.Text,
                                txtDireccion.Text, txtTelefono.Text))
                            {
                                MessageBox.Show("Datos registrados","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al guardas los datos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                        }
                    }
                    else
                    {
                        if (ValidarCC(int.Parse(txtIdentificador.Text)))
                        {
                            if (tablaClientes.InsertDoc(txtNombreLegal.Text, "Natural",
                                int.Parse(txtIdentificador.Text), cbxCiudad.Text,
                                txtDireccion.Text, txtTelefono.Text))
                            {
                                MessageBox.Show("Datos registrados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al guardas los datos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Faltan Datos");
            }
        }
        #endregion

        #region Cerrar
        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Funciones
        private void AgregarCiudades()
        {
            cbxCiudad.Items.Clear();
            listaCiudades = CiudadesTxt.ListaCiudades();
            foreach (var item in listaCiudades[0])
            {
                cbxCiudad.Items.Add(item.ToString());
            }
        }

        private bool ValidarNit(int nit)
        {
            if (tablaClientes.ValidarNit(nit)==0)
            {
                return true;
            }
            else if (tablaClientes.ValidarNit(nit) > 0)
            {
                MessageBox.Show("El NIT  ya existe ");
                return false;                
            }
            else
            {
                MessageBox.Show("Error base datos");
                return false;
            }
        }

        private bool ValidarCC(int CC)
        {
            if (tablaClientes.ValidarCC(CC) == 0)
            {
                return true;
            }
            else if (tablaClientes.ValidarCC(CC) > 0)
            {
                MessageBox.Show("El documento ya existe ");
                return false;
            }
            else
            {
                MessageBox.Show("Error base datos");
                return false;
            }
        }
        
        private bool ValidarControles()
        {
            bool verifica = true;
            if (string.IsNullOrEmpty(txtNombreLegal.Text))
            {
                txtNombreLegal.Focus();
                verifica = false;
            }
            else if (string.IsNullOrEmpty(txtIdentificador.Text))
            {
                txtIdentificador.Focus();
                verifica = false;
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtTelefono.Focus();
                verifica = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                txtDireccion.Focus();
                verifica = false;
            }
            else if (string.IsNullOrEmpty(cbxCiudad.Text))
            {
                cbxCiudad.Focus();
                verifica = false;
            }

            return verifica;
        }
        #endregion

        private void btNuevoRegistro_Click(object sender, EventArgs e)
        {
            ValidarNit(1);
        }
    }
}
