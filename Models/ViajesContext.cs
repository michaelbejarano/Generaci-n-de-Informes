using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace generacionDeInformes.Models;

public partial class ViajesContext : DbContext
{
    public ViajesContext()
    {
    }

    public ViajesContext(DbContextOptions<ViajesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<EvaluacionesProveedore> EvaluacionesProveedores { get; set; }

    public virtual DbSet<Itinerario> Itinerarios { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Paquete> Paquetes { get; set; }

    public virtual DbSet<PaqueteServicio> PaqueteServicios { get; set; }

    public virtual DbSet<Personalizacione> Personalizaciones { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=viajes;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("clientes_pkey");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Correo, "clientes_correo_key").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .HasColumnName("correo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<EvaluacionesProveedore>(entity =>
        {
            entity.HasKey(e => e.EvaluacionId).HasName("evaluaciones_proveedores_pkey");

            entity.ToTable("evaluaciones_proveedores");

            entity.Property(e => e.EvaluacionId).HasColumnName("evaluacion_id");
            entity.Property(e => e.Comentario).HasColumnName("comentario");
            entity.Property(e => e.FechaEvaluacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_evaluacion");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Puntuacion).HasColumnName("puntuacion");
            entity.Property(e => e.ReservaId).HasColumnName("reserva_id");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.EvaluacionesProveedores)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_evaluacion_proveedor");

            entity.HasOne(d => d.Reserva).WithMany(p => p.EvaluacionesProveedores)
                .HasForeignKey(d => d.ReservaId)
                .HasConstraintName("fk_evaluacion_reserva");
        });

        modelBuilder.Entity<Itinerario>(entity =>
        {
            entity.HasKey(e => e.ItinerarioId).HasName("itinerarios_pkey");

            entity.ToTable("itinerarios");

            entity.Property(e => e.ItinerarioId).HasColumnName("itinerario_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Dia).HasColumnName("dia");
            entity.Property(e => e.PaqueteId).HasColumnName("paquete_id");

            entity.HasOne(d => d.Paquete).WithMany(p => p.Itinerarios)
                .HasForeignKey(d => d.PaqueteId)
                .HasConstraintName("fk_itinerario_paquete");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("pagos_pkey");

            entity.ToTable("pagos");

            entity.Property(e => e.PagoId).HasColumnName("pago_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasDefaultValueSql("'PENDIENTE'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Monto)
                .HasPrecision(10, 2)
                .HasColumnName("monto");
            entity.Property(e => e.ReservaId).HasColumnName("reserva_id");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ReservaId)
                .HasConstraintName("fk_pago_reserva");
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.PaqueteId).HasName("paquetes_pkey");

            entity.ToTable("paquetes");

            entity.Property(e => e.PaqueteId).HasColumnName("paquete_id");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Destino)
                .HasMaxLength(150)
                .HasColumnName("destino");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
        });

        modelBuilder.Entity<PaqueteServicio>(entity =>
        {
            entity.HasKey(e => new { e.PaqueteId, e.ServicioId }).HasName("paquete_servicios_pkey");

            entity.ToTable("paquete_servicios");

            entity.Property(e => e.PaqueteId).HasColumnName("paquete_id");
            entity.Property(e => e.ServicioId).HasColumnName("servicio_id");
            entity.Property(e => e.Cantidad)
                .HasDefaultValue(1)
                .HasColumnName("cantidad");

            entity.HasOne(d => d.Paquete).WithMany(p => p.PaqueteServicios)
                .HasForeignKey(d => d.PaqueteId)
                .HasConstraintName("fk_ps_paquete");

            entity.HasOne(d => d.Servicio).WithMany(p => p.PaqueteServicios)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ps_servicio");
        });

        modelBuilder.Entity<Personalizacione>(entity =>
        {
            entity.HasKey(e => e.PersonalizacionId).HasName("personalizaciones_pkey");

            entity.ToTable("personalizaciones");

            entity.Property(e => e.PersonalizacionId).HasColumnName("personalizacion_id");
            entity.Property(e => e.Detalle).HasColumnName("detalle");
            entity.Property(e => e.Preferencia)
                .HasMaxLength(150)
                .HasColumnName("preferencia");
            entity.Property(e => e.ReservaId).HasColumnName("reserva_id");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Personalizaciones)
                .HasForeignKey(d => d.ReservaId)
                .HasConstraintName("fk_personalizacion_reserva");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("proveedores_pkey");

            entity.ToTable("proveedores");

            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Calificacion)
                .HasPrecision(3, 2)
                .HasDefaultValue(0m)
                .HasColumnName("calificacion");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .HasColumnName("correo");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("reservas_pkey");

            entity.ToTable("reservas");

            entity.Property(e => e.ReservaId).HasColumnName("reserva_id");
            entity.Property(e => e.CantidadPersonas).HasColumnName("cantidad_personas");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasDefaultValueSql("'PENDIENTE'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_reserva");
            entity.Property(e => e.PaqueteId).HasColumnName("paquete_id");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserva_cliente");

            entity.HasOne(d => d.Paquete).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.PaqueteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserva_paquete");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.ServicioId).HasName("servicios_pkey");

            entity.ToTable("servicios");

            entity.Property(e => e.ServicioId).HasColumnName("servicio_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasDefaultValue(0m)
                .HasColumnName("precio");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("fk_servicio_proveedor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
