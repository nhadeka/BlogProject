using Blog.Core.Database;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repositories.Abstracts
{
   public interface IGenreRepo: IRepoBase<Genre>
    {
        //ilerde eklenmek istenebilecek ekstra işlemler için (ortak işlemler harici)

    }
}
