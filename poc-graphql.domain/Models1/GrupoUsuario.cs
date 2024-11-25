using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class GrupoUsuario
{
    public Guid IdGrupoUsuario { get; set; }

    public Guid IdUsuario { get; set; }

    public Guid IdGrupo { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Grupo IdGrupoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
