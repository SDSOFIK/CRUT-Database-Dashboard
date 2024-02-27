using CURT.DATA.BAS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CURT.DATA.BAS.Configuration
{
    public class TecaherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(nameof(Teacher));
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Subject).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Department).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Email).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Phone).HasMaxLength(100).IsRequired();
        }
    }
}
