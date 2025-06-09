using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CRUDUSUARIOS.Models;
using CRUDUSUARIOS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUSUARIOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbcrudcoreContext _DBContext;

        public HomeController(DbcrudcoreContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Usuario> lista = _DBContext.Usuarios.Include(c => c.oCargo).ToList();
            ViewBag.ListaCargo = _DBContext.Cargos.Select(c => new SelectListItem
            {
                Text = c.Descripcion,
                Value = c.IdCargo.ToString()
            }).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Usuario_Detalle(int IdUsuario)
        {
           UsuarioVM oUsuarioVM = new UsuarioVM(){
               oUsuario = new Usuario(),
               oListaCargo = _DBContext.Cargos.Select(cargo => new SelectListItem(){
                   Text  = cargo.Descripcion,
                   Value = cargo.IdCargo.ToString()
               }).ToList()
           };
            if (IdUsuario != 0) {
                oUsuarioVM.oUsuario = _DBContext.Usuarios.Find(IdUsuario);
            }


            return View(oUsuarioVM);
        }

        [HttpGet]
        public IActionResult Usuario_Detalles(int IdUsuario)
        {

            Usuario oUsuario = _DBContext.Usuarios.Include(c => c.oCargo).Where(u => u.IdUsuario == IdUsuario).FirstOrDefault();
            return View(oUsuario);
        }


        [HttpPost]
        public IActionResult Usuario_Detalle(UsuarioVM oUsuarioVM)
        {
            if (oUsuarioVM.oUsuario.IdUsuario == 0)
            {
                oUsuarioVM.oUsuario.Estatus = true;
                _DBContext.Usuarios.Add(oUsuarioVM.oUsuario);
            }
            else
            {
                oUsuarioVM.oUsuario.Estatus = true;
                _DBContext.Usuarios.Update(oUsuarioVM.oUsuario);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Eliminar(int IdUsuario)
        {

            Usuario oUsuario = _DBContext.Usuarios.Include(c => c.oCargo).Where(u => u.IdUsuario == IdUsuario).FirstOrDefault();
            return View(oUsuario);
        }


       

        [HttpPost]
        public IActionResult CambiarEstatus(int idUsuario, bool nuevoEstatus)
        {
            var usuario = _DBContext.Usuarios.Find(idUsuario);
            if (usuario == null)
                return NotFound();

            usuario.Estatus = nuevoEstatus;
            _DBContext.SaveChanges();

            return RedirectToAction("Index","Home");
        }

    }
}
