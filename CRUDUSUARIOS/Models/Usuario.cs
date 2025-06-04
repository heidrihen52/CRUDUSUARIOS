using System;
using System.Collections.Generic;

namespace CRUDUSUARIOS.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }
    
    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public bool? Estatus { get; set; }

    public int? IdCargo { get; set; }

    public virtual Cargo? oCargo { get; set; }
}
