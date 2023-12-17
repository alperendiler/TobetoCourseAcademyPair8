using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("CourseId").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.Price).HasColumnName("Price").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Courses_CourseName").IsUnique();
            builder.HasOne(c => c.Category).WithMany(i => i.Course).HasForeignKey(c => c.CategoryId);
            builder.HasOne(b => b.Instructor).WithMany(i => i.Course).HasForeignKey(c => c.InstructorId);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}