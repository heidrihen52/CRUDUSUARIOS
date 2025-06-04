using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDUSUARIOS.Models.ViewModels
{
    public class UsuarioVM
    {
        public Usuario oUsuario { get; set; }   

        public List<SelectListItem> oListaCargo { get; set;  }
    }
}
