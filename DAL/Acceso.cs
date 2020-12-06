using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using DAL;


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


        public string Escribir(string Consulta, Hashtable Parametros)
        {
            ComandoSQL = new SqlCommand();
            ComandoSQL.Connection = AbrirConexion();

            string Id =""; // Valor que se capturará en el caso de insersiones

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
                ComandoSQL.Parameters.Add("@Id_ins", SqlDbType.Int).Direction = ParameterDirection.Output; // Para inserción

                int respuesta = ComandoSQL.ExecuteNonQuery();
                Transaccion.Commit();
                Id = ComandoSQL.Parameters["@Id_ins"].Value.ToString().Trim();
            }

            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                Transaccion.Rollback();  
            }

            finally
            {
                Conexion.Close();
            }
            return Id;
        }

        public void EjecutarQuerysBackup(string Consulta) // Exclusivo para tareas de backup: se conecta a la base MASTER y no utiliza Transacciones
        {
            ComandoSQL = new SqlCommand();
            Conexion = new SqlConnection("Data Source=EQA-NB09;Initial Catalog=master;User ID=sa;Password=T0rtug4");
            Conexion.Open();
            ComandoSQL.Connection = Conexion;
                        
            try
            {             
                ComandoSQL.CommandText = Consulta;
                ComandoSQL.CommandTimeout = 600;
                ComandoSQL.CommandType = CommandType.Text; 
                ComandoSQL.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
            }
            finally
            {
                Conexion.Close();
            }
        }
    }
}
