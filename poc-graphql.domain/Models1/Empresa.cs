using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class Empresa
{
    public Guid IdEmpresa { get; set; }

    public string? RazonSocial { get; set; }

    public string? Identificacion { get; set; }

    public bool? Activo { get; set; }

    public Guid IdAgrupacionEmpresa { get; set; }

    public virtual AgrupacionEmpresa IdAgrupacionEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<UsuarioEmpresa> UsuarioEmpresas { get; set; } = new List<UsuarioEmpresa>();
}
