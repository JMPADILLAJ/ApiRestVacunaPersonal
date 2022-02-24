using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace farma_API_REST.Models
{
    public class InsertEmpleado
    {
        public int cedula { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }

    }
}