using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Review
    {
        public Review()
        {
            AdditionDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime AdditionDate { get; set; }
       
        public int GenreId { get; set; }
        public int PictureId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Picture Picture { get; set; }
    } 
}
