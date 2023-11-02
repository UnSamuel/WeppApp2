using Microsoft.AspNetCore.Mvc;
using The_Last_Dance_First_Try.Context;
using The_Last_Dance_First_Try.Models;

namespace The_Last_Dance_First_Try.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeguroController : Controller
    {
        public readonly AplicacionContext aplicacionContext;
        public SeguroController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }
        [HttpGet]
        [Route("MostrarSeguros")]
        public async Task<IActionResult> MostrarSeguro()
        {
            List<Seguro> seguros = aplicacionContext.Seguro.OrderByDescending(seguro => seguro.IdSeguro).ToList();
            return StatusCode(StatusCodes.Status200OK, seguros);

        }
        [HttpPost]
        [Route("CrearSeguros")]
        public async Task<IActionResult> CrearSeguro([FromBody] Seguro seguro)
        {
            aplicacionContext.Seguro.Add(seguro);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Creado Correctamente");

        }
        [HttpPut]
        [Route("EditarSeguros")]
        public async Task<IActionResult> EditarSeguro([FromBody] Seguro seguro)
        {
            aplicacionContext.Seguro.Update(seguro);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Editado Correctamente");

        }
        [HttpDelete]
        [Route("EliminarSeguros/")]
        public async Task<IActionResult> EliminarSeguro(int id)
        {
            Seguro seguro = aplicacionContext.Seguro.Find(id);
            aplicacionContext.Seguro.Remove(seguro);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Eliminado Correctamente");
        }
    }
}
