using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infraestructure.persistence.Context
{
    public class AplicationsContext : DbContext
    {

        public AplicationsContext(DbContextOptions<AplicationsContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Categories> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //fluent api -- nombre de la app
            //Modifica el nombre de las tablas
            #region table
            builder.Entity<Product>()
                .ToTable("product");

            builder.Entity<Categories>()
                .ToTable("category");
            #endregion

            //modifica los primary key
            #region primaryKey
            builder.Entity<Product>()
                .HasKey(product => product.id);

            builder.Entity<Product>()
                .HasKey(category => category.id);
            #endregion

            //establece las relaciones
            //many to one
            #region relationship
            builder.Entity<Categories>()
                .HasMany<Product>(categories => categories.products)
                .WithOne(product => product.categories)
                .HasForeignKey(product => product.categoryId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            //configuracion de las property
            #region "property configuration"

            #region product
            builder.Entity<Product>()
                .Property(product => product.id)
                .IsRequired();

            builder.Entity<Product>()
                .Property(product => product.productName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<Product>()
                .Property(product => product.productPrice)
                .IsRequired();
            #endregion

            #region category
            builder.Entity<Categories>()
                .Property(categories => categories.id)
                .IsRequired();

            builder.Entity<Categories>()
                .Property(categories => categories.categoryName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<Categories>()
                .Property(categories => categories.categoryDescription)
                .HasMaxLength(500)
                .IsRequired();
            #endregion

            #endregion
        }
    }
}
