using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Eticaret2022.DataEntities.DataModels
{
    public partial class Eticaret2022Context : DbContext
    {
        public Eticaret2022Context()
            : base("name=Eticaret2022Context")
        {
        }

        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<AltKategori> AltKategori { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BankaBilgi> BankaBilgi { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Fatura> Fatura { get; set; }
        public virtual DbSet<Iletisim> Iletisim { get; set; }
        public virtual DbSet<OdemeTip> OdemeTip { get; set; }
        public virtual DbSet<SatilanUrun> SatilanUrun { get; set; }
        public virtual DbSet<SatisDetay> SatisDetay { get; set; }
        public virtual DbSet<SistemHata> SistemHata { get; set; }
        public virtual DbSet<SiteHakkinda> SiteHakkinda { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<UrunYorum> UrunYorum { get; set; }
        public virtual DbSet<UstKategori> UstKategori { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adres>()
                .HasMany(e => e.SatisDetay)
                .WithRequired(e => e.Adres)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AltKategori>()
                .HasMany(e => e.Urun)
                .WithRequired(e => e.AltKategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Adres)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.MusteriId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.SatisDetay)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.MusteriId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.UrunYorum)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OdemeTip>()
                .HasMany(e => e.SatisDetay)
                .WithRequired(e => e.OdemeTip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SatisDetay>()
                .HasOptional(e => e.Fatura)
                .WithRequired(e => e.SatisDetay);

            modelBuilder.Entity<SatisDetay>()
                .HasMany(e => e.SatilanUrun)
                .WithRequired(e => e.SatisDetay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.SatilanUrun)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.UrunYorum)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UstKategori>()
                .HasMany(e => e.AltKategori)
                .WithRequired(e => e.UstKategori)
                .WillCascadeOnDelete(false);
        }
    }
}
