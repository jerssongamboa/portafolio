using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accidente> Accidentes { get; set; } = null!;
        public virtual DbSet<Actividade> Actividades { get; set; } = null!;
        public virtual DbSet<Administrador> Administradors { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Comuna> Comunas { get; set; } = null!;
        public virtual DbSet<Contrato> Contratos { get; set; } = null!;
        public virtual DbSet<Estadopago> Estadopagos { get; set; } = null!;
        public virtual DbSet<Estadousuario> Estadousuarios { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Profesional> Profesionals { get; set; } = null!;
        public virtual DbSet<Profesionalactividad> Profesionalactividads { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Reporte> Reportes { get; set; } = null!;
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseOracle("User Id=usuario_ef_core;Password=123456;Data Source=localhost:1521/xe;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("USUARIO_EF_CORE");

            modelBuilder.Entity<Accidente>(entity =>
            {
                entity.HasKey(e => e.IdAccidente)
                    .HasName("PK_ACCIDENTE");

                entity.ToTable("ACCIDENTES");

                entity.Property(e => e.IdAccidente)
                    .HasColumnType("NUMBER(20)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_ACCIDENTE");

                entity.Property(e => e.ClienteRut)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTE_RUT");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.FechaAccidente)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_ACCIDENTE");

                entity.HasOne(d => d.ClienteRutNavigation)
                    .WithMany(p => p.Accidentes)
                    .HasForeignKey(d => d.ClienteRut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLIENTE_ACCIDENTES_FK");
            });

            modelBuilder.Entity<Actividade>(entity =>
            {
                entity.HasKey(e => e.IdActividad);

                entity.ToTable("ACTIVIDADES");

                entity.Property(e => e.IdActividad)
                    .HasColumnType("NUMBER(20)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_ACTIVIDAD");

                entity.Property(e => e.ClienteRut)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTE_RUT");

                entity.Property(e => e.ContratoId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRATO_ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Extra)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EXTRA");

                entity.Property(e => e.FechaPlanificada)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_PLANIFICADA");

                entity.Property(e => e.FechaTerminoEstipulado)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_TERMINO_ESTIPULADO");

                entity.Property(e => e.FechaTerminoReal)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_TERMINO_REAL");

                entity.Property(e => e.ProfesionalAsignado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PROFESIONAL_ASIGNADO");

                entity.Property(e => e.TipoActividad)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_ACTIVIDAD");

                entity.HasOne(d => d.ClienteRutNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.ClienteRut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLIENTE_ACTIVIDADES_FK");

                entity.HasOne(d => d.Contrato)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.ContratoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRATO_ACTIVIDADES_FK");

                entity.HasOne(d => d.ProfesionalAsignadoNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.ProfesionalAsignado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PROFESIONAL_ACTIVIDADES_FK");
            });

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.Rut);

                entity.ToTable("ADMINISTRADOR");

                entity.HasIndex(e => e.Correo, "UQ_ADMINISTRADOR_CORREO")
                    .IsUnique();

                entity.Property(e => e.Rut)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RUT");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_MATERNO");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_PATERNO");

                entity.Property(e => e.ComunaIdComuna)
                    .HasPrecision(10)
                    .HasColumnName("COMUNA_ID_COMUNA");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.EstadousuarioId)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ESTADOUSUARIO_ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.RegionIdRegion)
                    .HasPrecision(10)
                    .HasColumnName("REGION_ID_REGION");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.TipousuarioId)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("TIPOUSUARIO_ID");

                entity.HasOne(d => d.ComunaIdComunaNavigation)
                    .WithMany(p => p.Administradors)
                    .HasForeignKey(d => d.ComunaIdComuna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("COMUNA_ADMINISTRADOR_FK");

                entity.HasOne(d => d.Estadousuario)
                    .WithMany(p => p.Administradors)
                    .HasForeignKey(d => d.EstadousuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ESTADOUSUARIO_ADMINISTRADOR_FK");

                entity.HasOne(d => d.RegionIdRegionNavigation)
                    .WithMany(p => p.Administradors)
                    .HasForeignKey(d => d.RegionIdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGION_ADMINISTRADOR_FK");

                entity.HasOne(d => d.Tipousuario)
                    .WithMany(p => p.Administradors)
                    .HasForeignKey(d => d.TipousuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPOUSUARIO_ADMINISTRADOR_FK");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Rut);

                entity.ToTable("CLIENTE");

                entity.HasIndex(e => e.Correo, "UQ_CLIENTE_CORREO")
                    .IsUnique();

                entity.Property(e => e.Rut)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RUT");

                entity.Property(e => e.ComunaIdComuna)
                    .HasPrecision(10)
                    .HasColumnName("COMUNA_ID_COMUNA");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.EstadousuarioId)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ESTADOUSUARIO_ID");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RAZON_SOCIAL");

                entity.Property(e => e.RegionIdRegion)
                    .HasPrecision(10)
                    .HasColumnName("REGION_ID_REGION");

                entity.Property(e => e.Rubro)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RUBRO");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.TipousuarioId)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("TIPOUSUARIO_ID");

                entity.HasOne(d => d.ComunaIdComunaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.ComunaIdComuna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("COMUNA_CLIENTE_FK");

                entity.HasOne(d => d.Estadousuario)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.EstadousuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ESTADOUSUARIO_CLIENTE_FK");

                entity.HasOne(d => d.RegionIdRegionNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.RegionIdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGION_CLIENTE_FK");

                entity.HasOne(d => d.Tipousuario)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.TipousuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPOUSUARIO_CLIENTE_FK");
            });

            modelBuilder.Entity<Comuna>(entity =>
            {
                entity.HasKey(e => e.IdComuna);

                entity.ToTable("COMUNA");

                entity.HasIndex(e => e.Nombre, "UQ_COMUNA_NOMBRE")
                    .IsUnique();

                entity.Property(e => e.IdComuna)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_COMUNA");

                entity.Property(e => e.IdRegion)
                    .HasPrecision(10)
                    .HasColumnName("ID_REGION");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.Comunas)
                    .HasForeignKey(d => d.IdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGION_COMUNA_FK");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato)
                    .HasName("PK_ID_CONTRATO");

                entity.ToTable("CONTRATO");

                entity.Property(e => e.IdContrato)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRATO");

                entity.Property(e => e.ClienteRut)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTE_RUT");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_INICIO");

                entity.Property(e => e.FechaTermino)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_TERMINO");

                entity.HasOne(d => d.ClienteRutNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.ClienteRut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLIENTE_CONTRATO_FK");
            });

            modelBuilder.Entity<Estadopago>(entity =>
            {
                entity.ToTable("ESTADOPAGO");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Estadousuario>(entity =>
            {
                entity.ToTable("ESTADOUSUARIO");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago);

                entity.ToTable("PAGOS");

                entity.Property(e => e.IdPago)
                    .HasColumnType("NUMBER(20)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_PAGO");

                entity.Property(e => e.ClienteRut)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTE_RUT");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_VENCIMIENTO");

                entity.Property(e => e.IdEstado)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ID_ESTADO");

                entity.Property(e => e.Monto)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("MONTO");

                entity.HasOne(d => d.ClienteRutNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.ClienteRut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLIENTE_PAGOS_FK");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ESTADOPAGO_PAGO_FK");
            });

            modelBuilder.Entity<Profesional>(entity =>
            {
                entity.HasKey(e => e.Rut);

                entity.ToTable("PROFESIONAL");

                entity.HasIndex(e => e.Correo, "UQ_PROFESIONAL_CORREO")
                    .IsUnique();

                entity.Property(e => e.Rut)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RUT");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_MATERNO");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_PATERNO");

                entity.Property(e => e.ComunaIdComuna)
                    .HasPrecision(10)
                    .HasColumnName("COMUNA_ID_COMUNA");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.EstadousuarioId)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ESTADOUSUARIO_ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.ProfesionalActId)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PROFESIONAL_ACT_ID");

                entity.Property(e => e.RegionIdRegion)
                    .HasPrecision(10)
                    .HasColumnName("REGION_ID_REGION");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.TipousuarioId)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("TIPOUSUARIO_ID");

                entity.HasOne(d => d.ComunaIdComunaNavigation)
                    .WithMany(p => p.Profesionals)
                    .HasForeignKey(d => d.ComunaIdComuna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("COMUNA_PROFESIONAL_FK");

                entity.HasOne(d => d.Estadousuario)
                    .WithMany(p => p.Profesionals)
                    .HasForeignKey(d => d.EstadousuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ESTADOUSUARIO_PROFESIONAL_FK");

                entity.HasOne(d => d.ProfesionalAct)
                    .WithMany(p => p.Profesionals)
                    .HasForeignKey(d => d.ProfesionalActId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PROFESIONALACT_PROF_FK");

                entity.HasOne(d => d.RegionIdRegionNavigation)
                    .WithMany(p => p.Profesionals)
                    .HasForeignKey(d => d.RegionIdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGION_PROFESIONAL_FK");

                entity.HasOne(d => d.Tipousuario)
                    .WithMany(p => p.Profesionals)
                    .HasForeignKey(d => d.TipousuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPOUSUARIO_PROFESIONAL_FK");
            });

            modelBuilder.Entity<Profesionalactividad>(entity =>
            {
                entity.ToTable("PROFESIONALACTIVIDAD");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ID");

                entity.Property(e => e.Actividad)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVIDAD");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.IdRegion);

                entity.ToTable("REGION");

                entity.HasIndex(e => e.Nombre, "UQ_REGION_NOMBRE")
                    .IsUnique();

                entity.Property(e => e.IdRegion)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_REGION");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte);

                entity.ToTable("REPORTES");

                entity.Property(e => e.IdReporte)
                    .HasColumnType("NUMBER(20)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_REPORTE");

                entity.Property(e => e.Archivo)
                    .HasColumnType("BFILE")
                    .HasColumnName("ARCHIVO");

                entity.Property(e => e.ClienteRut)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTE_RUT");

                entity.Property(e => e.FechaEmision)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_EMISION");

                entity.HasOne(d => d.ClienteRutNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.ClienteRut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLIENTE_REPORTES_FK");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.ToTable("TIPOUSUARIO");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.HasSequence("ACCIDENTES_SEQUENCE");

            modelBuilder.HasSequence("ACTIVIDADES_SEQUENCE");

            modelBuilder.HasSequence("PAGOS_SEQUENCE");

            modelBuilder.HasSequence("REPORTES_SEQUENCE");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
