using Blog.Core.Database;
using Blog.Entity.Entities;
using Blog.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repositories.Concretes
{
    public class UserRepo : RepoBase<User>, IUserRepo
    {
        //ilerde eklenmek istenebilecek ekstra işlemler için (ortak işlemler harici)
        public UserRepo(DbContext context) : base(context)
        {
        }
    }
}
