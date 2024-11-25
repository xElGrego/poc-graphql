using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class Role
{
    public Guid IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? Fecha { get; set; }

    public Guid IdCliente { get; set; }

    public Guid? IdUsuarioCreacion { get; set; }

    public Guid? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<GrupoRole> GrupoRoles { get; set; } = new List<GrupoRole>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
