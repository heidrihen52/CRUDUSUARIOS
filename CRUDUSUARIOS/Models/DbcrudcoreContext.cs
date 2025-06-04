using Microsoft.EntityFrameworkCore;

namespace CRUDUSUARIOS.Models;

public partial class DbcrudcoreContext : DbContext
{
    public DbcrudcoreContext()
    {
    }

    public DbcrudcoreContext(DbContextOptions<DbcrudcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__CARGO__6C9856253D5D0CB8");

            entity.ToTable("CARGO");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF97086E3128");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasDefaultValue(true);


            entity.HasOne(d => d.oCargo).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("FK__USUARIO__IdCargo__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
