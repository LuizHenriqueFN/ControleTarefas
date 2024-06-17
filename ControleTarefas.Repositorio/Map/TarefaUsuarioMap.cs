using ControleTarefas.Entidade.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleTarefas.Repositorio.Map
{
    public class TarefaUsuarioMap : IEntityTypeConfiguration<TarefaUsuario>
    {
        public void Configure(EntityTypeBuilder<TarefaUsuario> builder)
        {
            builder.ToTable("tb_tarefausuario");

            builder.HasKey(e => new { e.IdTarefa, e.IdUsuario });

            builder.Property(e => e.IdTarefa)
                   .HasColumnName("id_tarefa")
                   .IsRequired();

            builder.Property(e => e.IdUsuario)
                   .HasColumnName("id_usuario")
                   .IsRequired();

            builder.Property(e => e.Concluida)
                   .HasColumnName("flg_concluida")
                   .IsRequired();

            builder.HasOne(e => e.Usuario)
                   .WithMany(e => e.TarefasUsuario)
                   .HasForeignKey(e => e.IdUsuario);

            builder.HasOne(e => e.Tarefa)
                   .WithMany(e => e.UsuarioTarefa)
                   .HasForeignKey(e => e.IdTarefa);
        }
    }
}
