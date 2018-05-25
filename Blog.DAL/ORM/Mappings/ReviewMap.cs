using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Mappings
{
   public class ReviewMap: EntityTypeConfiguration<Review>
    {
        public ReviewMap()
        {
            ToTable("Review");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasColumnType("int");



            Property(x => x.Title)
                .IsRequired()
                .IsUnicode()
                .IsMaxLength()
                .HasColumnType("nvarchar");


            Property(x => x.Content)
               .IsRequired()
               .IsUnicode()
               .IsMaxLength()
               .HasColumnType("nvarchar");



            Property(x => x.AdditionDate)
                .IsRequired()
                .HasColumnType("datetime");





            Property(x => x.GenreId)
               .IsRequired()
               .HasColumnType("int");


            Property(x => x.PictureId)
               .IsRequired()
               .HasColumnType("int");
              

            

            

           //r=review, u=user, g=genre
            HasRequired(r => r.Genre)
                 .WithMany(g => g.Review)
                 .HasForeignKey(r => r.GenreId);

            HasRequired(r => r.Picture)
                .WithMany(p => p.Review)
                .HasForeignKey(r => r.PictureId);


        }
    }
}
