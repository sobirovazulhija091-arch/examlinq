using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
public class ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : DbContext(options)
                    {
         public DbSet<Subscription> Subscriptions{get;set;}
         public DbSet<Plan> Plans{get;set;}
         public DbSet<Course> Courses{get;set;}
         public DbSet<User> Users{get;set;}
         public DbSet<Payment> Payments{get;set;}
         public DbSet<CourseAccess> CourseAccesses{get;set;}
            protected override void OnModelCreating(ModelBuilder model) 
             {
                    base.OnModelCreating(model);
                    model.Entity<Subscription>(builder =>
              {
                 builder.HasOne<User>()
                    .WithMany()
                   .HasForeignKey(x => x.UserId);
            
             builder.HasOne<Plan>()
                .WithMany()
               .HasForeignKey(x => x.PlanId);
      });
        model.Entity<Payment>(builder =>
        {
            builder.HasOne<User>()
                    .WithMany()
                   .HasForeignKey(x => x.UserId);
            
             builder.HasOne<Subscription>()
                .WithMany()
                .HasForeignKey(x => x.SubscriptionId);         
        });
        model.Entity<CourseAccess>(builder =>
        {
                builder.HasOne<User>()
                    .WithMany()
                   .HasForeignKey(x => x.UserId);

             builder.HasOne<Course>().WithMany()
                   .HasForeignKey(x=>x.CourseId);
                   
        });
    }
   }
public class ApplicationDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbcontext>
{
    public ApplicationDbcontext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbcontext>();
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=examlinq;Username=postgres;Password=1234"
        );
        return new ApplicationDbcontext(optionsBuilder.Options);
    }
}




