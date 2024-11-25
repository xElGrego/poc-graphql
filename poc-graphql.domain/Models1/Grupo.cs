using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class Grupo
{
    public Guid IdGrupo { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? Fecha { get; set; }

    public Guid IdCliente { get; set; }

    public Guid? Idusuariocreacion { get; set; }

    public Guid? Idusuariomodificacion { get; set; }

    public DateTime? Fechamodificacion { get; set; }

    public virtual ICollection<GrupoRole> GrupoRoles { get; set; } = new List<GrupoRole>();

    public virtual ICollection<GrupoUsuario> GrupoUsuarios { get; set; } = new List<GrupoUsuario>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
