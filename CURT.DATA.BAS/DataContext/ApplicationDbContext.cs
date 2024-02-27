using Microsoft.EntityFrameworkCore;
using CURT.DATA.BAS.Models;

namespace CURT.DATA.BAS.DataContext;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext( DbContextOptions<ApplicationDbContext>options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

public DbSet<CURT.DATA.BAS.Models.Teacher> Teacher { get; set; } = default!;

}
