using System;
using System.Collections.Generic;

namespace poc_graphql.api.Models1;

public partial class Termino
{
    public Guid IdTerminos { get; set; }

    public Guid IdUsuario { get; set; }

    public string? IpCliente { get; set; }

    public string? NavegadorCliente { get; set; }

    public bool? TermsChecked { get; set; }

    public bool? PrivacyChecked { get; set; }

    public bool? SecurityChecked { get; set; }

    public DateTime? FechaAceptacion { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
