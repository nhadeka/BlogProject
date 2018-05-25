using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
   public class Picture
    {
        public int Id { get; set; }
       
        public string SmPic { get; set; }
        public string MdPic { get; set; }
        public string LgPic { get; set; }

        public virtual ICollection< Review> Review { get; set; }
    }
}
