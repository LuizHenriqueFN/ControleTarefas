using ControleTarefas.Entidade.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleTarefas.Repositorio.Map
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("tb_tarefa");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id_tarefa")
                   .IsRequired();

            builder.Property(e => e.Titulo)
                   .HasColumnName("dsc_tarefa")
                   .HasMaxLength(50)
                   .IsRequired(false);
        }
    }
}
