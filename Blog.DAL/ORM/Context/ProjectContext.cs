using Blog.DAL.ORM.Mappings;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Context
{
    
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("ConnDb")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectContext>());
        }
        
       
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Review> BookReview { get; set; }
        public DbSet<Genre> Genre { get; set; }
       
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Add(new PluralizingTableNameConvention());

            
           
            modelBuilder.Configurations.Add(new PictureMap());
            modelBuilder.Configurations.Add(new ReviewMap());
            modelBuilder.Configurations.Add(new GenreMap());
           
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
        }
    }
}
