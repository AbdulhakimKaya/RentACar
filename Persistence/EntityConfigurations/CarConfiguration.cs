using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(c => c.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(c => c.CarState).HasColumnName("State").IsRequired();
        builder.Property(c => c.ModelYear).HasColumnName("ModelYear").IsRequired();
        builder.Property(c => c.Plate).HasColumnName("Plate").IsRequired();
        builder.Property(c => c.MinFIndexScore).HasColumnName("MinFIndexScore").IsRequired();
        builder.Property(c => c.DailyPrice).HasColumnName("DailyPrice").IsRequired();
        
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        builder.HasOne(c => c.Model).WithMany(m => m.Cars); 
        builder.HasMany(x => x.Images).WithOne(i => i.Car).HasForeignKey(i => i.CarId);

        builder.HasOne(c => c.Color);
        
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}