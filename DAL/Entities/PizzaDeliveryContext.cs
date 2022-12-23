using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class PizzaDeliveryContext : DbContext
    {
        public PizzaDeliveryContext()
            : base("name=PizzaDeliveryContext")
        {
        }

        public virtual DbSet<Courier> Courier { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaType> PizzaType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Line_of_order> Line_of_order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courier>()
                .Property(e => e.Courier_name)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.Courier_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.Order_code)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Courier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Employee_login)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Employee_password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Employee_name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.Employee_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Ingredient_name)
                .IsUnicode(false);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.Ingredients)
                .WithRequired(e => e.Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Order_adress)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Line_of_order)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.Order_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.Pizza_type)
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.Pizza_name)
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.Ingredients)
                .WithRequired(e => e.Pizza)
                .HasForeignKey(e => e.Pizza_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.Line_of_order)
                .WithRequired(e => e.Pizza)
                .HasForeignKey(e => e.Pizza_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PizzaType>()
                .Property(e => e.Pizza_type)
                .IsUnicode(false);

            modelBuilder.Entity<PizzaType>()
                .HasMany(e => e.Pizza)
                .WithRequired(e => e.PizzaType)
                .WillCascadeOnDelete(false);
        }
    }
}
