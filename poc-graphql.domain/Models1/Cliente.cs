using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class Cliente
{
    public Guid IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public Guid? IdUsuarioCreacion { get; set; }

    public Guid? IdUsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<ClientesUsuario> ClientesUsuarios { get; set; } = new List<ClientesUsuario>();

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
