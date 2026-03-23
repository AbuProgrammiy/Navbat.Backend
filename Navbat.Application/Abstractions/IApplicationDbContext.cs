using Microsoft.EntityFrameworkCore;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<UserModel> Users { get; set; }
        DbSet<ServiceModel> Services { get; set; }
        DbSet<ServiceCategoryModel> ServiceCategories { get; set; }
        DbSet<QueueModel> Queues { get; set; }
        DbSet<TemporaryCodeModel> TemporaryCodes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);//CancellationToken cancellationToken = default); 
    }
}
