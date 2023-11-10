using Microsoft.AspNetCore.Mvc;
using Practico9;
namespace tl2_tp09_2023_exequiel1984.Controllers;

[ApiController]
[Route("[controller]")]

public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private ITareaRepository tareaRepository;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }

    [HttpPost]
    [Route("/api/tarea")]
    public ActionResult<Tarea> CrearTarea(Tarea tarea)
    {
        tareaRepository.Create(tarea);
        return Ok(tarea);
    }

    [HttpPut]
    [Route("/api/tarea/{id}/Nombre/{Nombre}")]
    public ActionResult<string> UpdTarea(int id, String Nombre)
    {
        tareaRepository.UpDateNombre(id, Nombre);
        return "Bien hecho";
    }

    [HttpPut]
    [Route("/api/tarea/{id}/Estado/{Estado}")]
    public ActionResult<string> UpdEstado(int id, EstadoTarea Estado)
    {
        tareaRepository.UpDateEstado(id, Estado);
        return "Bien hecho";
    }

    [HttpGet]
    [Route("/api/tarea/{id}")]
    public ActionResult<Tarea> GetTarea(int id)
    {
        Tarea tarea = tareaRepository.GetById(id);
        if(String.IsNullOrEmpty(tarea.Nombre))
            return NotFound("No lo encontré");
        else 
            return Ok(tarea);
    }
    /* [HttpGet]
    [Route("/api/tableros")]
    public ActionResult<IEnumerable<Tablero>> GetTableros(){
        List<Tablero> tableros = tableroRepository.GetAll();
        if (tableros.Count != 0)
            return Ok(tableros);
        else
            return BadRequest("Todavia no tengo tableros");
    } */
}