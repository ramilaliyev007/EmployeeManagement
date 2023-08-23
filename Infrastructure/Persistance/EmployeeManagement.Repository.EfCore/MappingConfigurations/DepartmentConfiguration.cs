﻿using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.EfCore.MappingConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x => x.CreatedDate)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.HasMany(x => x.Employees)
                   .WithOne(x => x.Department)
                   .HasForeignKey(x => x.DepartmentId);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasData(GetSeedData());
        }

        private List<Department> GetSeedData()
        {
            return new List<Department>()
            {
                new()
                {
                    Id=1,
                    Name="IT"
                },
                new()
                {
                    Id=2,
                    Name="HR"
                }, new()
                {
                    Id=3,
                    Name="Audit"
                },
            };
        }
    }
}
