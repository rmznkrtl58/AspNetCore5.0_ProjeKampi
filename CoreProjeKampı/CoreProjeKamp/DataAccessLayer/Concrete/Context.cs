using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
        //IdentityDbContext<1.p->bizim oluşturduğumuz Kullanıcı Tablosu
        //2.p->Role tablomuz,3.p->hem AppUser ile hemde AppRole classımda tanımlamış olduğum int değeri>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VM4NR9R\\SQLEXPRESS;database=coreprojekamp;integrated security=true;");
        }
        //ÇOKA ÇOK İLİŞKİLERDE AŞAĞIDAKİ YAPI KULLANILIR
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Has one=> bir tablodaki varlığın başka bir tabloyla bir ilişkisi olduğunu belirtir.
            modelBuilder.Entity<Message2>()
            .HasOne(x => x.SenderUser)
            .WithMany(x => x.WriterSender)
            .HasForeignKey(x => x.SenderId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(x => x.WriterReceiver)
                .HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //IdentityDbContext'tten miras aldığım için sorun çıkarmasın diye aşağıdaki 
            //metodu yazıyorum
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<About> abouts { get; set; }
        public DbSet<Blog> Blogs  { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Comment>Comments   { get; set; }
        public DbSet<Contact>Contacts   { get; set; }
        public DbSet<Writer>Writers   { get; set; }
        public DbSet<SubscribeMail> SubscribeMails { get; set; }
        public DbSet<BlogScore>BlogScores { get; set; }
        public DbSet<Notification>Notifications { get; set; }
        public DbSet<Message>Messages { get; set; }
        public DbSet<Message2>Message2s { get; set; }
        public DbSet<Admin>Admins { get; set; }
    }
}
