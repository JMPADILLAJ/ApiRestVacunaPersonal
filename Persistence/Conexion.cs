using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace farma_API_REST.Persistence
{
    public class Conexion: IDisposable
    {

        string cadena = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public SqlConnection OpenConexion()
        {

            SqlConnection cnx = new SqlConnection(@cadena);

            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                return cnx;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public SqlConnection CloseConexion()
        {

            SqlConnection cnx = new SqlConnection(@cadena);

            try
            {
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
                cadena = "";
                return cnx;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}