using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class AgrupacionEmpresa
{
    public Guid IdAgrupacionEmpresa { get; set; }

    public string? RazonSocial { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
