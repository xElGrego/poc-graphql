using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class Token
{
    public Guid IdToken { get; set; }

    public string? Valor { get; set; }

    public Guid? IdUsuario { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public bool? Procesado { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
