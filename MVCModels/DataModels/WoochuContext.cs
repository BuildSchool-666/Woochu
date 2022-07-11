using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class WoochuContext : DbContext
    {
        public WoochuContext()
        {

        }

        public WoochuContext(DbContextOptions<WoochuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AltPrice> AltPrices { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<HostApplication> HostApplications { get; set; }
        public virtual DbSet<ImageFile> ImageFiles { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomEvent> RoomEvents { get; set; }
        public virtual DbSet<RoomFacility> RoomFacilities { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=Woochu;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<AltPrice>(entity =>
            {
                entity.ToTable("AltPrice");

                entity.Property(e => e.AltPriceId).HasComment("特殊價錢ID");

                entity.Property(e => e.BasicPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("初價");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("折扣");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasComment("特殊日價錢開始");

                entity.Property(e => e.RoomId).HasComment("房間ID");

                entity.Property(e => e.ServiceCharge)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("服務費");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasComment("特殊日價錢開始");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.AltPrices)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AltPrice_Room");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasComment("評論ID");

                entity.Property(e => e.Accuracy).HasComment("準確度");

                entity.Property(e => e.AuditRejectReason).HasComment("審核不通過原因");

                entity.Property(e => e.AuditTime)
                    .HasColumnType("datetime")
                    .HasComment("審核時間");

                entity.Property(e => e.CheckIn).HasComment("入住");

                entity.Property(e => e.Cleanliness).HasComment("整潔度");

                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasColumnName("Comment")
                    .HasComment("評論");

                entity.Property(e => e.Communication).HasComment("溝通度");

                entity.Property(e => e.Cp)
                    .HasColumnName("CP")
                    .HasComment("性價比");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("評論時間");

                entity.Property(e => e.IsDelete).HasComment("刪除狀態?");

                entity.Property(e => e.Location).HasComment("地點");

                entity.Property(e => e.RoomId).HasComment("房源ID");

                entity.Property(e => e.UserId).HasComment("使用者ID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Comment_Room");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("Facility");

                entity.Property(e => e.FacilityId).HasComment("設備ID");

                entity.Property(e => e.FacilityName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("設備名稱");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.IsMulti).HasComment("是否為複數");
            });

            modelBuilder.Entity<HostApplication>(entity =>
            {
                entity.ToTable("HostApplication");

                entity.Property(e => e.HostApplicationId).HasComment("房東ID");

                entity.Property(e => e.ApplyTime)
                    .HasColumnType("datetime")
                    .HasComment("申請時間");

                entity.Property(e => e.AuditRejectReason).HasComment("審核時間");

                entity.Property(e => e.AuditTime)
                    .HasColumnType("datetime")
                    .HasComment("審核不通過原因");

                entity.Property(e => e.BankAccount)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasComment("房東戶頭");

                entity.Property(e => e.UserId).HasComment("使用者ID");

                entity.Property(e => e.VerifyData)
                    .IsRequired()
                    .HasComment("房東申請資料(一張身分卡)");

                entity.Property(e => e.VerifyState).HasComment("1未審核，2審核通過，3審核未通過");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HostApplications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Host_User");
            });

            modelBuilder.Entity<ImageFile>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("ImageFile");

                entity.Property(e => e.ImageId).HasComment("房源照片ID");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasComment("房源照片URL");

                entity.Property(e => e.RoomId).HasComment("房源ID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.ImageFiles)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImageFile_Room1");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Message");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Message1)
                    .HasColumnType("ntext")
                    .HasColumnName("Message");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasComment("訂單ID");

                entity.Property(e => e.AdultCount).HasComment("成人數");

                entity.Property(e => e.BabyCount).HasComment("嬰兒數");

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("datetime")
                    .HasComment("入住日期");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnType("datetime")
                    .HasComment("退房日期");

                entity.Property(e => e.CustomerId).HasComment("顧客ID");

                entity.Property(e => e.KidCount).HasComment("小孩數");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasComment("下單日期");

                entity.Property(e => e.PayedStatus).HasComment("訂單狀態(1待付、2已付、3待取消訂單、4待退款、5已退款)");

                entity.Property(e => e.RoomId).HasComment("房源ID");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("總價");

                entity.Property(e => e.UserId).HasComment("房東ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Room");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasComment("房間ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasComment("房源詳細地址");

                entity.Property(e => e.BasicPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("初價");

                entity.Property(e => e.BrowseCount).HasComment("瀏覽次數");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasComment("房源縣市");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("房屋建造日期");

                entity.Property(e => e.Description).HasComment("房源描述(ckeditor, QuillEditor)");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("折扣");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasComment("房源區");

                entity.Property(e => e.GuestCount).HasComment("旅客數");

                entity.Property(e => e.Latitude)
                    .HasColumnType("decimal(8, 6)")
                    .HasComment("房源緯度");

                entity.Property(e => e.Longitude)
                    .HasColumnType("decimal(9, 6)")
                    .HasComment("房源經度");

                entity.Property(e => e.PrivacyTypeId).HasComment("房源空間(1Entire 2.Privacy獨間 3. Shared合併房間)");

                entity.Property(e => e.PublishTime)
                    .HasColumnType("datetime")
                    .HasComment("發布日期");

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("房間名稱");

                entity.Property(e => e.RoomStatus).HasComment("1上架2暫時下架3刪除房源");

                entity.Property(e => e.RoomTypeId).HasComment("房源樣式ID");

                entity.Property(e => e.ServiceCharge)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("服務費");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("更新日期");

                entity.Property(e => e.UserId).HasComment("房東ID");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("房源郵遞區號");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_RoomType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_User");
            });

            modelBuilder.Entity<RoomEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK_Event");

                entity.ToTable("RoomEvent");

                entity.Property(e => e.EventId).HasComment("房間事件ID");

                entity.Property(e => e.EventEndDate)
                    .HasColumnType("datetime")
                    .HasComment("房間事件結束時間");

                entity.Property(e => e.EventName).HasComment("房間事件名稱");

                entity.Property(e => e.EventStartDate)
                    .HasColumnType("datetime")
                    .HasComment("房間事件開始時間");

                entity.Property(e => e.RoomId).HasComment("房間ID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomEvents)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Room");
            });

            modelBuilder.Entity<RoomFacility>(entity =>
            {
                entity.ToTable("RoomFacility");

                entity.Property(e => e.RoomFacilityId).HasComment("房源設備ID");

                entity.Property(e => e.FacilityId).HasComment("設備ID");

                entity.Property(e => e.Quantity).HasComment("defalut = 1 => check, ,> 1 display total");

                entity.Property(e => e.RoomId).HasComment("房源ID");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.RoomFacilities)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomFacility_AmenitiesAndEquipment");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomFacilities)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomFacility_Room");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("RoomType");

                entity.Property(e => e.RoomTypeId).HasComment("房源樣式ID");

                entity.Property(e => e.ParentId).HasComment("父類別ID");

                entity.Property(e => e.RoomTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("房源樣式名稱(Rental, Loft)");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_RoomType_RoomType");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasComment("使用者ID");

                entity.Property(e => e.About).HasComment("使用者自介");

                entity.Property(e => e.Address).HasComment("使用者地址");

                entity.Property(e => e.AverageReplyTime).HasComment("使用者平均回復時間(分鐘)");

                entity.Property(e => e.City).HasComment("使用者城市");

                entity.Property(e => e.Country).HasComment("使用者國家");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("使用者建立時間");

                entity.Property(e => e.District).HasComment("使用者州省區");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB")
                    .HasComment("使用者生日");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("使用者email");

                entity.Property(e => e.EmailVerify).HasComment("使用者email驗證");

                entity.Property(e => e.EmergencyContactEmail)
                    .HasMaxLength(50)
                    .HasComment("使用者緊急連絡人Email");

                entity.Property(e => e.EmergencyContactName)
                    .HasMaxLength(200)
                    .HasComment("使用者緊急連絡人名字");

                entity.Property(e => e.EmergencyContactNumber)
                    .HasMaxLength(50)
                    .HasComment("使用者緊急連絡人手機號碼");

                entity.Property(e => e.EmergencyContactRelation)
                    .HasMaxLength(50)
                    .HasComment("使用者緊急連絡人關係");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true)
                    .HasComment("使用者名");

                entity.Property(e => e.Gender).HasComment("使用者性別(1男2女3第三性4不透露)");

                entity.Property(e => e.Ic)
                    .HasMaxLength(50)
                    .HasColumnName("IC")
                    .HasComment("使用者身份證字號");

                entity.Property(e => e.IsHost).HasComment("是否為房東");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true)
                    .HasComment("使用者姓");

                entity.Property(e => e.LastOnlineTime)
                    .HasColumnType("datetime")
                    .HasComment("使用者最後上線");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasComment("使用者email密碼");

                entity.Property(e => e.PersonalPhoto)
                    .HasMaxLength(200)
                    .HasComment("使用者頭貼");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasComment("使用者手機號碼");

                entity.Property(e => e.PhoneConfirmed).HasComment("使用者手機號碼驗證");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .HasComment("使用者郵遞區號");
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");

                entity.Property(e => e.WishListId).HasComment("願望清單ID");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasComment("房源新增時間");

                entity.Property(e => e.RoomId).HasComment("房源ID");

                entity.Property(e => e.UserId).HasComment("使用者ID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishList_Room");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishList_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
