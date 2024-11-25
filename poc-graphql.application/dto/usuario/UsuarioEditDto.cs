namespace poc_graphql.application.dto.usuario
{
    public class UsuarioEditDto
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool reestablecerContra {  get; set; }
    }
}
