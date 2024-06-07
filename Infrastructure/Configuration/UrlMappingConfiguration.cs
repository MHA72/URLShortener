using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class UrlMappingConfiguration : IEntityTypeConfiguration<UrlMapping>
{
    public void Configure(EntityTypeBuilder<UrlMapping> builder)
    {
        builder.HasKey(mapping => mapping.Id);
        builder.HasQueryFilter(mapping => mapping.IsDeleted);
    }
}