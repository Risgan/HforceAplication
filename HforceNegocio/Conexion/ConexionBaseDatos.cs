using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HforceNegocio.Conexion
{
    public class ConexionBaseDatos
    {
        public MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString);


        /// <summary>
        /// Abrir conexion con base de datos
        /// </summary>
        /// <param name="usuario">String nombre de usuario</param>
        /// <param name="clave">String de la clave</param>
        public string AbrirConexion()
        {
            try
            {
                conexion.Open();
                return "Conectado";
            }
            catch (Exception ex)
            {
                return "Error al conectar con BD\n"+ ex;
            }           
        }

        /// <summary>
        /// Cerrar conexion base de datos
        /// </summary>
        /// <returns>String info cerrar conexion</returns>
        public string CerrarConexion()
        {
            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
                return "Sin conexion";
            }
            return "Error Cerrar Base Datos";
        }
    }
}
