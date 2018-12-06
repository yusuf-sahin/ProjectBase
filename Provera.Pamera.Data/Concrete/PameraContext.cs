using Microsoft.EntityFrameworkCore;
using Provera.Pamera.Model.Abstract;
using Provera.Pamera.Model.Concrete;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Provera.Pamera.Data.Concrete
{
    public class PameraContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseNpgsql(@"Server=localhost;Database=Pamera_DB;Username=provera;Password=Provera@2016");
            optionsBuilder.UseNpgsql(@"Server=localhost;Database=DBPamera;Username=postgres;Password=Provera@2016");
        }
        public DbSet<Product> Products { get; set; }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.UtcNow;
                    var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.ModifiedAt = now;
                            trackable.ModifiedBy = user;
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = now;
                            trackable.CreatedBy = user;
                            trackable.ModifiedAt = now;
                            trackable.ModifiedBy = user;
                            break;
                    }
                }
            }
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted))
            {
                if (entry.Entity is ISoftDeletable)
                {
                    entry.Property(_isDeletedProperty).CurrentValue = true;
                    entry.State = EntityState.Modified;
                }
            }
        }

        private string GetCurrentUser()
        {
            return "UserName"; // TODO implement your own logic

            // If you are using ASP.NET Core, you should look at this answer on StackOverflow
            // https://stackoverflow.com/a/48554738/2996339
        }
        private const string _isDeletedProperty = "IsDeleted";
        private static readonly MethodInfo _propertyMethod = typeof(EF).GetMethod(nameof(EF.Property), BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(bool));

        private static LambdaExpression GetIsDeletedRestriction(Type type)
        {
            var parm = Expression.Parameter(type, "it");
            var prop = Expression.Call(_propertyMethod, parm, Expression.Constant(_isDeletedProperty));
            var condition = Expression.MakeBinary(ExpressionType.Equal, prop, Expression.Constant(false));
            var lambda = Expression.Lambda(condition, parm);
            return lambda;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entity.ClrType) == true)
                {
                    entity.AddProperty(_isDeletedProperty, typeof(bool));

                    modelBuilder
                        .Entity(entity.ClrType)
                        .HasQueryFilter(GetIsDeletedRestriction(entity.ClrType));
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}