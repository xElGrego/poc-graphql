using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class ClientesUsuario
{
    public Guid IdClienteUsuario { get; set; }

    public Guid IdUsuario { get; set; }

    public Guid IdCliente { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
