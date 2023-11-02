using Microsoft.AspNetCore.Mvc;
using The_Last_Dance_First_Try.Context;
using The_Last_Dance_First_Try.Models;

namespace The_Last_Dance_First_Try.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalarioController : Controller
    {
        public readonly AplicacionContext aplicacionContext;
        public SalarioController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }
        [HttpGet]
        [Route("MostrarSalarios")]
        public async Task<IActionResult> MostrarSalario()
        {
            List<Salario> salarios = aplicacionContext.Salario.OrderByDescending(salario => salario.IdSalario).ToList();
            return StatusCode(StatusCodes.Status200OK, salarios);

        }
        [HttpPost]
        [Route("CrearSalarios")]
        public async Task<IActionResult> CrearSalario([FromBody] Salario salario)
        {
            aplicacionContext.Salario.Add(salario);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Creado Correctamente");

        }
        [HttpPut]
        [Route("EditarSalarios")]
        public async Task<IActionResult> EditarSalario([FromBody] Salario salario)
        {
            aplicacionContext.Salario.Update(salario);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Editado Correctamente");

        }
        [HttpDelete]
        [Route("EliminarSalarios/")]
        public async Task<IActionResult> EliminarSalario(int id)
        {
            Salario salario = aplicacionContext.Salario.Find(id);
            aplicacionContext.Salario.Remove(salario);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Eliminado Correctamente");
        }

    }
}
