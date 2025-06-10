using CRUDUSUARIOS.Models;
using CRUDUSUARIOS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUDUSUARIOS.Services
{
    public class UsuarioService
    {
        private readonly DbcrudcoreContext _context;

        public UsuarioService(DbcrudcoreContext context)
        {
            _context = context;
        }

        public List<Usuario> ObtenerUsuariosConCargo()
        {
            return _context.Usuarios.Include(c => c.oCargo).ToList();
        }

        public List<SelectListItem> ObtenerListaCargos()
        {
            return _context.Cargos.Select(c => new SelectListItem
            {
                Text = c.Descripcion,
                Value = c.IdCargo.ToString()
            }).ToList();
        }

        public UsuarioVM ObtenerUsuarioVM(int idUsuario)
        {
            var vm = new UsuarioVM
            {
                oUsuario = idUsuario == 0
                    ? new Usuario()
                    : _context.Usuarios.Find(idUsuario) ?? new Usuario(),
                oListaCargo = ObtenerListaCargos()
            };
            return vm;
        }

        public Usuario ObtenerUsuarioConCargo(int idUsuario)
        {
            return _context.Usuarios
                .Include(c => c.oCargo)
                    .FirstOrDefault(u => u.IdUsuario == idUsuario) ?? new Usuario();
        }

        public void GuardarUsuario(Usuario usuario)
        {
            usuario.Estatus = true;

            if (usuario.IdUsuario == 0)
                _context.Usuarios.Add(usuario);
            else
                _context.Usuarios.Update(usuario);

            _context.SaveChanges();
        }

        public void CambiarEstatus(int idUsuario, bool nuevoEstatus)
        {
            var usuario = _context.Usuarios.Find(idUsuario);
            if (usuario == null) return;

            usuario.Estatus = nuevoEstatus;
            _context.SaveChanges();
        }
    }
}
