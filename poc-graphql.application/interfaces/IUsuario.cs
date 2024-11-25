using poc_graphql.api.Models1;

namespace poc_graphql.application.interfaces
{
    public interface IUsuario
    {
        Task<List<Usuario>> Obtener();
    }
}
