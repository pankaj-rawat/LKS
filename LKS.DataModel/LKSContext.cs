using System.Data.Entity;
using LKS.Entities;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LKS.DataModel
{
    public class LKSContext:DbContext
    {
        public DbSet<NewsPost> NewsPosts{get;set;}
        public DbSet<NewsComment>NewsComments{get;set;}
        public LKSContext(): base("name=LKSconnectionstring")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {                
            modelBuilder.Entity<NewsPost>().Property(p => p.Author)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(true);
            modelBuilder.Entity<NewsPost>().Property(p => p.Detail)
                .IsRequired()
                .IsUnicode(true);
            modelBuilder.Entity<NewsPost>().Property(p => p.Heading)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(150);
            modelBuilder.Entity<NewsPost>().Property(p => p.ImagePath)
                .IsOptional()
                .HasMaxLength(500);
            modelBuilder.Entity<NewsPost>().HasKey(p => p.Id);
            //modelBuilder.Entity<NewsPost>().Property(p => p.Id) //by default
            //    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<NewsComment>().Property(p => p.CommentDate)
                .IsRequired();
            modelBuilder.Entity<NewsComment>().Property(p => p.Comment)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(true);

            modelBuilder.Entity<NewsPost>().HasMany<NewsComment>(s => s.NewsComments)
                .WithRequired(s => s.NewsPost)
                .HasForeignKey(s => s.NewsPostId);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //this will make table name as singular
        }
    }

}
