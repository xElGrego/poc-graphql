using Microsoft.EntityFrameworkCore;
using poc_graphql.api.Models1;
using poc_graphql.application.dto.usuario;
using poc_graphql.application.dto.reponse;
using poc_graphql.application.exceptions;
using System.Text.RegularExpressions;
using HotChocolate.Subscriptions;

namespace poc_graphql.infrasctructure.data.repositories.usuario.mutation
{
    public class UsuarioMutation
    {
        private readonly ITopicEventSender _eventSender;

        public UsuarioMutation(ITopicEventSender eventSender)
        {
            _eventSender = eventSender;
        }

        public async Task<ResponseDto> Create([Service] PermisosContext _context, UsuarioAddDto usuarioDto)
        {
            var response = new ResponseDto();

            try
            {
                var usuarioExist = await _context.Usuarios.Where(u => u.Identificacion == usuarioDto.Identificacion.Trim()).FirstOrDefaultAsync();

                if (usuarioExist != null)
                {
                    throw new PocGraphqlException("El usuario con esta identificación o correo ya existe.");
                }

                var usuario = new Usuario()
                {
                    IdUsuario = Guid.NewGuid(),
                    Correo = usuarioDto.Correo,
                    Identificacion = usuarioDto.Identificacion,
                    Nombre = usuarioDto.Nombre,
                    Usuario1 = usuarioDto.Identificacion,
                    Activo = true
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                response.response = "Usuario creado con éxito";
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }

        public async Task<ResponseDto> Edit([Service] PermisosContext _context, UsuarioEditDto usuarioDto)
        {
            var response = new ResponseDto();

            try
            {
                if (!IsValidEmail(usuarioDto.Correo.Trim()))
                {
                    throw new PocGraphqlException("El correo proporcionado no es válido.");
                }

                var usuario = await _context.Usuarios.Where(u => u.Identificacion == usuarioDto.Identificacion.Trim()).FirstOrDefaultAsync();

                if (usuario == null)
                {
                    throw new PocGraphqlException("El usuario con esta identificación o correo ya existe.");
                }

                usuario.Nombre = usuarioDto.Nombre;
                usuario.Correo = usuarioDto.Correo.Trim();
                usuario.IsReestablecerContra = usuarioDto.reestablecerContra;
                await _context.SaveChangesAsync();
                response.response = "Usuario editado con éxito";
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
        }

    }
}
