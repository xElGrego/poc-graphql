using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class GrupoRole
{
    public Guid IdGrupoRoles { get; set; }

    public Guid IdGrupo { get; set; }

    public Guid IdRol { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Grupo IdGrupoNavigation { get; set; } = null!;

    public virtual Role IdRolNavigation { get; set; } = null!;
}
