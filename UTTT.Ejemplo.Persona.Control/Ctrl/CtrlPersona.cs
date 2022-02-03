using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UTTT.Ejemplo.Persona.Control.Interface;
using UTTT.Ejemplo.Persona.Data.Entity;
using System.Data.SqlClient;

namespace UTTT.Ejemplo.Persona.Control.Ctrl
{
    public class CtrlPersona: Conexion, IOperacion
    {

        #region IOperacion
        public bool insertar(object _o)
        {
            try
            {
                UTTT.Ejemplo.Persona.Data.Entity.Persona persona = (UTTT.Ejemplo.Persona.Data.Entity.Persona)_o;                
                SqlConnection conn = base.sqlConnection();
                conn.Open();               
                SqlCommand comm = new SqlCommand("INSERT INTO Persona (strClaveUnica,strNombre,strAPaterno,strAMaterno,idCatSexo) VALUES( '"
                  + persona.StrClaveUnica + "','"
                 + persona.StrNombre + "','"
                 + persona.StrAPaterno + "','"
                 + persona.StrAMaterno + "','"
                 + persona.IdCatSexo +  "')", conn);  
                comm.ExecuteNonQuery();
                conn.Close(); 
                return true;
            }
#pragma warning disable CS0168 // La variable '_e' se ha declarado pero nunca se usa
            catch (Exception _e)
#pragma warning restore CS0168 // La variable '_e' se ha declarado pero nunca se usa
            { 
                
            }
            return false;
        }

        public bool eliminar(object _o)
        {
            try
            {
                UTTT.Ejemplo.Persona.Data.Entity.Persona persona = (UTTT.Ejemplo.Persona.Data.Entity.Persona)_o;
                SqlConnection conn = base.sqlConnection();
                conn.Open();               
                SqlCommand comm = new SqlCommand("Delete from Persona where strClaveUnica=" + persona.StrClaveUnica , conn);
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
#pragma warning disable CS0168 // La variable '_e' se ha declarado pero nunca se usa
            catch (Exception _e)
#pragma warning restore CS0168 // La variable '_e' se ha declarado pero nunca se usa
            {

            }
            return false;
        }

        public bool actualizar(object _o)
        {          

            try
            {
                UTTT.Ejemplo.Persona.Data.Entity.Persona persona = (UTTT.Ejemplo.Persona.Data.Entity.Persona)_o;                
                SqlConnection conn = base.sqlConnection();
                conn.Open();               
                SqlCommand comm = new SqlCommand("Update Persona  set  strClaveUnica='" + persona.StrClaveUnica +
                    "', strNombre ='" + persona.StrNombre +
                    "', strAPaterno ='" + persona.StrAPaterno +
                     "', strAMaterno  ='" + persona.StrAMaterno +
                     "' where strClaveUnica=" + persona.StrClaveUnica, conn);                
                   
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
#pragma warning disable CS0168 // La variable '_e' se ha declarado pero nunca se usa
            catch (Exception _e)
#pragma warning restore CS0168 // La variable '_e' se ha declarado pero nunca se usa
            {

            }
            return false;
        }

        public List<object> consultarLista(object _o)
        {
            try
            {
                UTTT.Ejemplo.Persona.Data.Entity.Persona persona = (UTTT.Ejemplo.Persona.Data.Entity.Persona)_o;
                SqlConnection conn = base.sqlConnection();
                conn.Open();
                
                SqlCommand comm = new SqlCommand("Select * from Persona ", conn);               
                SqlDataReader reader = comm.ExecuteReader();
                
                List<Object> lista = new List<object>();
                while (reader.Read())
                {
                    UTTT.Ejemplo.Persona.Data.Entity.Persona personaTemp = new Data.Entity.Persona();
                    personaTemp.Id = int.Parse(reader["id"].ToString());
                    personaTemp.StrClaveUnica = reader["strClaveUnica"].ToString();
                    personaTemp.StrNombre = reader["strNombre"].ToString();
                    personaTemp.StrAPaterno = reader["strAPaterno"].ToString();
                    personaTemp.StrAMaterno = reader["strAMaterno"].ToString();
                    personaTemp.IdCatSexo = int.Parse(reader["idCatSexo"].ToString());
                    Object objeto = personaTemp;
                    lista.Add(objeto);
                    

                }
                conn.Close();                
                return lista;
            }
#pragma warning disable CS0168 // La variable '_e' se ha declarado pero nunca se usa
            catch (Exception _e)
#pragma warning restore CS0168 // La variable '_e' se ha declarado pero nunca se usa
            {

            }
            return null;
        }

        public object consultarItem(object _o)
        {
            try
            {
                UTTT.Ejemplo.Persona.Data.Entity.Persona persona = (UTTT.Ejemplo.Persona.Data.Entity.Persona)_o;          
                SqlConnection conn = base.sqlConnection();                
                conn.Open();
                SqlCommand comm = new SqlCommand("Select * from Persona where strClaveUnica=" + persona.StrClaveUnica+ " ", conn);
                SqlDataReader reader = comm.ExecuteReader();
                UTTT.Ejemplo.Persona.Data.Entity.Persona personaTemp = new Data.Entity.Persona();
                while (reader.Read())
                {
                    personaTemp.Id = int.Parse(reader["id"].ToString());
                    personaTemp.StrClaveUnica = reader["strClaveUnica"].ToString();
                    personaTemp.StrNombre = reader["strNombre"].ToString();
                    personaTemp.StrAPaterno = reader["strAPaterno"].ToString();
                    personaTemp.StrAMaterno = reader["strAMaterno"].ToString();
                   
                }               
                conn.Close();              
                Object objeto = personaTemp;
                return objeto;
            }
#pragma warning disable CS0168 // La variable '_e' se ha declarado pero nunca se usa
            catch (Exception _e)
#pragma warning restore CS0168 // La variable '_e' se ha declarado pero nunca se usa
            {

            }
            return null;
        }
        #endregion
    }
}
