using FutureClient.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FutureClient.Infrastructure.Configurations;

public class FutureQuarterDifferencesConfiguration : IEntityTypeConfiguration<FutureDifference>
{
    public void Configure(EntityTypeBuilder<FutureDifference> builder)
    {
        builder.HasKey(x => x.Id);
    }
}