using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HforceNegocio.Tablas
{
    public class Clientes
    {
        #region Construcctores
        Conexion.ConexionBaseDatos conexionBaseDatos = new Conexion.ConexionBaseDatos();
        Tipo_Cliente Tipo_Cliente = new Tipo_Cliente();
        #endregion

        #region Select
        public int Count()
        {
            int cuenta = -1;
            try
            {
                string query = "SELECT COUNT(*) FROM Clientes";

                conexionBaseDatos.AbrirConexion();

                MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

                conexionBaseDatos.AbrirConexion();

                cuenta = int.Parse(cmd.ExecuteScalar().ToString());

                conexionBaseDatos.CerrarConexion();

                return cuenta;
            }
            catch (Exception)
            {

                return cuenta;
            }
        }
        public int ValidarNit(int NIT)
        {
            int cuenta = -1;
            try
            {
                string query = "SELECT COUNT(*) FROM Clientes WHERE nit = @nit";
              
                conexionBaseDatos.AbrirConexion();

                MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);
                
                cmd.Parameters.AddWithValue("@nit", NIT);

                conexionBaseDatos.AbrirConexion();

                cuenta = int.Parse(cmd.ExecuteScalar().ToString());

                conexionBaseDatos.CerrarConexion();

                return cuenta;
            }
            catch (Exception)
            {

                return cuenta;
            }
        }
        public int ValidarCC(int CC)
        {
            int cuenta = -1;
            try
            {
                string query = "SELECT COUNT(*) FROM Clientes WHERE cc = @cc";

                conexionBaseDatos.AbrirConexion();

                MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

                cmd.Parameters.AddWithValue("@cc", CC);

                conexionBaseDatos.AbrirConexion();

                cuenta = int.Parse(cmd.ExecuteScalar().ToString());

                conexionBaseDatos.CerrarConexion();

                return cuenta;
            }
            catch (Exception)
            {

                return cuenta;
            }
        }
        #endregion

        #region Insert


        public bool InsertNit(string nombre_cliente,string tipo_cliente,int nit,int dv,string ciudad,
            string direccion,string telefono)
        {
            try
            {
                int id_cliente = Count() + 1;
                int id_tipo_cliente = Tipo_Cliente.SelectId(tipo_cliente);
                string query = "INSERT INTO" +
                    " Clientes (id_cliente, nombre_cliente, id_tipo_cliente," +
                    "nit, dv, ciudad, direccion, telefono)" +
                    "VALUES (@id_cliente, @nombre_cliente, @id_tipo_cliente," +
                    "@nit, @dv, @ciudad, @direccion, @telefono)";

                MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);
                
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                cmd.Parameters.AddWithValue("@nombre_cliente", nombre_cliente);
                cmd.Parameters.AddWithValue("@id_tipo_cliente", id_tipo_cliente);
                cmd.Parameters.AddWithValue("@nit", nit);
                cmd.Parameters.AddWithValue("@dv", dv);
                cmd.Parameters.AddWithValue("@ciudad", ciudad);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@telefono", telefono);

                conexionBaseDatos.AbrirConexion();
                cmd.ExecuteNonQuery();
                conexionBaseDatos.CerrarConexion();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool InsertDoc(string nombre_cliente, string tipo_cliente, int cc, string ciudad,
           string direccion, string telefono)
        {
            try
            {
                int id_cliente = Count() + 1;
                int id_tipo_cliente = Tipo_Cliente.SelectId(tipo_cliente);
                string query = "INSERT INTO" +
                    " Clientes (id_cliente, nombre_cliente, id_tipo_cliente," +
                    "cc, ciudad, direccion, telefono)" +
                    "VALUES (@id_cliente, @nombre_cliente, @id_tipo_cliente," +
                    "@cc, @ciudad, @direccion, @telefono)";

                MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                cmd.Parameters.AddWithValue("@nombre_cliente", nombre_cliente);
                cmd.Parameters.AddWithValue("@id_tipo_cliente", id_tipo_cliente);
                cmd.Parameters.AddWithValue("@cc", cc);
                cmd.Parameters.AddWithValue("@ciudad", ciudad);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@telefono", telefono);

                conexionBaseDatos.AbrirConexion();
                cmd.ExecuteNonQuery();
                conexionBaseDatos.CerrarConexion();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}
