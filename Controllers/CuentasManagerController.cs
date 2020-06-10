using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RappiApi.Models;
using RappiApi.Models.ViewModels;
using RappiApi.Services.Interfaces;

namespace RappiApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentasManagerController : ControllerBase
    {
        private readonly ILogger<CuentasManagerController> _logger;
        private readonly IConfiguration _config;
        private SignInManager<UsuarioAplicacion> _signInManager;
        private UserManager<UsuarioAplicacion> _userManager;
        private readonly IGeneradorToken _generadorToken;
        public CuentasManagerController(
            ILogger<CuentasManagerController> logger,
            IConfiguration config,
            IGeneradorToken generadorToken,
            SignInManager<UsuarioAplicacion> signInManager,
            UserManager<UsuarioAplicacion> userManager)
        {
            _logger = logger;
            _config = config;
            _signInManager = signInManager;
            _generadorToken = generadorToken;
            _userManager = userManager;

        }

       
        [HttpPost]
        [Route("ObtenerToken")]
        [ActionName("ObtenerToken")]
        public async Task<IActionResult> ObtenerToken(LoginViewModel login)
        {
            HttpResponseMessage _responseMessage = new HttpResponseMessage();
            Microsoft.AspNetCore.Identity.SignInResult resultado =
            await _signInManager.PasswordSignInAsync(
                login.NombreUsuario,
                login.Contrasena,
                login.Recuerdame, lockoutOnFailure: true);

            if (resultado.Succeeded)
                return _generadorToken.GenerarToken(login);

            return new BadRequestObjectResult(
                new JsonResult(new
            {
                error = string.Format(
                CultureInfo.CurrentCulture,
                "Error de autenticación")
            }));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("CrearUsuarioApp")]
        [ActionName("CrearUsuarioApp")]
        public async Task<IActionResult> CrearUsuarioApp(CrearUsuarioViewModel usuario)
        {
            var user = new UsuarioAplicacion { UserName = usuario.Usuario, Email = usuario.Usuario };
            var result = await _userManager.CreateAsync(user, usuario.Password);
            if (result.Succeeded)
            {
                return Ok(new JsonResult(new
                {
                    success = string.Format(
                   CultureInfo.CurrentCulture,
                   "usuario creado con exito")
                }));
            }

            return BadRequest(new JsonResult(new
            {
                error = string.Format(
                  CultureInfo.CurrentCulture,
                  "No se pudo crear el usuario.")
            }));
        }

          [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("EliminarUsuarioApp")]
        [ActionName("EliminarUsuarioApp")]
        public async Task<IActionResult> EliminarUsuarioApp(CrearUsuarioViewModel usuario)
        {
            var user = new UsuarioAplicacion { UserName = usuario.Usuario, Email = usuario.Usuario };
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok(new JsonResult(new
                {
                    success = string.Format(
                   CultureInfo.CurrentCulture,
                   "usuario eliminado con exito")
                }));
            }

            return BadRequest(new JsonResult(new
            {
                error = string.Format(
                  CultureInfo.CurrentCulture,
                  "No se pudo eliminar el usuario.")
            }));
        }
    }
}