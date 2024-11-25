using Microsoft.EntityFrameworkCore;
using poc_graphql.api.Models1;
using poc_graphql.application.dto.pagination;

namespace poc_graphql.infrasctructure.data.repositories.cliente.querys
{
    public class UsuarioQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Usuario>> GetUsuarios([Service] PermisosContext _context)
        {
            return await _context.Usuarios.ToListAsync();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<Usuario> GetUsuarioId([Service] PermisosContext _context, string identificacion)
        {
            return await _context.Usuarios.Where(x => x.Identificacion == identificacion).FirstOrDefaultAsync();
        }


        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<PaginationFilterResponse<Usuario>> GetUsuariosPagination(
            [Service] PermisosContext _context, string? identificacion, int start,int length,string fechaInicio,string fechaFin, string? orderBy = "Fecha",string? orderDirection = "ASC" 
        )
        {
            var response = new PaginationFilterResponse<Usuario>();
            var inicio = DateTime.Parse(fechaInicio);
            var fin = DateTime.Parse(fechaFin);

            inicio = inicio.Date;
            fin = fin.Date.AddDays(1).AddTicks(-1);

            var query = _context.Usuarios.Where(x => x.Activo == true && x.Fecha >= inicio && x.Fecha <= fin);

            if (!string.IsNullOrWhiteSpace(identificacion))
            {
                query = query.Where(u => u.Identificacion.Contains(identificacion));
            }

            query = orderBy switch
            {
                "Fecha" => orderDirection == "DESC" ? query.OrderByDescending(x => x.Fecha) : query.OrderBy(x => x.Fecha),
                "Identificacion" => orderDirection == "DESC" ? query.OrderByDescending(x => x.Identificacion) : query.OrderBy(x => x.Identificacion),
                "Nombre" => orderDirection == "DESC" ? query.OrderByDescending(x => x.Nombre) : query.OrderBy(x => x.Nombre),
                "Correo" => orderDirection == "DESC" ? query.OrderByDescending(x => x.Correo) : query.OrderBy(x => x.Correo),
                _ => query.OrderBy(x => x.Fecha)
            };

            response.pagination.Total = await query.CountAsync();
            var usuarios = await query
                .Skip(start)
                .Take(length)
                .ToListAsync();

            response.consulta = usuarios;
            response.pagination.Limit = length;
            response.pagination.Offset = start;
            response.pagination.Returned = usuarios.Count;
            return response;
        }
    }
}
