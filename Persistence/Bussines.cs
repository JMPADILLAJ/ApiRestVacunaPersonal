using farma_API_REST.Models;
using SqlDataReaderMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace farma_API_REST.Persistence
{
    public class Bussines
    {
        public List<Empleado> ListarEmpleados()
        {

            List<Empleado> ListaEmpleados = new List<Empleado>();
            using (Conexion cnx = new Conexion())
            {

                string script = "SELECT * FROM farma_empleado";
                SqlCommand cmd = new SqlCommand(script, cnx.OpenConexion());
                SqlDataReader res = cmd.ExecuteReader();

                if (res.HasRows)
                {
                    ListaEmpleados = cnx.DataReaderMapToList<Empleado>(res);
                    cnx.CloseConexion();

                }
            }
            return ListaEmpleados;
        }

        public int InsertarEmpleado(InsertEmpleado ie)
        {

            int r = 0;
            using (Conexion cnx = new Conexion())
            {

                string script = "sp_empleado_create";
                SqlCommand cmd = new SqlCommand(script, cnx.OpenConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombres", ie.nombres);
                cmd.Parameters.AddWithValue("@apellidos", ie.apellidos);
                cmd.Parameters.AddWithValue("@cedula", ie.cedula);
                cmd.Parameters.AddWithValue("@correo", ie.correo);
                SqlDataReader res = cmd.ExecuteReader();
                if (res.HasRows)
                {
                    while (res.Read())
                    {
                        r = res.GetInt32(0);
                    }

                    cnx.CloseConexion();
                    cmd.Parameters.Clear();
                }
            }

            return r;
        }


        public int ActualizarEmpleado(UpdateEmpleado ue)
        {

            int r = 0;

            using (Conexion cnx = new Conexion())
            {

                string script = "sp_empleado_update";
                SqlCommand cmd = new SqlCommand(script, cnx.OpenConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_empleado", ue.id_empleado);
                cmd.Parameters.AddWithValue("@cedula", ue.cedula);
                cmd.Parameters.AddWithValue("@nombres", ue.nombres);
                cmd.Parameters.AddWithValue("@apellidos", ue.apellidos);
                cmd.Parameters.AddWithValue("@correo", ue.correo);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", ue.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@direccion_domicilio", ue.direccion_domicilio);
                cmd.Parameters.AddWithValue("@telefono", ue.telefono);
                cmd.Parameters.AddWithValue("@estado_vacuna", ue.estado_vacuna);
                cmd.Parameters.AddWithValue("@tipo_vacuna", ue.tipo_vacuna);
                cmd.Parameters.AddWithValue("@fecha_vacuna", ue.fecha_vacuna);
                cmd.Parameters.AddWithValue("@numero_dosis", ue.numero_dosis);
                SqlDataReader res = cmd.ExecuteReader();

                if (res.HasRows)
                {
                    while (res.Read())
                    {
                        r = res.GetInt32(0);
                    }

                    cnx.CloseConexion();
                    cmd.Parameters.Clear();
                }
            }

            return r;
        }


        public List<Empleado> GetEmpleadosTipoVac(string tipo_vacuna)
        {

            List<Empleado> ListaEmpleados = new List<Empleado>();
            using (Conexion cnx = new Conexion())
            {

                string script = "SELECT * FROM farma_empleado  where tipo_vacuna="+ tipo_vacuna;
                SqlCommand cmd = new SqlCommand(script, cnx.OpenConexion());
                SqlDataReader res = cmd.ExecuteReader();

                if (res.HasRows)
                {
                    ListaEmpleados = cnx.DataReaderMapToList<Empleado>(res);
                    cnx.CloseConexion();

                }
            }
            return ListaEmpleados;
        }


        public List<Empleado> GetEmpleadosEstadoVac(int estado_vacuna)
        {

            List<Empleado> ListaEmpleados = new List<Empleado>();
            using (Conexion cnx = new Conexion())
            {

                string script = "SELECT * FROM farma_empleado  where estado_vacuna=" + estado_vacuna;
                SqlCommand cmd = new SqlCommand(script, cnx.OpenConexion());
                SqlDataReader res = cmd.ExecuteReader();

                if (res.HasRows)
                {
                    ListaEmpleados = cnx.DataReaderMapToList<Empleado>(res);
                    cnx.CloseConexion();

                }
            }
            return ListaEmpleados;
        }


        public List<Empleado> GetEmpleadosFechaVac(DateTime fecha_vacuna)
        {

            List<Empleado> ListaEmpleados = new List<Empleado>();
            using (Conexion cnx = new Conexion())
            {
                string script = "SELECT * FROM farma_empleado  where fecha_vacuna="+ fecha_vacuna;
                SqlCommand cmd = new SqlCommand(script, cnx.OpenConexion());
                SqlDataReader res = cmd.ExecuteReader();

                if (res.HasRows)
                {
                    ListaEmpleados = cnx.DataReaderMapToList<Empleado>(res);
                    cnx.CloseConexion();
                }
            }
            return ListaEmpleados;
        }



        public Empleado GetEmpleado(int cedula)
        {

            Empleado empleado = new Empleado();

            using (Conexion cnx = new Conexion())
            {

                string script = "SELECT * FROM farma_empleado where cedula="+cedula;
                SqlCommand cmd = new SqlCommand(script, cnx.OpenConexion());
                SqlDataReader res = cmd.ExecuteReader();

                if (res.HasRows)
                {
                    while (res.Read())
                    {
                        empleado = new SqlDataReaderMapper<Empleado>(res).Build();
                    }
                   
                    cnx.CloseConexion();

                }
            }
            return empleado;
        }
    }
}