using PulseApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PulseApi.Infrastructure.Data.Configurations;
public class QuoteItemConfiguration : IEntityTypeConfiguration<QuoteItem>
{
    public void Configure(EntityTypeBuilder<QuoteItem> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(1024)
            .IsRequired();
    }
}
