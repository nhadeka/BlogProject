using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Mappings
{
   public class PictureMap:EntityTypeConfiguration<Picture>
    {
        public PictureMap()
        {
            ToTable("Picture");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasColumnType("int");


            Property(x => x.SmPic)
               .IsRequired()
               .IsUnicode()
               .IsMaxLength()
               .HasColumnType("nvarchar");


            Property(x => x.MdPic)
               .IsRequired()
               .IsUnicode()
               .IsMaxLength()
               .HasColumnType("nvarchar");


            Property(x => x.LgPic)
               .IsRequired()
               .IsUnicode()
               .IsMaxLength()
               .HasColumnType("nvarchar");
               
        }
    }
}
