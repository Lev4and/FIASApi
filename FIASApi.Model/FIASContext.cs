using FIASApi.Model.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FIASApi.Model
{
    public partial class FIASContext : DbContext
    {
        public FIASContext()
        {
        }

        public FIASContext(DbContextOptions<FIASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actstat> Actstats { get; set; }
        public virtual DbSet<Addrob> Addrobs { get; set; }
        public virtual DbSet<Centerst> Centersts { get; set; }
        public virtual DbSet<Curentst> Curentsts { get; set; }
        public virtual DbSet<Eststat> Eststats { get; set; }
        public virtual DbSet<Flattype> Flattypes { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Ndoctype> Ndoctypes { get; set; }
        public virtual DbSet<Nordoc> Nordocs { get; set; }
        public virtual DbSet<Operstat> Operstats { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Roomtype> Roomtypes { get; set; }
        public virtual DbSet<Socrbase> Socrbases { get; set; }
        public virtual DbSet<Stead> Steads { get; set; }
        public virtual DbSet<Strstat> Strstats { get; set; }
        public virtual DbSet<VArea> VAreas { get; set; }
        public virtual DbSet<VCity> VCities { get; set; }
        public virtual DbSet<VFlat> VFlats { get; set; }
        public virtual DbSet<VHouse> VHouses { get; set; }
        public virtual DbSet<VOffice> VOffices { get; set; }
        public virtual DbSet<VPlace> VPlaces { get; set; }
        public virtual DbSet<VRegion> VRegions { get; set; }
        public virtual DbSet<VStreet> VStreets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9CDGA5B;Database=FIAS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Actstat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ACTSTAT");

                entity.Property(e => e.Actstatid).HasColumnName("ACTSTATID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Addrob>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ADDROB");

                entity.Property(e => e.Actstatus).HasColumnName("ACTSTATUS");

                entity.Property(e => e.Aoguid)
                    .HasMaxLength(36)
                    .HasColumnName("AOGUID");

                entity.Property(e => e.Aoid)
                    .HasMaxLength(36)
                    .HasColumnName("AOID");

                entity.Property(e => e.Aolevel).HasColumnName("AOLEVEL");

                entity.Property(e => e.Areacode)
                    .HasMaxLength(3)
                    .HasColumnName("AREACODE");

                entity.Property(e => e.Autocode)
                    .HasMaxLength(1)
                    .HasColumnName("AUTOCODE");

                entity.Property(e => e.Cadnum)
                    .HasMaxLength(100)
                    .HasColumnName("CADNUM");

                entity.Property(e => e.Centstatus).HasColumnName("CENTSTATUS");

                entity.Property(e => e.Citycode)
                    .HasMaxLength(3)
                    .HasColumnName("CITYCODE");

                entity.Property(e => e.Code)
                    .HasMaxLength(17)
                    .HasColumnName("CODE");

                entity.Property(e => e.Ctarcode)
                    .HasMaxLength(3)
                    .HasColumnName("CTARCODE");

                entity.Property(e => e.Currstatus).HasColumnName("CURRSTATUS");

                entity.Property(e => e.Divtype).HasColumnName("DIVTYPE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Extrcode)
                    .HasMaxLength(4)
                    .HasColumnName("EXTRCODE");

                entity.Property(e => e.Formalname)
                    .HasMaxLength(120)
                    .HasColumnName("FORMALNAME");

                entity.Property(e => e.Ifnsfl)
                    .HasMaxLength(4)
                    .HasColumnName("IFNSFL");

                entity.Property(e => e.Ifnsul)
                    .HasMaxLength(4)
                    .HasColumnName("IFNSUL");

                entity.Property(e => e.Livestatus).HasColumnName("LIVESTATUS");

                entity.Property(e => e.Nextid)
                    .HasMaxLength(36)
                    .HasColumnName("NEXTID");

                entity.Property(e => e.Normdoc)
                    .HasMaxLength(36)
                    .HasColumnName("NORMDOC");

                entity.Property(e => e.Offname)
                    .HasMaxLength(120)
                    .HasColumnName("OFFNAME");

                entity.Property(e => e.Okato)
                    .HasMaxLength(11)
                    .HasColumnName("OKATO");

                entity.Property(e => e.Oktmo)
                    .HasMaxLength(11)
                    .HasColumnName("OKTMO");

                entity.Property(e => e.Operstatus).HasColumnName("OPERSTATUS");

                entity.Property(e => e.Parentguid)
                    .HasMaxLength(36)
                    .HasColumnName("PARENTGUID");

                entity.Property(e => e.Placecode)
                    .HasMaxLength(3)
                    .HasColumnName("PLACECODE");

                entity.Property(e => e.Plaincode)
                    .HasMaxLength(15)
                    .HasColumnName("PLAINCODE");

                entity.Property(e => e.Plancode)
                    .HasMaxLength(4)
                    .HasColumnName("PLANCODE");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(6)
                    .HasColumnName("POSTALCODE");

                entity.Property(e => e.Previd)
                    .HasMaxLength(36)
                    .HasColumnName("PREVID");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Sextcode)
                    .HasMaxLength(3)
                    .HasColumnName("SEXTCODE");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(10)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Streetcode)
                    .HasMaxLength(4)
                    .HasColumnName("STREETCODE");

                entity.Property(e => e.Terrifnsfl)
                    .HasMaxLength(4)
                    .HasColumnName("TERRIFNSFL");

                entity.Property(e => e.Terrifnsul)
                    .HasMaxLength(4)
                    .HasColumnName("TERRIFNSUL");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATEDATE");
            });

            modelBuilder.Entity<Centerst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CENTERST");

                entity.Property(e => e.Centerstid).HasColumnName("CENTERSTID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Curentst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CURENTST");

                entity.Property(e => e.Curentstid).HasColumnName("CURENTSTID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Eststat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ESTSTAT");

                entity.Property(e => e.Eststatid).HasColumnName("ESTSTATID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(50)
                    .HasColumnName("SHORTNAME");
            });

            modelBuilder.Entity<Flattype>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FLATTYPE");

                entity.Property(e => e.Fltypeid).HasColumnName("FLTYPEID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(50)
                    .HasColumnName("SHORTNAME");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HOUSE");

                entity.Property(e => e.Aoguid)
                    .HasMaxLength(36)
                    .HasColumnName("AOGUID");

                entity.Property(e => e.Buildnum)
                    .HasMaxLength(50)
                    .HasColumnName("BUILDNUM");

                entity.Property(e => e.Cadnum)
                    .HasMaxLength(100)
                    .HasColumnName("CADNUM");

                entity.Property(e => e.Counter).HasColumnName("COUNTER");

                entity.Property(e => e.Divtype).HasColumnName("DIVTYPE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Eststatus).HasColumnName("ESTSTATUS");

                entity.Property(e => e.Houseguid)
                    .HasMaxLength(36)
                    .HasColumnName("HOUSEGUID");

                entity.Property(e => e.Houseid)
                    .HasMaxLength(36)
                    .HasColumnName("HOUSEID");

                entity.Property(e => e.Housenum)
                    .HasMaxLength(20)
                    .HasColumnName("HOUSENUM");

                entity.Property(e => e.Ifnsfl)
                    .HasMaxLength(4)
                    .HasColumnName("IFNSFL");

                entity.Property(e => e.Ifnsul)
                    .HasMaxLength(4)
                    .HasColumnName("IFNSUL");

                entity.Property(e => e.Normdoc)
                    .HasMaxLength(36)
                    .HasColumnName("NORMDOC");

                entity.Property(e => e.Okato)
                    .HasMaxLength(11)
                    .HasColumnName("OKATO");

                entity.Property(e => e.Oktmo)
                    .HasMaxLength(11)
                    .HasColumnName("OKTMO");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(6)
                    .HasColumnName("POSTALCODE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Statstatus).HasColumnName("STATSTATUS");

                entity.Property(e => e.Strstatus).HasColumnName("STRSTATUS");

                entity.Property(e => e.Strucnum)
                    .HasMaxLength(50)
                    .HasColumnName("STRUCNUM");

                entity.Property(e => e.Terrifnsfl)
                    .HasMaxLength(4)
                    .HasColumnName("TERRIFNSFL");

                entity.Property(e => e.Terrifnsul)
                    .HasMaxLength(4)
                    .HasColumnName("TERRIFNSUL");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATEDATE");
            });

            modelBuilder.Entity<Ndoctype>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NDOCTYPE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Ndtypeid).HasColumnName("NDTYPEID");
            });

            modelBuilder.Entity<Nordoc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NORDOC");

                entity.Property(e => e.Docdate)
                    .HasColumnType("datetime")
                    .HasColumnName("DOCDATE");

                entity.Property(e => e.Docimgid)
                    .HasMaxLength(36)
                    .HasColumnName("DOCIMGID");

                entity.Property(e => e.Docname)
                    .HasMaxLength(250)
                    .HasColumnName("DOCNAME");

                entity.Property(e => e.Docnum)
                    .HasMaxLength(20)
                    .HasColumnName("DOCNUM");

                entity.Property(e => e.Normdocid)
                    .HasMaxLength(36)
                    .HasColumnName("NORMDOCID");
            });

            modelBuilder.Entity<Operstat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OPERSTAT");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Operstatid).HasColumnName("OPERSTATID");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ROOM");

                entity.Property(e => e.Cadnum)
                    .HasMaxLength(100)
                    .HasColumnName("CADNUM");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Flatnumber)
                    .HasMaxLength(50)
                    .HasColumnName("FLATNUMBER");

                entity.Property(e => e.Flattype).HasColumnName("FLATTYPE");

                entity.Property(e => e.Houseguid)
                    .HasMaxLength(36)
                    .HasColumnName("HOUSEGUID");

                entity.Property(e => e.Livestatus).HasColumnName("LIVESTATUS");

                entity.Property(e => e.Nextid)
                    .HasMaxLength(36)
                    .HasColumnName("NEXTID");

                entity.Property(e => e.Normdoc)
                    .HasMaxLength(36)
                    .HasColumnName("NORMDOC");

                entity.Property(e => e.Operstatus).HasColumnName("OPERSTATUS");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(6)
                    .HasColumnName("POSTALCODE");

                entity.Property(e => e.Previd)
                    .HasMaxLength(36)
                    .HasColumnName("PREVID");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Roomcadnum)
                    .HasMaxLength(100)
                    .HasColumnName("ROOMCADNUM");

                entity.Property(e => e.Roomguid)
                    .HasMaxLength(36)
                    .HasColumnName("ROOMGUID");

                entity.Property(e => e.Roomid)
                    .HasMaxLength(36)
                    .HasColumnName("ROOMID");

                entity.Property(e => e.Roomnumber)
                    .HasMaxLength(50)
                    .HasColumnName("ROOMNUMBER");

                entity.Property(e => e.Roomtype)
                    .HasMaxLength(2)
                    .HasColumnName("ROOMTYPE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATEDATE");
            });

            modelBuilder.Entity<Roomtype>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ROOMTYPE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Rmtypeid).HasColumnName("RMTYPEID");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(50)
                    .HasColumnName("SHORTNAME");
            });

            modelBuilder.Entity<Socrbase>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SOCRBASE");

                entity.Property(e => e.KodTSt)
                    .HasMaxLength(4)
                    .HasColumnName("KOD_T_ST");

                entity.Property(e => e.Level).HasColumnName("LEVEL");

                entity.Property(e => e.Scname)
                    .HasMaxLength(10)
                    .HasColumnName("SCNAME");

                entity.Property(e => e.Socrname)
                    .HasMaxLength(50)
                    .HasColumnName("SOCRNAME");
            });

            modelBuilder.Entity<Stead>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("STEAD");

                entity.Property(e => e.Cadnum)
                    .HasMaxLength(100)
                    .HasColumnName("CADNUM");

                entity.Property(e => e.Counter).HasColumnName("COUNTER");

                entity.Property(e => e.Divtype).HasColumnName("DIVTYPE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Ifnsfl)
                    .HasMaxLength(4)
                    .HasColumnName("IFNSFL");

                entity.Property(e => e.Ifnsul)
                    .HasMaxLength(4)
                    .HasColumnName("IFNSUL");

                entity.Property(e => e.Livestatus).HasColumnName("LIVESTATUS");

                entity.Property(e => e.Nextid)
                    .HasMaxLength(36)
                    .HasColumnName("NEXTID");

                entity.Property(e => e.Normdoc)
                    .HasMaxLength(36)
                    .HasColumnName("NORMDOC");

                entity.Property(e => e.Number)
                    .HasMaxLength(120)
                    .HasColumnName("NUMBER");

                entity.Property(e => e.Okato)
                    .HasMaxLength(11)
                    .HasColumnName("OKATO");

                entity.Property(e => e.Oktmo)
                    .HasMaxLength(11)
                    .HasColumnName("OKTMO");

                entity.Property(e => e.Operstatus).HasColumnName("OPERSTATUS");

                entity.Property(e => e.Parentguid)
                    .HasMaxLength(36)
                    .HasColumnName("PARENTGUID");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(6)
                    .HasColumnName("POSTALCODE");

                entity.Property(e => e.Previd)
                    .HasMaxLength(36)
                    .HasColumnName("PREVID");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Steadguid)
                    .HasMaxLength(36)
                    .HasColumnName("STEADGUID");

                entity.Property(e => e.Steadid)
                    .HasMaxLength(36)
                    .HasColumnName("STEADID");

                entity.Property(e => e.Terrifnsfl)
                    .HasMaxLength(4)
                    .HasColumnName("TERRIFNSFL");

                entity.Property(e => e.Terrifnsul)
                    .HasMaxLength(4)
                    .HasColumnName("TERRIFNSUL");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATEDATE");
            });

            modelBuilder.Entity<Strstat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("STRSTAT");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(50)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Strstatid).HasColumnName("STRSTATID");
            });

            modelBuilder.Entity<VArea>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_area");

                entity.Property(e => e.Aoguid)
                    .HasMaxLength(36)
                    .HasColumnName("AOGUID");

                entity.Property(e => e.Areacode)
                    .HasMaxLength(3)
                    .HasColumnName("AREACODE");

                entity.Property(e => e.Code)
                    .HasMaxLength(17)
                    .HasColumnName("CODE");

                entity.Property(e => e.Offname)
                    .HasMaxLength(120)
                    .HasColumnName("OFFNAME");

                entity.Property(e => e.Okato)
                    .HasMaxLength(11)
                    .HasColumnName("OKATO");

                entity.Property(e => e.Oktmo)
                    .HasMaxLength(11)
                    .HasColumnName("OKTMO");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Regionname)
                    .HasMaxLength(120)
                    .HasColumnName("REGIONNAME");

                entity.Property(e => e.Scname)
                    .HasMaxLength(10)
                    .HasColumnName("SCNAME");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(10)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Socrname)
                    .HasMaxLength(50)
                    .HasColumnName("SOCRNAME");
            });

            modelBuilder.Entity<VCity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_city");

                entity.Property(e => e.Aoguid)
                    .HasMaxLength(36)
                    .HasColumnName("AOGUID");

                entity.Property(e => e.Areacode)
                    .HasMaxLength(3)
                    .HasColumnName("AREACODE");

                entity.Property(e => e.Areaname)
                    .HasMaxLength(131)
                    .HasColumnName("AREANAME");

                entity.Property(e => e.Citycode)
                    .HasMaxLength(3)
                    .HasColumnName("CITYCODE");

                entity.Property(e => e.Code)
                    .HasMaxLength(17)
                    .HasColumnName("CODE");

                entity.Property(e => e.Offname)
                    .HasMaxLength(120)
                    .HasColumnName("OFFNAME");

                entity.Property(e => e.Okato)
                    .HasMaxLength(11)
                    .HasColumnName("OKATO");

                entity.Property(e => e.Oktmo)
                    .HasMaxLength(11)
                    .HasColumnName("OKTMO");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Regionname)
                    .HasMaxLength(120)
                    .HasColumnName("REGIONNAME");

                entity.Property(e => e.Scname)
                    .HasMaxLength(10)
                    .HasColumnName("SCNAME");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(10)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Socrname)
                    .HasMaxLength(50)
                    .HasColumnName("SOCRNAME");
            });

            modelBuilder.Entity<VFlat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_flat");

                entity.Property(e => e.Areacode)
                    .HasMaxLength(3)
                    .HasColumnName("AREACODE");

                entity.Property(e => e.Areaname)
                    .HasMaxLength(131)
                    .HasColumnName("AREANAME");

                entity.Property(e => e.Buildnum)
                    .HasMaxLength(50)
                    .HasColumnName("BUILDNUM");

                entity.Property(e => e.Citycode)
                    .HasMaxLength(3)
                    .HasColumnName("CITYCODE");

                entity.Property(e => e.Cityname)
                    .HasMaxLength(131)
                    .HasColumnName("CITYNAME");

                entity.Property(e => e.Flatnumber)
                    .HasMaxLength(50)
                    .HasColumnName("FLATNUMBER");

                entity.Property(e => e.Flattypename)
                    .HasMaxLength(50)
                    .HasColumnName("FLATTYPENAME");

                entity.Property(e => e.Flattypeshortname)
                    .HasMaxLength(50)
                    .HasColumnName("FLATTYPESHORTNAME");

                entity.Property(e => e.Fltypeid).HasColumnName("FLTYPEID");

                entity.Property(e => e.Houseguid)
                    .HasMaxLength(36)
                    .HasColumnName("HOUSEGUID");

                entity.Property(e => e.Houseid)
                    .HasMaxLength(36)
                    .HasColumnName("HOUSEID");

                entity.Property(e => e.Housenum)
                    .HasMaxLength(20)
                    .HasColumnName("HOUSENUM");

                entity.Property(e => e.Placecode)
                    .HasMaxLength(3)
                    .HasColumnName("PLACECODE");

                entity.Property(e => e.Placename)
                    .HasMaxLength(131)
                    .HasColumnName("PLACENAME");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(6)
                    .HasColumnName("POSTALCODE");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Regionname)
                    .HasMaxLength(120)
                    .HasColumnName("REGIONNAME");

                entity.Property(e => e.Roomguid)
                    .HasMaxLength(36)
                    .HasColumnName("ROOMGUID");

                entity.Property(e => e.Roomid)
                    .HasMaxLength(36)
                    .HasColumnName("ROOMID");

                entity.Property(e => e.Statstatus).HasColumnName("STATSTATUS");

                entity.Property(e => e.Streetcode)
                    .HasMaxLength(4)
                    .HasColumnName("STREETCODE");

                entity.Property(e => e.Streetname)
                    .HasMaxLength(131)
                    .HasColumnName("STREETNAME");

                entity.Property(e => e.Strucnum)
                    .HasMaxLength(50)
                    .HasColumnName("STRUCNUM");
            });

            modelBuilder.Entity<VHouse>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_house");

                entity.Property(e => e.Aoguid)
                    .HasMaxLength(36)
                    .HasColumnName("AOGUID");

                entity.Property(e => e.Areacode)
                    .HasMaxLength(3)
                    .HasColumnName("AREACODE");

                entity.Property(e => e.Areaname)
                    .HasMaxLength(131)
                    .HasColumnName("AREANAME");

                entity.Property(e => e.Buildnum)
                    .HasMaxLength(50)
                    .HasColumnName("BUILDNUM");

                entity.Property(e => e.Citycode)
                    .HasMaxLength(3)
                    .HasColumnName("CITYCODE");

                entity.Property(e => e.Cityname)
                    .HasMaxLength(131)
                    .HasColumnName("CITYNAME");

                entity.Property(e => e.Houseguid)
                    .HasMaxLength(36)
                    .HasColumnName("HOUSEGUID");

                entity.Property(e => e.Houseid)
                    .HasMaxLength(36)
                    .HasColumnName("HOUSEID");

                entity.Property(e => e.Housenum)
                    .HasMaxLength(20)
                    .HasColumnName("HOUSENUM");

                entity.Property(e => e.Placecode)
                    .HasMaxLength(3)
                    .HasColumnName("PLACECODE");

                entity.Property(e => e.Placename)
                    .HasMaxLength(131)
                    .HasColumnName("PLACENAME");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(6)
                    .HasColumnName("POSTALCODE");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Regionname)
                    .HasMaxLength(120)
                    .HasColumnName("REGIONNAME");

                entity.Property(e => e.Statstatus).HasColumnName("STATSTATUS");

                entity.Property(e => e.Streetcode)
                    .HasMaxLength(4)
                    .HasColumnName("STREETCODE");

                entity.Property(e => e.Streetname)
                    .HasMaxLength(131)
                    .HasColumnName("STREETNAME");

                entity.Property(e => e.Strucnum)
                    .HasMaxLength(50)
                    .HasColumnName("STRUCNUM");
            });

            modelBuilder.Entity<VOffice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_office");

                entity.Property(e => e.Areacode)
                    .HasMaxLength(3)
                    .HasColumnName("AREACODE");

                entity.Property(e => e.Areaname)
                    .HasMaxLength(131)
                    .HasColumnName("AREANAME");

                entity.Property(e => e.Buildnum)
                    .HasMaxLength(50)
                    .HasColumnName("BUILDNUM");

                entity.Property(e => e.Citycode)
                    .HasMaxLength(3)
                    .HasColumnName("CITYCODE");

                entity.Property(e => e.Cityname)
                    .HasMaxLength(131)
                    .HasColumnName("CITYNAME");

                entity.Property(e => e.Flatnumber)
                    .HasMaxLength(50)
                    .HasColumnName("FLATNUMBER");

                entity.Property(e => e.Flattypename)
                    .HasMaxLength(50)
                    .HasColumnName("FLATTYPENAME");

                entity.Property(e => e.Flattypeshortname)
                    .HasMaxLength(50)
                    .HasColumnName("FLATTYPESHORTNAME");

                entity.Property(e => e.Fltypeid).HasColumnName("FLTYPEID");

                entity.Property(e => e.Houseguid)
                    .HasMaxLength(36)
                    .HasColumnName("HOUSEGUID");

                entity.Property(e => e.Houseid)
                    .HasMaxLength(36)
                    .HasColumnName("HOUSEID");

                entity.Property(e => e.Housenum)
                    .HasMaxLength(20)
                    .HasColumnName("HOUSENUM");

                entity.Property(e => e.Placecode)
                    .HasMaxLength(3)
                    .HasColumnName("PLACECODE");

                entity.Property(e => e.Placename)
                    .HasMaxLength(131)
                    .HasColumnName("PLACENAME");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(6)
                    .HasColumnName("POSTALCODE");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Regionname)
                    .HasMaxLength(120)
                    .HasColumnName("REGIONNAME");

                entity.Property(e => e.Roomguid)
                    .HasMaxLength(36)
                    .HasColumnName("ROOMGUID");

                entity.Property(e => e.Roomid)
                    .HasMaxLength(36)
                    .HasColumnName("ROOMID");

                entity.Property(e => e.Statstatus).HasColumnName("STATSTATUS");

                entity.Property(e => e.Streetcode)
                    .HasMaxLength(4)
                    .HasColumnName("STREETCODE");

                entity.Property(e => e.Streetname)
                    .HasMaxLength(131)
                    .HasColumnName("STREETNAME");

                entity.Property(e => e.Strucnum)
                    .HasMaxLength(50)
                    .HasColumnName("STRUCNUM");
            });

            modelBuilder.Entity<VPlace>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_place");

                entity.Property(e => e.Aoguid)
                    .HasMaxLength(36)
                    .HasColumnName("AOGUID");

                entity.Property(e => e.Areacode)
                    .HasMaxLength(3)
                    .HasColumnName("AREACODE");

                entity.Property(e => e.Areaname)
                    .HasMaxLength(131)
                    .HasColumnName("AREANAME");

                entity.Property(e => e.Citycode)
                    .HasMaxLength(3)
                    .HasColumnName("CITYCODE");

                entity.Property(e => e.Cityname)
                    .HasMaxLength(131)
                    .HasColumnName("CITYNAME");

                entity.Property(e => e.Code)
                    .HasMaxLength(17)
                    .HasColumnName("CODE");

                entity.Property(e => e.Offname)
                    .HasMaxLength(120)
                    .HasColumnName("OFFNAME");

                entity.Property(e => e.Okato)
                    .HasMaxLength(11)
                    .HasColumnName("OKATO");

                entity.Property(e => e.Oktmo)
                    .HasMaxLength(11)
                    .HasColumnName("OKTMO");

                entity.Property(e => e.Placecode)
                    .HasMaxLength(3)
                    .HasColumnName("PLACECODE");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Regionname)
                    .HasMaxLength(120)
                    .HasColumnName("REGIONNAME");

                entity.Property(e => e.Scname)
                    .HasMaxLength(10)
                    .HasColumnName("SCNAME");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(10)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Socrname)
                    .HasMaxLength(50)
                    .HasColumnName("SOCRNAME");
            });

            modelBuilder.Entity<VRegion>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_region");

                entity.Property(e => e.Aoguid)
                    .HasMaxLength(36)
                    .HasColumnName("AOGUID");

                entity.Property(e => e.Code)
                    .HasMaxLength(17)
                    .HasColumnName("CODE");

                entity.Property(e => e.Offname)
                    .HasMaxLength(120)
                    .HasColumnName("OFFNAME");

                entity.Property(e => e.Okato)
                    .HasMaxLength(11)
                    .HasColumnName("OKATO");

                entity.Property(e => e.Oktmo)
                    .HasMaxLength(11)
                    .HasColumnName("OKTMO");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Scname)
                    .HasMaxLength(10)
                    .HasColumnName("SCNAME");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(10)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Socrname)
                    .HasMaxLength(50)
                    .HasColumnName("SOCRNAME");
            });

            modelBuilder.Entity<VStreet>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_street");

                entity.Property(e => e.Aoguid)
                    .HasMaxLength(36)
                    .HasColumnName("AOGUID");

                entity.Property(e => e.Areacode)
                    .HasMaxLength(3)
                    .HasColumnName("AREACODE");

                entity.Property(e => e.Areaname)
                    .HasMaxLength(131)
                    .HasColumnName("AREANAME");

                entity.Property(e => e.Citycode)
                    .HasMaxLength(3)
                    .HasColumnName("CITYCODE");

                entity.Property(e => e.Cityname)
                    .HasMaxLength(131)
                    .HasColumnName("CITYNAME");

                entity.Property(e => e.Code)
                    .HasMaxLength(17)
                    .HasColumnName("CODE");

                entity.Property(e => e.Offname)
                    .HasMaxLength(120)
                    .HasColumnName("OFFNAME");

                entity.Property(e => e.Okato)
                    .HasMaxLength(11)
                    .HasColumnName("OKATO");

                entity.Property(e => e.Oktmo)
                    .HasMaxLength(11)
                    .HasColumnName("OKTMO");

                entity.Property(e => e.Placecode)
                    .HasMaxLength(3)
                    .HasColumnName("PLACECODE");

                entity.Property(e => e.Placename)
                    .HasMaxLength(131)
                    .HasColumnName("PLACENAME");

                entity.Property(e => e.Regioncode)
                    .HasMaxLength(2)
                    .HasColumnName("REGIONCODE");

                entity.Property(e => e.Regionname)
                    .HasMaxLength(120)
                    .HasColumnName("REGIONNAME");

                entity.Property(e => e.Scname)
                    .HasMaxLength(10)
                    .HasColumnName("SCNAME");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(10)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Socrname)
                    .HasMaxLength(50)
                    .HasColumnName("SOCRNAME");

                entity.Property(e => e.Streetcode)
                    .HasMaxLength(4)
                    .HasColumnName("STREETCODE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
