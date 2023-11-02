using Microsoft.AspNetCore.Mvc;
using The_Last_Dance_First_Try.Context;
using The_Last_Dance_First_Try.Models;

namespace The_Last_Dance_First_Try.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        public readonly AplicacionContext aplicacionContext;
        public EmpleadoController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }
        [HttpGet]
        [Route("MostrarEmpleados")]
        public async Task<IActionResult> MostrarEmpleado()
        {
            List<Empleado> empleados = aplicacionContext.Empleado.OrderByDescending(empleado => empleado.IdEmpleado).ToList();
            return StatusCode(StatusCodes.Status200OK, empleados);

        }
        [HttpPost]
        [Route("CrearEmpleados")]
        public async Task<IActionResult> CrearEmpleado([FromBody] Empleado empleado)
        {
            aplicacionContext.Empleado.Add(empleado);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Creado Correctamente");

        }
        [HttpPut]
        [Route("EditarEmpleado")]
        public async Task<IActionResult> EditarEmpleado([FromBody] Empleado empleado)
        {
            aplicacionContext.Empleado.Update(empleado);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Editado Correctamente");

        }
        [HttpDelete]
        [Route("EliminarEmpleado/")]
        public async Task<IActionResult> EliminarEmpleado(int id)
        {
            Empleado empleado = aplicacionContext.Empleado.Find(id);
            aplicacionContext.Empleado.Remove(empleado);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Eliminado Correctamente");
        }
    }
}
