using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HforceNegocio.Tablas
{
    public class Tipo_Cliente
    {
        #region Construcctores
        Conexion.ConexionBaseDatos conexionBaseDatos = new Conexion.ConexionBaseDatos();
        #endregion

        #region Select
        public int SelectId(string tipo_cliente)
        {
            try
            {
                string query = "SELECT id_tipo_cliente FROM Tipo_Cliente WHERE Tipo_cliente=@Tipo_cliente";

                conexionBaseDatos.AbrirConexion();

                MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);
                cmd.Parameters.AddWithValue("@Tipo_cliente", tipo_cliente);

                conexionBaseDatos.AbrirConexion();

                int dato = int.Parse(cmd.ExecuteScalar().ToString());

                conexionBaseDatos.CerrarConexion();

                return dato;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
    }
}
