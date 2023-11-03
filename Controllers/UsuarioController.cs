using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Practico9;
namespace tl2_tp09_2023_exequiel1984.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository usuarioRepository;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost("CrearUsuario")]
    public ActionResult<Usuario> CrearUsuario(Usuario usuario)
    {
        usuarioRepository.Create(usuario);
        return Ok(usuario);
    }

    /* [HttpGet("GetTarea")]
    public ActionResult<Tarea> GetTarea(int id)
    {
        var tarea = manejoTarea.GetTarea(id);
        if(tarea == null)
            return BadRequest();
        else 
            return tarea;
    }

    [HttpPut("UpdTarea")]
    public ActionResult<Tarea> UpdTarea(Tarea tarea)
    {
        var auxTarea = manejoTarea.UpdTarea(tarea);
        if(auxTarea == null)
            return BadRequest();
        else
            return auxTarea;
    }

    [HttpDelete("DeleteTarea")]
    public ActionResult<Tarea> DeleteTarea(int id)
    {
        var auxTarea = manejoTarea.DeleteTarea(id);
        if(auxTarea == null)
            return BadRequest();
        else
            return auxTarea;
    }

    [HttpGet]
    [Route("GetTareas")]
    public ActionResult<List<Tarea>> GetTareas()
    {
        return Ok(manejoTarea.GetTareas());
    }

    [HttpGet]
    [Route("GetTareasCompletadas")]
    public ActionResult<List<Tarea>> GetTareasCompletadas()
    {
        return Ok(manejoTarea.GetTareasCompletadas());
    } */
}