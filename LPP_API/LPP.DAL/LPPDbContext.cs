using LPP.Entities;
using Microsoft.EntityFrameworkCore;
    
namespace LPP.DAL
{

    public class LppDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Hashtag> Hashtags { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sanction> Sanctions { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PicturePost> PicturesPost { get; set; }
        public virtual DbSet<PicturePhoto> PicturesPhoto { get; set; }
        public virtual DbSet<PictureProduct> PicturesProduct { get; set; }


        public LppDbContext(DbContextOptions<LppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");


                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");


                entity.HasOne(e => e.Seller)
                    .WithMany(u => u.SellerChats)
                    .HasForeignKey(e => e.SellerId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Buyer)
                    .WithMany(u => u.InterestedChats)
                    .HasForeignKey(e => e.BuyerId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Product);
                entity.HasMany(e => e.Messages)
                    .WithOne(e => e.Chat)
                    .HasForeignKey(e => e.ChatId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Chat_Message");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");


                entity.Property(e => e.Texte)
                    .HasColumnName("texte")
                    .IsRequired();
                entity.Property(e => e.Dislike)
                    .HasColumnName("dislike")
                    .HasDefaultValue(0);
                entity.Property(e => e.Like)
                    .HasColumnName("like")
                    .HasDefaultValue(0);
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Comments)
                    .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Hashtag>(entity =>
            {
                entity.ToTable("Hashtag");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");


                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();
                entity.HasMany(e => e.Post)
                    .WithMany(p => p.Hashtags)
                    .UsingEntity(j => j.ToTable("Post_Hashtag"));
                entity.HasMany(e => e.Photo)
                    .WithMany(p => p.Hashtags)
                    .UsingEntity(j => j.ToTable("Photo_Hashtag"));
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");


                entity.Property(e => e.IsRead)
                    .HasColumnName("isRead")
                    .HasDefaultValue(false);
                entity.Property(e => e.Texte)
                    .HasColumnName("texte")
                    .IsRequired();
                entity.HasOne(e => e.Chat)
                    .WithMany(m => m.Messages)
                    .HasForeignKey(e => e.ChatId);
                entity.HasOne(e => e.User);

            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");


                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsRequired(false);
                entity.Property(e => e.Like)
                    .HasColumnName("like")
                    .HasDefaultValue(0);
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Photos)
                    .HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Pictures)
                    .WithOne(e => e.Item)
                    .HasForeignKey(e => e.ItemId);
                entity.HasMany(e => e.Hashtags)
                    .WithMany(h => h.Photo)
                    .UsingEntity(j => j.ToTable("Photo_Hashtag"));
                entity.HasMany(e => e.Comments);
            });

            modelBuilder.Entity<PicturePost>(entity =>
            {
                entity.ToTable("PicturePost");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");



                entity.Property(e => e.PictureURL)
                    .HasColumnName("PictureURL")
                    .IsRequired();

            });

            modelBuilder.Entity<PicturePhoto>(entity =>
            {
                entity.ToTable("PicturePhoto");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");



                entity.Property(e => e.PictureURL)
                    .HasColumnName("PictureURL")
                    .IsRequired();

            });

            modelBuilder.Entity<PictureProduct>(entity =>
            {
                entity.ToTable("PictureProduct");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");



                entity.Property(e => e.PictureURL)
                    .HasColumnName("PictureURL")
                    .IsRequired();

            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");


                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .IsRequired();
                entity.Property(e => e.Texte)
                    .HasColumnName("texte")
                    .IsRequired();
                entity.Property(e => e.Like)
                    .HasColumnName("like")
                    .HasDefaultValue(0);
                entity.HasMany(e => e.Pictures)
                    .WithOne(e => e.Item)
                    .HasForeignKey(e => e.ItemId);
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Posts)
                    .HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Hashtags)
                    .WithMany(h => h.Post)
                    .UsingEntity(j => j.ToTable("Post_Hashtag"));
                entity.HasMany(e => e.Comments);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.Property(e => e.Id)
                   .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");

                entity.Property(e => e.Description)
                    .HasColumnName("description");
                entity.Property(e => e.IsSold)
                    .HasColumnName("isSold");
                entity.Property(e => e.Price)
                   .HasColumnName("price")
                   .IsRequired();
                entity.HasMany(e => e.Pictures)
                    .WithOne(e => e.Item)
                    .HasForeignKey(e => e.ItemId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Seller)
                    .WithMany(u => u.SoldProduct)
                    .HasForeignKey(e => e.SellerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();
                entity.HasOne(e => e.Buyer)
                    .WithMany(u => u.BoughtProducts)
                    .HasForeignKey(e => e.BuyerId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(e => e.Comments);
            });

            modelBuilder.Entity<Sanction>(entity =>
            {
                entity.ToTable("Sanction");
                entity.Property(e => e.Id)
                   .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");



                entity.Property(e => e.Duration)
                   .HasColumnName("duration")
                   .IsRequired();
                entity.Property(e => e.Type)
                   .HasColumnName("type")
                   .IsRequired();
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Sanctions)
                    .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.Property(e => e.Id)
                   .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");


                entity.Property(e => e.Karma)
                   .HasColumnName("karma")
                   .HasDefaultValue(0);
                entity.Property(e => e.Firstname)
                   .HasColumnName("firstName")
                   .IsRequired();
                entity.Property(e => e.Lastname)
                   .HasColumnName("lastName")
                   .IsRequired();
                entity.Property(e => e.Pseudo)
                   .HasColumnName("pseudo")
                   .IsRequired();
                entity.Property(e => e.Email)
                   .HasColumnName("email")
                   .IsRequired();
                entity.Property(e => e.Password)
                   .HasColumnName("password")
                   .IsRequired();
                entity.Property(e => e.IsAdmin)
                    .HasColumnName("isAdmin");
                entity.Property(e => e.Report)
                    .HasColumnName("report");
            });
            
            modelBuilder.Entity<Follow>(entity =>
            {
                entity.ToTable("Follow");
                entity.Property(e => e.Id)
                   .HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.UpdatedAt)
                    .HasComputedColumnSql("getdate()");

                entity.HasOne(e => e.Follower)
                    .WithMany(u => u.Followers)
                    .HasForeignKey(e => e.FollowerId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Followed)
                    .WithMany(u => u.Followeds)
                    .HasForeignKey(e => e.FollowedId)
                    .OnDelete(DeleteBehavior.NoAction);

            });
        }
    }
}
