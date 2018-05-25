using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Mappings
{
   public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasColumnType("int");
       

            Property(x => x.UserName)
               .IsRequired()
               .IsUnicode()
               .HasMaxLength(80)
               .HasColumnType("nvarchar");
          

            Property(x => x.Email)
              .HasColumnName("Email")
              .HasColumnType("varchar")
              .HasMaxLength(200)

              .IsRequired();


            Property(x => x.Password)
              
               .HasColumnType("nvarchar")
               .HasMaxLength(200)
               .IsUnicode()
              
               .IsRequired();


            Property(x => x.RoleId)
               .HasColumnName("RoleId")
               .HasColumnType("int")

               .IsRequired();

            Property(x => x.RegisterDate)
               .IsRequired()
               .HasColumnType("datetime");
               




            // u=user, r=role
            HasRequired(u => u.Role)
                 .WithMany(r => r.User)
                 .HasForeignKey(u => u.RoleId);

        }
    }
}
