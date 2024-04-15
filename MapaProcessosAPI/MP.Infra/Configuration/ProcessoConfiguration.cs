using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.Domain.Entities;

namespace MP.Infra.Configuration
{
    public class ProcessoConfiguration : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.ProcessoPai)
                .WithMany(p => p.SubsProcessosNavigation)
                .HasForeignKey(p => p.IdProcessoPai)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
