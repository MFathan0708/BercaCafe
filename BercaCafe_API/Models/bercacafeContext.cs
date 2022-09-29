using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class BercaCafeContext : DbContext
    {
        public BercaCafeContext()
        {
        }

        public BercaCafeContext(DbContextOptions<BercaCafeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddComposition> AddCompositions { get; set; }
        public virtual DbSet<Composition> Compositions { get; set; }
        public virtual DbSet<CompositionType> CompositionTypes { get; set; }
        public virtual DbSet<CupComposition> CupCompositions { get; set; }
        public virtual DbSet<Hrddirektorat> Hrddirektorats { get; set; }
        public virtual DbSet<Hrddivision> Hrddivisions { get; set; }
        public virtual DbSet<Hrdemployee1> Hrdemployee1s { get; set; }
        public virtual DbSet<Hrdemployee2> Hrdemployee2s { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialsLog> MaterialsLogs { get; set; }
        public virtual DbSet<MsEmployee> MsEmployees { get; set; }
        public virtual DbSet<MsEmployeeBackup> MsEmployeeBackups { get; set; }
        public virtual DbSet<MsMenuImageUrlNew> MsMenuImageUrlNews { get; set; }
        public virtual DbSet<MsUdc> MsUdcs { get; set; }
        public virtual DbSet<PsJob> PsJobs { get; set; }
        public virtual DbSet<ScAbsen> ScAbsens { get; set; }
        public virtual DbSet<TrAbsenHistory> TrAbsenHistories { get; set; }
        public virtual DbSet<VTest> VTests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=RDA-MADENDA;Database=BercaCafe;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AddComposition>(entity =>
            {
                entity.HasKey(e => e.AddCompId)
                    .HasName("PK__Add_Comp__69CF316D0A07DFA1");

                entity.ToTable("Add_Composition");

                entity.Property(e => e.AddCompId).HasColumnName("AddCompID");

                entity.Property(e => e.AddId).HasColumnName("AddID");

                entity.Property(e => e.CompTypeId).HasColumnName("CompTypeID");

                entity.HasOne(d => d.CompType)
                    .WithMany(p => p.AddCompositions)
                    .HasForeignKey(d => d.CompTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Add_Compo__CompT__61716316");
            });

            modelBuilder.Entity<Composition>(entity =>
            {
                entity.HasKey(e => e.CompId)
                    .HasName("PK__Composit__AD362A768E12FA86");

                entity.ToTable("Composition");

                entity.Property(e => e.CompId).HasColumnName("CompID");

                entity.Property(e => e.CompTypeId).HasColumnName("CompTypeID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.CompType)
                    .WithMany(p => p.Compositions)
                    .HasForeignKey(d => d.CompTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Compositi__CompT__644DCFC1");
            });

            modelBuilder.Entity<CompositionType>(entity =>
            {
                entity.HasKey(e => e.CompTypeId)
                    .HasName("PK__Composit__A42CAD9075A3F331");

                entity.ToTable("CompositionType");

                entity.Property(e => e.CompTypeId).HasColumnName("CompTypeID");

                entity.Property(e => e.CompUnit)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CupComposition>(entity =>
            {
                entity.HasKey(e => e.CupCompId)
                    .HasName("PK__Cup_Comp__6F91274643624000");

                entity.ToTable("Cup_Composition");

                entity.Property(e => e.CupCompId).HasColumnName("CupCompID");

                entity.Property(e => e.CompTypeId).HasColumnName("CompTypeID");

                entity.Property(e => e.CupId).HasColumnName("CupID");

                entity.HasOne(d => d.CompType)
                    .WithMany(p => p.CupCompositions)
                    .HasForeignKey(d => d.CompTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cup_Compo__CompT__5E94F66B");
            });

            modelBuilder.Entity<Hrddirektorat>(entity =>
            {
                entity.HasKey(e => e.DirektoratKey);

                entity.ToTable("HRDDirektorat");

                entity.Property(e => e.DirektoratKey)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedId).HasColumnName("CreatedID");

                entity.Property(e => e.CreatedIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DirektoratAlias)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DirektoratName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Freceive).HasColumnName("FReceive");

                entity.Property(e => e.Fsend).HasColumnName("FSend");

                entity.Property(e => e.LastModify).HasColumnType("datetime");

                entity.Property(e => e.LastModifyId).HasColumnName("LastModifyID");

                entity.Property(e => e.LastModifyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.ReceiveBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveFile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveTime).HasColumnType("datetime");

                entity.Property(e => e.SendBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SendFile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SendIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SendTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hrddivision>(entity =>
            {
                entity.HasKey(e => e.DivisionKey);

                entity.ToTable("HRDDivision");

                entity.Property(e => e.DivisionKey).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedId).HasColumnName("CreatedID");

                entity.Property(e => e.CreatedIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedName).HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DivisionAlias).HasMaxLength(255);

                entity.Property(e => e.DivisionName).HasMaxLength(255);

                entity.Property(e => e.Freceive).HasColumnName("FReceive");

                entity.Property(e => e.Fsend).HasColumnName("FSend");

                entity.Property(e => e.LastModify).HasColumnType("datetime");

                entity.Property(e => e.LastModifyId).HasColumnName("LastModifyID");

                entity.Property(e => e.LastModifyName).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.ReceiveBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveFile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveTime).HasColumnType("datetime");

                entity.Property(e => e.SendBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SendFile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SendIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SendTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hrdemployee1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HRDEmployee1");

                entity.Property(e => e.AbsenKey)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.Birthplace)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Blood)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CarAllowance)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ContractFrom).HasColumnType("datetime");

                entity.Property(e => e.ContractTo).HasColumnType("datetime");

                entity.Property(e => e.Country)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedId).HasColumnName("CreatedID");

                entity.Property(e => e.CreatedIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DateHired).HasColumnType("datetime");

                entity.Property(e => e.DateResign).HasColumnType("datetime");

                entity.Property(e => e.EmailAddr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Freceive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FReceive")
                    .IsFixedLength(true);

                entity.Property(e => e.Fsend)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FSend")
                    .IsFixedLength(true);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Itasset)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ITAsset");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifyId).HasColumnName("LastModifyID");

                entity.Property(e => e.LastModifyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatusExPettyCash)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoKtp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NoKTP");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveFile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveTime).HasColumnType("datetime");

                entity.Property(e => e.SendBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SendFile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SendIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SendTime).HasColumnType("datetime");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.TaxStatus)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hrdemployee2>(entity =>
            {
                entity.HasKey(e => e.EmployeeKey);

                entity.ToTable("HRDEmployee2");

                entity.Property(e => e.EmployeeKey).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.MaterialsId)
                    .HasName("PK__Material__394B877F7C115207");

                entity.Property(e => e.MaterialsId).HasColumnName("MaterialsID");

                entity.Property(e => e.InputDate).HasColumnType("date");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.LogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Materials__LogID__2FA4FD58");
            });

            modelBuilder.Entity<MaterialsLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__Material__5E5499A8251E269B");

                entity.ToTable("Materials_Log");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.CompTypeId).HasColumnName("CompTypeID");

                entity.Property(e => e.InputDate).HasColumnType("datetime");

                entity.Property(e => e.MaterialsName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialsUnit)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompType)
                    .WithMany(p => p.MaterialsLogs)
                    .HasForeignKey(d => d.CompTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Materials__CompT__2CC890AD");
            });

            modelBuilder.Entity<MsEmployee>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EmployeeKey, e.CardNo })
                    .HasName("PK__Ms_Emplo__5FA9ADD9F6496EE9");

                entity.ToTable("Ms_Employee");

                entity.HasIndex(e => e.EmployeeFlag, "emplflag");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CardNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Dept)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EffDt).HasColumnType("date");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HireDt)
                    .HasColumnType("date")
                    .HasColumnName("Hire_DT");

                entity.Property(e => e.TerminationDt).HasColumnType("date");
            });

            modelBuilder.Entity<MsEmployeeBackup>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EmployeeKey, e.CardNo })
                    .HasName("PK__Ms_Emplo__5FA9ADD9F6496EE9_copy17");

                entity.ToTable("Ms_Employee_backup");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CardNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Dept)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EffDt).HasColumnType("date");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HireDt)
                    .HasColumnType("date")
                    .HasColumnName("Hire_DT");

                entity.Property(e => e.TerminationDt).HasColumnType("date");
            });

            modelBuilder.Entity<MsMenuImageUrlNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ms_Menu_ImageURL_New");

                entity.Property(e => e.LinkUrl).IsUnicode(false);

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Menu)
                    .WithMany()
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ms_Menu_I__MenuI__03C67B1A");
            });

            modelBuilder.Entity<MsUdc>(entity =>
            {
                entity.HasKey(e => e.Idudc)
                    .HasName("PK__Ms_UDC__A648B076151FBEB3");

                entity.ToTable("Ms_UDC");

                entity.Property(e => e.Idudc).HasColumnName("IDUDC");

                entity.Property(e => e.Date1)
                    .HasColumnType("date")
                    .HasColumnName("DATE1");

                entity.Property(e => e.Desc1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESC1");

                entity.Property(e => e.Desc2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESC2");

                entity.Property(e => e.Desc3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESC3");

                entity.Property(e => e.Int1).HasColumnName("INT1");

                entity.Property(e => e.Int2).HasColumnName("INT2");

                entity.Property(e => e.Int3).HasColumnName("INT3");

                entity.Property(e => e.Mnum1)
                    .HasColumnType("money")
                    .HasColumnName("MNUM1");

                entity.Property(e => e.Mnum2)
                    .HasColumnType("money")
                    .HasColumnName("MNUM2");

                entity.Property(e => e.TypeUdc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TypeUDC");
            });

            modelBuilder.Entity<PsJob>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PS_JOB");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ACTION");

                entity.Property(e => e.ActionDt)
                    .HasPrecision(0)
                    .HasColumnName("ACTION_DT");

                entity.Property(e => e.ActionReason)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ACTION_REASON");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY");

                entity.Property(e => e.Deptid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPTID");

                entity.Property(e => e.Effdt)
                    .HasPrecision(0)
                    .HasColumnName("EFFDT");

                entity.Property(e => e.Effseq)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("EFFSEQ");

                entity.Property(e => e.EmplClass)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("EMPL_CLASS");

                entity.Property(e => e.EmplRcd)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("EMPL_RCD");

                entity.Property(e => e.EmplStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPL_STATUS");

                entity.Property(e => e.EmplType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPL_TYPE");

                entity.Property(e => e.Emplid)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("EMPLID");

                entity.Property(e => e.FlgKuponMakan)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FLG_KUPON_MAKAN");

                entity.Property(e => e.HireDt)
                    .HasPrecision(0)
                    .HasColumnName("HIRE_DT");

                entity.Property(e => e.HrStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HR_STATUS");

                entity.Property(e => e.JamKerja)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("JAM_KERJA");

                entity.Property(e => e.LastHireDt)
                    .HasPrecision(0)
                    .HasColumnName("LAST_HIRE_DT");

                entity.Property(e => e.Paygroup)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PAYGROUP");

                entity.Property(e => e.TerminationDt)
                    .HasPrecision(0)
                    .HasColumnName("TERMINATION_DT");

                entity.Property(e => e.WorkLocation)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("WORK_LOCATION");
            });

            modelBuilder.Entity<ScAbsen>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__USERINFO__7B9E7F355D31AC51");

                entity.ToTable("Sc_Absen");

                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("USERID");

                entity.Property(e => e.Badgenumber)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("BADGENUMBER");

                entity.Property(e => e.CardNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Ssn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SSN");
            });

            modelBuilder.Entity<TrAbsenHistory>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeKey, e.UserId, e.LogTime })
                    .HasName("PK__Tr_Absen__0DD50A096FDFF59E");

                entity.ToTable("Tr_Absen_history");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.CupId).HasColumnName("CupID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.TypeMenu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorId).HasColumnName("VendorID");
            });

            modelBuilder.Entity<VTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_test");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
