using Microsoft.AspNetCore.Mvc;
using The_Last_Dance_First_Try.Context;
using The_Last_Dance_First_Try.Models;

namespace The_Last_Dance_First_Try.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloController : Controller
    {
        public readonly AplicacionContext aplicacionContext;
        public TituloController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }
        [HttpGet]
        [Route("MostrarTitulo")]
        public async Task<IActionResult> MostrarTitulo()
        {
            List<Titulo> titulos = aplicacionContext.Titulo.OrderByDescending(titulo => titulo.IdTitulo).ToList();
            return StatusCode(StatusCodes.Status200OK, titulos);

        }
        [HttpPost]
        [Route("CrearTitulo")]
        public async Task<IActionResult> CrearTitulo([FromBody] Titulo titulo)
        {
            aplicacionContext.Titulo.Add(titulo);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Creado Correctamente");

        }
        [HttpPut]
        [Route("EditarTitulo")]
        public async Task<IActionResult> EditarTitulo([FromBody] Titulo titulo)
        {
            aplicacionContext.Titulo.Update(titulo);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Editado Correctamente");

        }
        [HttpDelete]
        [Route("EliminarTitulo/")]
        public async Task<IActionResult> EliminarTitulo(int id)
        {
            Titulo titulo = aplicacionContext.Titulo.Find(id);
            aplicacionContext.Titulo.Remove(titulo);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Eliminado Correctamente");
        }
    }
}
