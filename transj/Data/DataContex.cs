using Microsoft.EntityFrameworkCore;


namespace transj.Data
{
    public class DataContex :DbContext
    {
       public DbSet<cliente> clientes { get; set; }

       public DbSet<cuenta> cuentas { get; set; }

        public DbSet<banco> bancoes { get; set; }

        public DbSet<transferencia> transferencias { get; set; }



        public DataContex(DbContextOptions<DataContex> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cliente>(cliente =>
            {

                cliente.ToTable("Cliente");


                cliente.HasKey(p => p.cedula_cliente);

                cliente.Property(p => p.tipo_doc).IsRequired().HasMaxLength(3);

                cliente.Property(P => P.nombre_apellido).IsRequired().HasMaxLength(30);

               
            });

            modelBuilder.Entity<cuenta>(cuenta =>
            {

                cuenta.ToTable("Cuenta");

                cuenta.Property(p => p.id_cta).IsRequired();

                cuenta.HasKey(p => p.num_cta);


                cuenta.Property(P => P.moneda).IsRequired().HasMaxLength(3);

                cuenta.HasOne(P => P.Cliente).WithMany(p => p.Cuentas).HasForeignKey(p => p.cedula_cliente);

                cuenta.Property(P => P.saldo).IsRequired();

                cuenta.HasOne(P => P.Banco).WithMany(p => p.Cuentas).HasForeignKey(p => p.cod_banco);

            


            });





            modelBuilder.Entity<banco>(banco =>
            {
                banco.ToTable("Banco");

                banco.HasKey(P => P.cod_banco);

                banco.Property(p => p.nombre_banco).IsRequired().HasMaxLength(100);

                banco.Property(P => P.direccion).IsRequired().HasMaxLength(100);



            });


            modelBuilder.Entity<transferencia>(tranferencia =>
            {
                tranferencia.ToTable("transferencia");

                tranferencia.HasKey(p => p.id_transaccion);

                tranferencia.Property(p => p.num_cta).IsRequired().HasMaxLength(100);

                tranferencia.HasOne(P => P.Cuenta).WithMany(p => p.Transferencias).HasForeignKey(p => p.num_cta);

                tranferencia.HasOne(P => P.Cliente).WithMany(p => p.Transferencias).HasForeignKey(p => p.cedula_cliente);

                tranferencia.Property(P => P.fecha).IsRequired().HasMaxLength(100);

                tranferencia.Property(P => P.monto).IsRequired();

                tranferencia.Property(P => P.estado).IsRequired().HasMaxLength(15);





            });
        }
    }
}
