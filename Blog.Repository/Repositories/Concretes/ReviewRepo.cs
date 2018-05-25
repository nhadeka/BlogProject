using Blog.Core.Database;
using Blog.Entity.Entities;
using Blog.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repositories.Concretes
{
    public class ReviewRepo : RepoBase<Review>, IReviewRepo
    {
        //ilerde eklenmek istenebilecek ekstra işlemler için (ortak işlemler harici)
        public ReviewRepo(DbContext context) : base(context)
        {
        }

       
    }
}
