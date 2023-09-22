using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChimalliStore.Api.Context;

public partial class ChimallidbContext : DbContext
{
    public ChimallidbContext(DbContextOptions<ChimallidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentsCarrier> PaymentsCarriers { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsCategory> ProductsCategories { get; set; }

    public virtual DbSet<ProductsXuser> ProductsXusers { get; set; }

    public virtual DbSet<ProductsXusersXshoppingCart> ProductsXusersXshoppingCarts { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<ShoppingCartsXuser> ShoppingCartsXusers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Cp)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("CP");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.ObjectStatusId).HasColumnName("objectStatusId");
            entity.Property(e => e.State)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.Suburb)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("suburb");
            entity.Property(e => e.UserId).HasColumnName("userId");

            //entity.HasOne(d => d.User).WithMany(p => p.Addresses)
            //    .HasForeignKey(d => d.UserId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Addresses_Users");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DatetimePayment)
                .HasColumnType("datetime")
                .HasColumnName("datetimePayment");
            entity.Property(e => e.ObjectStatusId).HasColumnName("objectStatusId");
            entity.Property(e => e.PaymentCarrierGuid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("paymentCarrierGUID");
            entity.Property(e => e.PaymentCarrierId).HasColumnName("paymentCarrierId");
            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.ShoppingCartId).HasColumnName("shoppingCartId");
            entity.Property(e => e.TotalShoppingCart)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalShoppingCart");

            entity.HasOne(d => d.PaymentCarrier).WithMany()
                .HasForeignKey(d => d.PaymentCarrierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_PaymentsCarriers");

            entity.HasOne(d => d.ShoppingCart).WithMany()
                .HasForeignKey(d => d.ShoppingCartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_ShoppingCarts");
        });

        modelBuilder.Entity<PaymentsCarrier>(entity =>
        {
            entity.HasKey(e => e.PaymentCarrierId);

            entity.Property(e => e.PaymentCarrierId).HasColumnName("paymentCarrierId");
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.DescriptionPaymentCarrier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descriptionPaymentCarrier");
            entity.Property(e => e.NamePaymentCarrier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("namePaymentCarrier");
            entity.Property(e => e.ObjectStatusId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("objectStatusId");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Genre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("genre");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.MaternalLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("maternalLastName");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ObjectStatusId).HasColumnName("objectStatusId");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProducCategoryId).HasColumnName("producCategoryId");
            entity.Property(e => e.ProducUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("producUrl");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.ProducCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProducCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductsCategories");
        });

        modelBuilder.Entity<ProductsCategory>(entity =>
        {
            entity.HasKey(e => e.ProducCategoryId);

            entity.Property(e => e.ProducCategoryId).HasColumnName("producCategoryId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ObjectStatusId).HasColumnName("objectStatusId");
        });

        modelBuilder.Entity<ProductsXuser>(entity =>
        {
            entity.HasKey(e => e.ProductXuserId);

            entity.Property(e => e.ProductXuserId).HasColumnName("productXuserId");
            entity.Property(e => e.ObjectStatusId).HasColumnName("objectStatusId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsXusers)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsXusers_Products");

            entity.HasOne(d => d.User).WithMany(p => p.ProductsXusers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsXusers_Users");
        });

        modelBuilder.Entity<ProductsXusersXshoppingCart>(entity =>
        {
            entity.HasKey(e => e.ProductXuserXshoppingCartId);

            entity.Property(e => e.ProductXuserXshoppingCartId).HasColumnName("productXuserXshoppingCartId");
            entity.Property(e => e.ObjectStatus).HasColumnName("objectStatus");
            entity.Property(e => e.ProductXuserId).HasColumnName("productXuserId");
            entity.Property(e => e.ShoppingCartId).HasColumnName("shoppingCartId");

            entity.HasOne(d => d.ProductXuser).WithMany(p => p.ProductsXusersXshoppingCarts)
                .HasForeignKey(d => d.ProductXuserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsXusersXshoppingCarts_ProductsXusers");

            entity.HasOne(d => d.ShoppingCart).WithMany(p => p.ProductsXusersXshoppingCarts)
                .HasForeignKey(d => d.ShoppingCartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsXusersXshoppingCarts_ShoppingCarts");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.Property(e => e.ShoppingCartId).HasColumnName("shoppingCartId");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.ObjectStatusId).HasColumnName("objectStatusId");
            entity.Property(e => e.ShoppingCartGuid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("shoppingCart_GUID");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
        });

        modelBuilder.Entity<ShoppingCartsXuser>(entity =>
        {
            entity.HasKey(e => e.ShoppingCartXuserId);

            entity.ToTable("shoppingCartsXusers");

            entity.Property(e => e.ShoppingCartXuserId).HasColumnName("shoppingCartXuserId");
            entity.Property(e => e.ObjectStatusId).HasColumnName("objectStatusId");
            entity.Property(e => e.ShoppingCartId).HasColumnName("shoppingCartId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.ShoppingCart).WithMany(p => p.ShoppingCartsXusers)
                .HasForeignKey(d => d.ShoppingCartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_shoppingCartsXusers_ShoppingCarts");

            entity.HasOne(d => d.User).WithMany(p => p.ShoppingCartsXusers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_shoppingCartsXusers_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "UN_Users").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Alias)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("alias");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ObjectStatusId).HasColumnName("objectStatusId");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_People");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
