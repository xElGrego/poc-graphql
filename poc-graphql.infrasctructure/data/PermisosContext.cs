using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace poc_graphql.api.Models1;

public partial class PermisosContext : DbContext
{
    public PermisosContext()
    {
    }

    public PermisosContext(DbContextOptions<PermisosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgrupacionEmpresa> AgrupacionEmpresas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClientesUsuario> ClientesUsuarios { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<GrupoRole> GrupoRoles { get; set; }

    public virtual DbSet<GrupoUsuario> GrupoUsuarios { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Termino> Terminos { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioEmpresa> UsuarioEmpresas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgrupacionEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdAgrupacionEmpresa).HasName("agrupacionEmpresa_pkey");

            entity.ToTable("agrupacionEmpresas");

            entity.Property(e => e.IdAgrupacionEmpresa)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idAgrupacionEmpresa");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(500)
                .HasColumnName("razonSocial");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("clientes_pkey");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idCliente");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.IdUsuarioCreacion).HasColumnName("idUsuarioCreacion");
            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("idUsuarioModificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<ClientesUsuario>(entity =>
        {
            entity.HasKey(e => e.IdClienteUsuario).HasName("clienteUsuarios_pkey");

            entity.ToTable("clientesUsuarios");

            entity.Property(e => e.IdClienteUsuario)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idClienteUsuario");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClientesUsuarios)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clienteUsuarios_idCliente_fkey");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ClientesUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clienteUsuarios_idUsuario_fkey");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("empresas_pkey");

            entity.ToTable("empresas");

            entity.Property(e => e.IdEmpresa)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idEmpresa");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.IdAgrupacionEmpresa).HasColumnName("idAgrupacionEmpresa");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(30)
                .HasColumnName("identificacion");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(500)
                .HasColumnName("razonSocial");

            entity.HasOne(d => d.IdAgrupacionEmpresaNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.IdAgrupacionEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idAgrupacionEmpresa_empresas");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("grupos_pkey");

            entity.ToTable("grupos");

            entity.Property(e => e.IdGrupo)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idGrupo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(false)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Idusuariocreacion).HasColumnName("idusuariocreacion");
            entity.Property(e => e.Idusuariomodificacion).HasColumnName("idusuariomodificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_constraint_grupos_idcliente");
        });

        modelBuilder.Entity<GrupoRole>(entity =>
        {
            entity.HasKey(e => e.IdGrupoRoles).HasName("grupoRoles_pkey");

            entity.ToTable("grupoRoles");

            entity.Property(e => e.IdGrupoRoles)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idGrupoRoles");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.GrupoRoles)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grupoRoles_idGrupo_fkey");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.GrupoRoles)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grupoRoles_idRol_fkey");
        });

        modelBuilder.Entity<GrupoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdGrupoUsuario).HasName("grupoUsuarios_pkey");

            entity.ToTable("grupoUsuarios");

            entity.Property(e => e.IdGrupoUsuario)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idGrupoUsuario");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.GrupoUsuarios)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grupoUsuarios_idGrupo_fkey");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.GrupoUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grupoUsuarios_idUsuario_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idRol");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdUsuarioCreacion).HasColumnName("idUsuarioCreacion");
            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("idUsuarioModificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Roles)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_constraint_clientes_roles");
        });

        modelBuilder.Entity<Termino>(entity =>
        {
            entity.HasKey(e => e.IdTerminos).HasName("terminos_pkey");

            entity.ToTable("terminos");

            entity.Property(e => e.IdTerminos)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idTerminos");
            entity.Property(e => e.FechaAceptacion).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FechaPublicacion).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.IpCliente)
                .HasColumnType("character varying")
                .HasColumnName("ipCliente");
            entity.Property(e => e.NavegadorCliente)
                .HasColumnType("character varying")
                .HasColumnName("navegadorCliente");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Terminos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_terminos_usuario");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.IdToken).HasName("token_pkey");

            entity.ToTable("tokens");

            entity.Property(e => e.IdToken)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idToken");
            entity.Property(e => e.Fecha)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Procesado)
                .HasDefaultValue(false)
                .HasColumnName("procesado");
            entity.Property(e => e.Valor)
                .HasMaxLength(500)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("idUsuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("pk__usuarios__645723a698df0317");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Identificacion, "usuarios_unique").IsUnique();

            entity.Property(e => e.IdUsuario)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idUsuario");
            entity.Property(e => e.Activo)
                .HasDefaultValue(false)
                .HasColumnName("activo");
            entity.Property(e => e.Actualizado)
                .HasDefaultValue(false)
                .HasColumnName("actualizado");
            entity.Property(e => e.AplicativoOrigen).HasColumnName("aplicativoOrigen");
            entity.Property(e => e.Clave)
                .HasMaxLength(350)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(350)
                .HasColumnName("correo");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.IdUsuarioCreacion).HasColumnName("idUsuarioCreacion");
            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("idUsuarioModificacion");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(20)
                .HasColumnName("identificacion");
            entity.Property(e => e.IsReestablecerContra).HasColumnName("isReestablecerContra");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
            entity.Property(e => e.Salt)
                .HasMaxLength(15)
                .HasColumnName("salt");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(350)
                .HasColumnName("usuario");

            entity.HasOne(d => d.AplicativoOrigenNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.AplicativoOrigen)
                .HasConstraintName("usuarios_clientes_fk");
        });

        modelBuilder.Entity<UsuarioEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioEmpresa).HasName("usuarioEmpresas_pkey");

            entity.ToTable("usuarioEmpresas");

            entity.Property(e => e.IdUsuarioEmpresa)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("idUsuarioEmpresa");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.UsuarioEmpresas)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarioEmpresas_idEmpresa_fkey");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioEmpresas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarioEmpresas_idUsuario_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
