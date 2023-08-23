using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Repository.EfCore.MappingConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x => x.Surname)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x => x.CreatedDate)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.BirthDate)
                   .IsRequired()
                   .HasColumnType("DATE");

            builder.HasOne(x => x.Department)
                   .WithMany(x => x.Employees)
                   .HasForeignKey(x => x.DepartmentId);


            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasData(GetSeedData());
        }

        private List<Employee> GetSeedData()
        {
            return new()
            {
                new()
                {
                    Id=1,
                    DepartmentId=1,
                    Name="Ramil",
                    Surname="Aliyev",
                    BirthDate=new DateTime(1996,3,24),
                },
                new()
                {
                    Id=2,
                    DepartmentId=1,
                    Name="Kanan",
                    Surname="Mammadov",
                    BirthDate=new DateTime(1995,4,2),
                },
                new()
                {
                    Id=3,
                    DepartmentId=2,
                    Name="Yusif",
                    Surname="Karimli",
                    BirthDate=new DateTime(1993,1,26),
                },
            };
        }
    }
}
