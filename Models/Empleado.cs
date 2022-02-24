using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace farma_API_REST.Models
{
    public class Empleado
    {
        public int id_empleado              { get; set; }
        public string user_name             { get; set; }
        public string passwowrd             { get; set; }
        public int cedula                   { get; set; }
        public string nombres               { get; set; }
        public string apellidos             { get; set; }
        public string correo                { get; set; }
        public string fecha_nacimiento      { get; set; }
        public string direccion_domicilio   { get; set; }
        public string telefono              { get; set; }
        public int estado_vacuna            { get; set; }
        public string tipo_vacuna           { get; set; }
        public DateTime fecha_vacuna        { get; set; }
        public int numero_dosis             { get; set; }
        public DateTime date_create         { get; set; }
        public DateTime date_update         { get; set; }



    }
}