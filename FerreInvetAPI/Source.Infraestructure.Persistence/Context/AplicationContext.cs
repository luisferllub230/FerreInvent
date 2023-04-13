using Microsoft.EntityFrameworkCore;
using Source.Core.Domain.Common;
using Source.Core.Domain.Entities;

namespace Source.Infraestructure.Persistence.Context
{
    public class AplicationContext : DbContext
    {

        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Categories> categories { get; set; }
        public DbSet<Sales> sales { get; set; }
        public DbSet<Inventory> inventories { get; set; }
        public DbSet<Custumers> custumers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) 
        {

            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>()) 
            {
                switch (entry.State) 
                {
                    case EntityState.Added:
                        entry.Entity.createBy = "deafaultUser";
                        entry.Entity.created = DateTime.Now;
                        entry.Entity.lastModifiedBy = "deafaultUser";
                        entry.Entity.lastMoified = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.lastModifiedBy = "deafaultUser";
                        entry.Entity.lastMoified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {

            #region "fluent api name table"
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Categories>().ToTable("Categories");
            builder.Entity<Sales>().ToTable("Sales");
            builder.Entity<Inventory>().ToTable("Inventory");
            builder.Entity<Custumers>().ToTable("Custumers");
            #endregion

            #region "fluent api keys"
            builder.Entity<User>().HasKey(user => user.id);
            builder.Entity<Categories>().HasKey(category => category.id);
            builder.Entity<Sales>().HasKey(sales => sales.id);
            builder.Entity<Inventory>().HasKey(inventory => inventory.id);
            builder.Entity<Custumers>().HasKey(custumer => custumer.id);
            #endregion

            #region "fluent api relations ship"
            builder.Entity<Categories>()
                .HasMany(categories => categories.inventories)
                .WithOne(inventory => inventory.categories)
                .HasForeignKey(inventory => inventory.categoryID);

            builder.Entity<Custumers>()
                .HasMany(custumer => custumer.sales)
                .WithOne(sales => sales.custumer)
                .HasForeignKey(sales => sales.custumerID);
            #endregion

            #region "fluent api configarations properties"

            #region User
            builder.Entity<User>()
                .Property(user => user.name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<User>()
                .Property(user => user.userNickname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<User>()
                .Property(user => user.userEmail)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<User>()
                .Property(user => user.userPassword)
                .HasMaxLength(500)
                .IsRequired();

            builder.Entity<User>()
                .Property(user => user.position)
                .HasMaxLength(50)
                .IsRequired();
            #endregion

            #region Categories
            builder.Entity<Categories>()
                .Property(category => category.categoryName)
                .HasMaxLength(50)
                .IsRequired();
            #endregion

            #region Sales
            builder.Entity<Sales>()
                .Property(sales => sales.dateSales)
                .IsRequired();

            builder.Entity<Sales>()
                .Property(sales => sales.quantity)
                .IsRequired();

            builder.Entity<Sales>()
                .Property(sales => sales.totalCosto)
                .IsRequired();
            #endregion

            #region Inventory
            builder.Entity<Inventory>()
                .Property(inve => inve.inventoryName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Inventory>()
                .Property(inve => inve.bran)
                .HasMaxLength(50);

            builder.Entity<Inventory>()
                .Property(inve => inve.quantity)
                .IsRequired();

            builder.Entity<Inventory>()
                .Property(inve => inve.price)
                .IsRequired();

            builder.Entity<Inventory>()
                .Property(inve => inve.discount)
                .IsRequired();
            #endregion

            #region Custumer
            builder.Entity<Custumers>()
                .Property(custumer => custumer.custumerName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Custumers>()
                .Property(custumer => custumer.custumerAddress)
                .HasMaxLength(150)
                .IsRequired();

            builder.Entity<Custumers>()
                .Property(custumer => custumer.custumerEmail)
                .HasMaxLength(100)
                .IsRequired();
            #endregion

            #endregion

        }
    }
}
