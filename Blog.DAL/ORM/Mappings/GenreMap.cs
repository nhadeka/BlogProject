using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Mappings
{
   public class GenreMap: EntityTypeConfiguration<Genre>
    {
        public GenreMap()
        {
            ToTable("Genre");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasColumnType("int");


            Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(80)
                .HasColumnType("nvarchar");


            Property(x => x.Description)
                .IsRequired()
                .IsUnicode()
                .IsMaxLength()
                .HasColumnType("nvarchar");
                
        }
    }
}
