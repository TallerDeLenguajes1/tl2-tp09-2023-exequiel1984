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

    [HttpPost]
    [Route("/api/usuario")]
    public ActionResult<Usuario> CrearUsuario(Usuario usuario)
    {
        usuarioRepository.Create(usuario);
        return Ok(usuario);
    }

    [HttpGet]
    [Route("/api/usuarios")]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        return Ok(usuarioRepository.GetAll());
    }

    [HttpGet]
    [Route("/api/usuario/{id}")]
    public ActionResult<Usuario> GetUsuario(int id)
    {
        Usuario usuario = usuarioRepository.GetById(id);
        if(String.IsNullOrEmpty(usuario.NombreDeUsuario))
            return NotFound("No lo encontré");
        else 
            return Ok(usuario);
    }

    [HttpPut]
    [Route("/api/usuario/{id}/Nombre")]
    public ActionResult<string> UpdUsuario(int id, Usuario usuario)
    {
        usuarioRepository.Update(id, usuario);
        return "Bien hecho";
    }

    /* [HttpDelete("DeleteTarea")]
    public ActionResult<Tarea> DeleteTarea(int id)
    {
        var auxTarea = manejoTarea.DeleteTarea(id);
        if(auxTarea == null)
            return BadRequest();
        else
            return auxTarea;
    } */

    
    /* [HttpGet]
    [Route("GetTareasCompletadas")]
    public ActionResult<List<Tarea>> GetTareasCompletadas()
    {
        return Ok(manejoTarea.GetTareasCompletadas());
    } */
}