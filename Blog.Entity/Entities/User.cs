using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
  public  class User
    {
        public int Id { get; set; }
        public User()
        {
            RoleId = 2;
            RegisterDate = DateTime.Now;
        }
        public string UserName { get; set; }
       
        public string Email { get; set; }
       
        public string Password { get; set; }
        public int RoleId { get; set; }
       
        public DateTime RegisterDate { get; set; }
        

      
        public virtual Role Role { get; set; }
    }
}
