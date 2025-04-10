using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.TiendaOnline.Infraestructure.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ColorModel> Colors { get; set; }
        public DbSet<SizeModel> Sizes { get; set; }
        public DbSet<ProductColorModel> ProductColors { get; set; }
        public DbSet<ProductSizeModel> ProductSizes { get; set; }
        public DbSet<UserModel> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductModel>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
        }
    }
}
