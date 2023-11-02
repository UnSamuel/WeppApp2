using Microsoft.AspNetCore.Mvc;
using The_Last_Dance_First_Try.Context;
using The_Last_Dance_First_Try.Models;

namespace The_Last_Dance_First_Try.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : Controller
    {
        public readonly AplicacionContext aplicacionContext;
        public DepartamentoController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }
        [HttpGet]
        [Route("MostrarDepartamentos")]
        public async Task<IActionResult> MostrarDepartamento()
        {
            List<Departamento> departamentos = aplicacionContext.Departamento.OrderByDescending(departamento => departamento.IdDepartamento).ToList();
            return StatusCode(StatusCodes.Status200OK, departamentos);

        }
        [HttpPost]
        [Route("CrearDepartamento")]
        public async Task<IActionResult> CrearDepartamento([FromBody] Departamento departamento)
        {
            aplicacionContext.Departamento.Add(departamento);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Creado Correctamente");

        }
        [HttpPut]
        [Route("EditarDepartamentos")]
        public async Task<IActionResult> EditarDepartamento([FromBody] Departamento departamento)
        {
            aplicacionContext.Departamento.Update(departamento);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Editado Correctamente");

        }
        [HttpDelete]
        [Route("EliminarDepartamento/")]
        public async Task<IActionResult> EliminarDepartamento(int id)
        {
            Departamento departamento = aplicacionContext.Departamento.Find(id);
            aplicacionContext.Departamento.Remove(departamento);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Eliminado Correctamente");
        }


    }

}

