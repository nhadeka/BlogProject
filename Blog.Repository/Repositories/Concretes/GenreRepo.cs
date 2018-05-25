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
    public class GenreRepo : RepoBase<Genre>, IGenreRepo
    {
        //ilerde eklenmek istenebilecek ekstra işlemler için (ortak işlemler harici)
        public GenreRepo(DbContext context) : base(context)
        {
        }
    }
}
