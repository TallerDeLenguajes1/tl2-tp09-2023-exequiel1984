using Microsoft.AspNetCore.Mvc;
using Practico9;
namespace tl2_tp09_2023_exequiel1984.Controllers;

[ApiController]
[Route("[controller]")]

public class TableroController : ControllerBase
{
    private readonly ILogger<TableroController> _logger;
    private ITableroRepository tableroRepository;
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    [HttpPost]
    [Route("/api/Tablero")]
    public ActionResult<Tablero> CrearTablero(Tablero tablero)
    {
        tableroRepository.Create(tablero);
        return Ok(tablero);
    }

    [HttpGet]
    [Route("/api/tableros")]
    public ActionResult<IEnumerable<Tablero>> GetTableros(){
        List<Tablero> tableros = tableroRepository.GetAll();
        if (tableros.Count != 0)
            return Ok(tableros);
        else
            return BadRequest("Todavia no tengo tableros");
    }
}