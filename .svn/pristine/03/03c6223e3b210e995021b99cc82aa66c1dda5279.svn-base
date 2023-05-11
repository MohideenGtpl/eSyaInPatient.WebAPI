using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eSyaInPatient.DL.Entities
{
    public partial class eSyaEnterprise : DbContext
    {
        public static string _connString = "";
        public eSyaEnterprise()
        {
        }

        public eSyaEnterprise(DbContextOptions<eSyaEnterprise> options)
            : base(options)
        {
        }

        public virtual DbSet<GtEastbl> GtEastbl { get; set; }
        public virtual DbSet<GtEcapcd> GtEcapcd { get; set; }
        public virtual DbSet<GtEcbsln> GtEcbsln { get; set; }
        public virtual DbSet<GtEcbssg> GtEcbssg { get; set; }
        public virtual DbSet<GtEcstrm> GtEcstrm { get; set; }
        public virtual DbSet<GtEswrbl> GtEswrbl { get; set; }
        public virtual DbSet<GtEswrbm> GtEswrbm { get; set; }
        public virtual DbSet<GtEswrms> GtEswrms { get; set; }
        public virtual DbSet<GtEswrrl> GtEswrrl { get; set; }
        public virtual DbSet<GtEswrrm> GtEswrrm { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<GtEastbl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.StoreCode });

                entity.ToTable("GT_EASTBL");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.BusinessKeyNavigation)
                    .WithMany(p => p.GtEastbl)
                    .HasPrincipalKey(p => p.BusinessKey)
                    .HasForeignKey(d => d.BusinessKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EASTBL_GT_ECBSLN");
            });

            modelBuilder.Entity<GtEcapcd>(entity =>
            {
                entity.HasKey(e => e.ApplicationCode)
                    .HasName("PK_GT_ECAPCD_1");

                entity.ToTable("GT_ECAPCD");

                entity.Property(e => e.ApplicationCode).ValueGeneratedNever();

                entity.Property(e => e.CodeDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcbsln>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.SegmentId, e.LocationId });

                entity.ToTable("GT_ECBSLN");

                entity.HasIndex(e => e.BusinessKey)
                    .HasName("IX_GT_ECBSLN")
                    .IsUnique();

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EActiveUsers)
                    .IsRequired()
                    .HasColumnName("eActiveUsers");

                entity.Property(e => e.EBusinessKey)
                    .IsRequired()
                    .HasColumnName("eBusinessKey");

                entity.Property(e => e.ESyaLicenseType)
                    .IsRequired()
                    .HasColumnName("eSyaLicenseType")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EUserLicenses)
                    .IsRequired()
                    .HasColumnName("eUserLicenses");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LocationDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TocurrConversion).HasColumnName("TOCurrConversion");

                entity.Property(e => e.TolocalCurrency)
                    .IsRequired()
                    .HasColumnName("TOLocalCurrency")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TorealCurrency).HasColumnName("TORealCurrency");

                entity.HasOne(d => d.GtEcbssg)
                    .WithMany(p => p.GtEcbsln)
                    .HasForeignKey(d => new { d.BusinessId, d.SegmentId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECBSLN_GT_ECBSSG");
            });

            modelBuilder.Entity<GtEcbssg>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.SegmentId });

                entity.ToTable("GT_ECBSSG");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OrgnDateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SegmentDesc)
                    .IsRequired()
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<GtEcstrm>(entity =>
            {
                entity.HasKey(e => e.StoreCode)
                    .HasName("PK_GT_ECSTRM_1");

                entity.ToTable("GT_ECSTRM");

                entity.Property(e => e.StoreCode).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.StoreDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StoreType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEswrbl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.WardId, e.RoomId });

                entity.ToTable("GT_ESWRBL");

                entity.Property(e => e.WardId).HasColumnName("WardID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.ConsignmentMarkupPerc).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEswrbm>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RoomId, e.BedNumber });

                entity.ToTable("GT_ESWRBM");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.BedNumber).HasMaxLength(10);

                entity.Property(e => e.BedStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.HospitalNumber).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.RoomNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<GtEswrms>(entity =>
            {
                entity.HasKey(e => e.WardId);

                entity.ToTable("GT_ESWRMS");

                entity.Property(e => e.WardId)
                    .HasColumnName("WardID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.WardDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WardShortDesc)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<GtEswrrl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.WardId, e.RoomId, e.RateType, e.EffectiveFrom });

                entity.ToTable("GT_ESWRRL");

                entity.Property(e => e.WardId).HasColumnName("WardID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DayCareTariff).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ServiceChargePerc).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Tariff).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEswrrm>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.ToTable("GT_ESWRRM");

                entity.Property(e => e.RoomId)
                    .HasColumnName("RoomID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.RoomDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoomShortDesc)
                    .IsRequired()
                    .HasMaxLength(10);
            });
        }
    }
}
