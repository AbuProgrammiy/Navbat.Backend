using Microsoft.EntityFrameworkCore;
using Navbat.Application.Abstractions;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<ServiceCategoryModel> ServiceCategories { get; set; }
        public DbSet<QueueModel> Queues { get; set; }
        public DbSet<TemporaryCodeModel> TemporaryCodes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.Migrate();
        }
    }

}
