using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class UsuarioEmpresa
{
    public Guid IdUsuarioEmpresa { get; set; }

    public Guid IdUsuario { get; set; }

    public Guid IdEmpresa { get; set; }

    public bool? Activo { get; set; }

    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
