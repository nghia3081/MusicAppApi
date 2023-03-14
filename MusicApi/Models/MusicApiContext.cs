using Microsoft.EntityFrameworkCore;

namespace MusicApi.Models
{
    public partial class MusicApiContext : DbContext
    {
        public MusicApiContext()
        {
        }

        public MusicApiContext(DbContextOptions<MusicApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertisement> Advertisements { get; set; } = null!;
        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Playlist> Playlists { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("MusicApi"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.ToTable("Advertisement");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(200);

                entity.Property(e => e.ImageUrl).HasMaxLength(200);
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__Album__ArtistId__38996AB5");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("Playlist");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IconUrl).HasMaxLength(200);

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.PlayUrl).HasMaxLength(200);

                entity.HasOne(d => d.Advertisement)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.AdvertisementId)
                    .HasConstraintName("FK__Song__Advertisem__5812160E");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK__Song__AlbumId__5535A963");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Song__CategoryId__571DF1D5");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.PlaylistId)
                    .HasConstraintName("FK__Song__PlaylistId__5441852A");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__Song__TopicId__5629CD9C");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
