using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProduccion.Custom;
using WebApiProduccion.Models;
using WebApiProduccion.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using WebApiProduccion.Data;
using NuGet.Common;

namespace WebApiProduccion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccesoController : ControllerBase
    {
        private readonly ProduccionDbContext _dbContext;
        private readonly Utilidades _utilidades;
        public AccesoController(ProduccionDbContext dbContext, Utilidades utilidades)
        {
            _dbContext = dbContext;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult>Registrar(UsuarioDTO objeto)
        {
            var modeloUsuario = new Usuario 
            { 
                username = objeto.Nombre,
                email = objeto.Correo,
                password = _utilidades.encriptar(objeto.Clave)

            };

            await _dbContext.Usuario.AddAsync(modeloUsuario);
            await _dbContext.SaveChangesAsync();

            if(modeloUsuario.ID != 0)
            {
                return StatusCode(StatusCodes.Status200OK, new { IsSuccess = true });
            }
            return StatusCode(StatusCodes.Status200OK, new { IsSuccess = false });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _dbContext.Usuario
                .Where(u =>
                    u.email == objeto.Correo &&
                    u.password == _utilidades.encriptar(objeto.Clave)
                    ).FirstOrDefaultAsync();
            if(usuarioEncontrado == null)
            {
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = false, token = ""});
            }
            return StatusCode(StatusCodes.Status200OK, new {isSuccess = true, token= _utilidades.generarJWT(usuarioEncontrado)});
                
        }

    }
}
