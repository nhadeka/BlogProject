using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Mappings
{
    public class RoleMap: EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable("Role");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasColumnType("int");


            Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20)
                .HasColumnType("nvarchar");
                
        }
    }
}
