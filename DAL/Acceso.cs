using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;


namespace DAL
{
    public class Acceso
    {
        private SqlConnection Conexion;
        private SqlTransaction Transaccion;
        private SqlCommand ComandoSQL;
        private string CadenaConexion = "Data Source=EQA-NB09;Initial Catalog=db_tc_sistema;User ID=sa;Password=T0rtug4";
        
        private SqlConnection AbrirConexion ()

        {
            Conexion = new SqlConnection(CadenaConexion);
            Conexion.Open();
            return Conexion;
        }

        public DataSet LeerDatos (string Consuta, Hashtable Parametros) 
        
        {
            DataSet DS = new DataSet();
            ComandoSQL = new SqlCommand();
            ComandoSQL.Connection = AbrirConexion();
            ComandoSQL.CommandText = Consuta;
            ComandoSQL.CommandType = CommandType.StoredProcedure;

            if ((Parametros != null))
            {
               
                foreach (string dato in Parametros.Keys)
                {               
                    ComandoSQL.Parameters.AddWithValue(dato, Parametros[dato]);
                }
            }

            SqlDataAdapter Adaptador = new SqlDataAdapter(ComandoSQL);
            Adaptador.Fill(DS);
            return DS;

        }


        public void Escribir(string Consulta, Hashtable Parametros)
        {
            ComandoSQL = new SqlCommand();
            ComandoSQL.Connection = AbrirConexion();

            try
            {
                
                Transaccion = Conexion.BeginTransaction();                      
                ComandoSQL.CommandText = Consulta;
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.Transaction = Transaccion;


                if ((Parametros != null))
                {
                    foreach (string dato in Parametros.Keys)
                    {                       
                        ComandoSQL.Parameters.AddWithValue(dato, Parametros[dato]);
                    }
                }

                int respuesta = ComandoSQL.ExecuteNonQuery();
                Transaccion.Commit();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Transaccion.Rollback();
               
            }
            finally
            {
                Conexion.Close();
            }

        }
    }
}
