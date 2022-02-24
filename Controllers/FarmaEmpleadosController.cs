using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using farma_API_REST.Models;
using farma_API_REST.Persistence;

namespace farma_API_REST.Controllers
{
    public class FarmaEmpleadosController : ApiController
    {
        Bussines b = new Bussines();

        [HttpGet]
        [Route("get/empleados")]
        public IHttpActionResult GetEmpleados()
        {
            try
            {
                var ListaEmpleados = b.ListarEmpleados();
                return Ok(ListaEmpleados);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("insert")]
        public IHttpActionResult InsertEmpleado([FromBody] InsertEmpleado emp)
        {

            try
            {
                if ((string.IsNullOrEmpty(emp.nombres)) ||
                                   (emp.cedula).Equals(null) ||
                                   (string.IsNullOrEmpty(emp.apellidos)) ||
                                   (string.IsNullOrEmpty(emp.correo)))
                {
                    return BadRequest("No se permiten campos vacios");
                }
                else
                {
                    var res = b.InsertarEmpleado(emp);
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }             
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdateEmpleado([FromBody] UpdateEmpleado uemp)
        {
            try
            {
                var r = b.ActualizarEmpleado(uemp);
                return Ok(r);
            }
            catch (Exception ex )
            {
                return BadRequest(ex.Message)  ;
            }
         
        }

        [HttpGet]
        [Route("get/estadovacuna")]
        public IHttpActionResult GetEmpleadosEstadoVac([FromUri] int estado_vacuna)
        {
            try
            {
                var ListaEmpleados = b.GetEmpleadosEstadoVac(estado_vacuna);
                return Ok(ListaEmpleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("get/tipovacuna")]
        public IHttpActionResult GetEmpleadosTipoVac([FromUri]string tipo_vacuna)
        {
            try
            {
                var ListaEmpleados = b.GetEmpleadosTipoVac(tipo_vacuna);
                return Ok(ListaEmpleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("get/fechavacuna")]
        public IHttpActionResult GetEmpleadosFechaVac([FromUri]  DateTime fecha_vacuna)
        {
            try
            {
                var ListaEmpleados = b.GetEmpleadosFechaVac(fecha_vacuna);
                return Ok(ListaEmpleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("get/empleado")]
        public IHttpActionResult GetEmpleado([FromUri] int cedula)
        {
            try
            {
                var empleado = b.GetEmpleado(cedula);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
