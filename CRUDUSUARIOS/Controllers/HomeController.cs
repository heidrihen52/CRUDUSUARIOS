using CRUDUSUARIOS.Models;
using CRUDUSUARIOS.Models.ViewModels;
using CRUDUSUARIOS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUSUARIOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public HomeController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            var lista = _usuarioService.ObtenerUsuariosConCargo();
            ViewBag.ListaCargo = _usuarioService.ObtenerListaCargos();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Usuario_Detalle(int IdUsuario)
        {
            var vm = _usuarioService.ObtenerUsuarioVM(IdUsuario);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Usuario_Detalles(int IdUsuario)
        {
            var usuario = _usuarioService.ObtenerUsuarioConCargo(IdUsuario);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Usuario_Detalle(UsuarioVM oUsuarioVM)
        {
            _usuarioService.GuardarUsuario(oUsuarioVM.oUsuario);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int IdUsuario)
        {
            var usuario = _usuarioService.ObtenerUsuarioConCargo(IdUsuario);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult CambiarEstatus(int idUsuario, bool nuevoEstatus)
        {
            _usuarioService.CambiarEstatus(idUsuario, nuevoEstatus);
            return RedirectToAction("Index", "Home");
        }
    }
}
