using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStoreApp.API.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;

        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Suppresses the strict non-deterministic model check warning
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA158F90D7").IsUnique();

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author).WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "1d9d71ed-e29a-40c1-82ff-d6c8440daa26"
                },
                new IdentityRole
                {
                Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "9fc78a51-c80e-43ad-b26e-c7bb709f14e8"
                }
            );

            var hasher = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id = "a8d47df2-90dc-4df0-af1e-2b9cf2189c6c",
                    Email = "admin@bookstor.com",
                    NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                    UserName = "admin@bookstor.com",
                    NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = "AQAAAAIAAYagAAAAEJa0exZEOzCjw2IcipBDYiG7NNvBmFJFy91bDMo9Y+u7Vjhu9uSVnr+JkdLZnD5NtQ=="
                },
                new ApiUser
                {
                    Id = "5f1136f4-93a8-4bbf-9018-b70a90486d5a",
                    Email = "user@bookstor.com",
                    NormalizedEmail = "USER@BOOKSTORE.COM",
                    UserName = "user@bookstor.com",
                    NormalizedUserName = "USER@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = "AQAAAAIAAYagAAAAEPTh/tw0XmfRJNR5hhOQLp1gvfyAPt9Ert3J8G9iRrk9LVxqVYDXtTmP24AN0pmkhg=="
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1d9d71ed-e29a-40c1-82ff-d6c8440daa26",
                    UserId = "5f1136f4-93a8-4bbf-9018-b70a90486d5a"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "9fc78a51-c80e-43ad-b26e-c7bb709f14e8",
                    UserId = "a8d47df2-90dc-4df0-af1e-2b9cf2189c6c"
                }

            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}