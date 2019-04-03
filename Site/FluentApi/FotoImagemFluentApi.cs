using Site.Models;
using System.Data.Entity.ModelConfiguration;

namespace Site.FluentApi
{
    public class FotoImagemFluentApi : EntityTypeConfiguration<FotoImagem>
    {
        public FotoImagemFluentApi()
        {
            ToTable("Imagens");

            HasKey(p => p.Id);
            Property(p => p.Id)
                    .HasColumnName("Id")
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.TipoEvento).IsRequired();
            Property(p => p.Path).IsRequired();
            Property(p => p.Descricao).HasMaxLength(100);
            Property(p => p.Ativo);
        }
    }
}