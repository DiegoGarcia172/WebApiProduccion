using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProduccion.Custom;
using WebApiProduccion.Models;
using WebApiProduccion.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using WebApiProduccion.Data;
using NuGet.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApiProduccion.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class Prueba : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
