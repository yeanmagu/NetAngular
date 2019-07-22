using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetPrueba.Model
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AutoresLibros> AutoresLibros { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Valoracion> Valoracion { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=PRUEBA_YEINERMARTINEZ;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AutoresLibros>(entity =>
            {
                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.AutoresLibros)
                    .HasForeignKey(d => d.AutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AutoresLi__Autor__44FF419A");

                entity.HasOne(d => d.Libro)
                    .WithMany(p => p.AutoresLibros)
                    .HasForeignKey(d => d.LibroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AutoresLi__Libro__440B1D61");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.Property(e => e.Precio).HasColumnType("money");

                entity.HasOne(d => d.Libro)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.LibroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleVe__Libro__4CA06362");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleVe__Venta__4BAC3F29");
            });

            modelBuilder.Entity<Libros>(entity =>
            {
                entity.Property(e => e.Costo).HasColumnType("money");

                entity.Property(e => e.DescripcionValoracion).HasMaxLength(100);

                entity.Property(e => e.Edicion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");

                entity.Property(e => e.PrecioMinorista).HasColumnType("money");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Valoracion)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.ValoracionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Libros__Valoraci__3B75D760");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.Property(e => e.AnioMuerte).HasMaxLength(5);

                entity.Property(e => e.AnioNacimiento).HasMaxLength(5);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(20);

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Personas__TipoId__412EB0B6");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__Tipo__75E3EFCFC4A527DE")
                    .IsUnique();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Valoracion>(entity =>
            {
                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__Valoraci__75E3EFCF41C1607E")
                    .IsUnique();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.VentasCliente)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__ClienteI__47DBAE45");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.VentasEmpleado)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__Empleado__48CFD27E");
            });
        }
    }
}
