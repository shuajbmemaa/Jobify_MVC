using JobApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobApp.Areas.Identity.Data;

public class JobAppContext : IdentityDbContext<JobAppUser>
{
    public JobAppContext(DbContextOptions<JobAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<JobAppUser>
{
	public void Configure(EntityTypeBuilder<JobAppUser> builder)
	{
		builder.Property(x => x.FirstName).HasMaxLength(100);
		builder.Property(x => x.LastName).HasMaxLength(100);
	}
}