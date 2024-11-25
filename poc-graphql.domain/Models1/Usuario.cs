using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public string? Usuario1 { get; set; }

    public string? Clave { get; set; }

    public bool? Activo { get; set; }

    public string? Correo { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? Identificacion { get; set; }

    public bool? Actualizado { get; set; }

    public string? Nombre { get; set; }

    public string? Salt { get; set; }

    public bool? IsReestablecerContra { get; set; }

    public Guid? IdUsuarioCreacion { get; set; }

    public Guid? IdUsuarioModificacion { get; set; }

    public Guid? AplicativoOrigen { get; set; }

    public virtual Cliente? AplicativoOrigenNavigation { get; set; }

    public virtual ICollection<ClientesUsuario> ClientesUsuarios { get; set; } = new List<ClientesUsuario>();

    public virtual ICollection<GrupoUsuario> GrupoUsuarios { get; set; } = new List<GrupoUsuario>();

    public virtual ICollection<Termino> Terminos { get; set; } = new List<Termino>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();

    public virtual ICollection<UsuarioEmpresa> UsuarioEmpresas { get; set; } = new List<UsuarioEmpresa>();
}
