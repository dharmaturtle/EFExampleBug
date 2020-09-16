using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace XUnitTestProject1
{
    public partial class EFExampleBugDb : DbContext
    {
        public EFExampleBugDb()
        {
        }

        public EFExampleBugDb(DbContextOptions<EFExampleBugDb> options)
            : base(options)
        {
        }

        public virtual DbSet<Alpha_Beta_Key> alpha_beta_key { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=EFExampleBug;Username=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
