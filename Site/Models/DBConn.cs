using Site.FluentApi;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Site.Models
{
    public class DBConn : DbContext
    {
        public DBConn(): base("DBContexto")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DBConn>());
        }

    public DbSet<FotoImagem> Imagens { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FotoImagemFluentApi());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }

}